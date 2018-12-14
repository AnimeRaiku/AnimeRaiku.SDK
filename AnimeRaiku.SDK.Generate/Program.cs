using AnimeRaiku.SDK.Auth;
using AnimeRaiku.SDK.Client;
using AnimeRaiku.SDK.Messages;
using AnimeRaiku.SDK.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using AnimeRaiku.SDK.Api;

namespace AnimeRaiku.SDK.Generate
{
    class Program
    {
        private static ApiClient api = null;
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("client-secrets.json")
                .Build();
            var token = new PasswordProvider(config["ClientId"], config["ClientSecret"], retry => new NetworkCredential(config["User"], config["Password"]), config["AuthURL"]);
            ApiConfiguration apiconfig = new ApiConfiguration()
            {
                BaseUrl = "https://api.animeraiku.com"
            };
            api = new ApiClient(token, apiconfig);

            var dtt = GetDTT().Result;
            var dt = GetDT().Result;

            foreach (var item in dtt)
            {
                if ((new string[] { "validDomains", "invalidNames" }).Contains(item.Attributes.Slug))
                    continue;

                CreateClass(item, dt.Where(k => k.Attributes.Type.Id == item.Id));
            }

            
        }

        static async Task<List<Data<DataProviderType>>> GetDTT()
        {
            List<Data<DataProviderType>> result = new List<Data<DataProviderType>>();
            ApiMessages<DataProviderType> response = null;
            uint page = 1;
            do
            {
                response = await api.DataProviderType.FindAsync(new Query.QueryExpression() { Page = page });
                result.AddRange(response.Data);
                page++;
            } while (response.Meta.Pagination.CurrentPage < response.Meta.Pagination.TotalPages);

            return result;
        }

        static async Task<List<Data<DataProvider>>> GetDT()
        {
            List<Data<DataProvider>> result = new List<Data<DataProvider>>();
            ApiMessages<DataProvider> response = null;
            uint page = 1;
            do
            {
                response = await api.DataProvider.FindAsync(new Query.QueryExpression() { Page = page });
                result.AddRange(response.Data);
                page++;
            } while (response.Meta.Pagination.CurrentPage < response.Meta.Pagination.TotalPages);

            return result;
        }

        private static Dictionary<String, String> replace = new Dictionary<string, string>()
        {
            { "creativeWorks", "CreativeWorkType" }
        };

        static void CreateClass(Data<DataProviderType> dtt, IEnumerable<Data<DataProvider>> dt)
        {
            // Create a namespace: (namespace CodeGenerationSample)
            var @namespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("AnimeRaiku.SDK.Model"));

            

            // Add System using statement: (using System)
            @namespace = @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")));
            @namespace = @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Runtime.Serialization")));
            @namespace = @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Newtonsoft.Json")));
            @namespace = @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Newtonsoft.Json.Converters")));

            var ddtname = replace.ContainsKey(dtt.Attributes.Slug) ? replace[dtt.Attributes.Slug] : EnumName(dtt.Attributes.Slug);
            //  Create a class: (class Order)
            var enumDeclaration = SyntaxFactory.EnumDeclaration(ddtname);

            // Add the public modifier: (public class Order)
            enumDeclaration = enumDeclaration.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));
            {
                var name = SyntaxFactory.ParseName("JsonConverter");
                var arguments = SyntaxFactory.ParseAttributeArgumentList("(typeof(StringEnumConverter))");
                var attribute = SyntaxFactory.Attribute(name, arguments); //MyAttribute("some_param")

                var attributeList = new SeparatedSyntaxList<AttributeSyntax>();
                attributeList = attributeList.Add(attribute);
                var list = SyntaxFactory.AttributeList(attributeList);
                enumDeclaration = enumDeclaration.AddAttributeLists(list);
            }



            foreach (var item in dt.Select(k => k.Attributes.Value).Distinct())
            {
                var name = SyntaxFactory.ParseName("EnumMember");
                var arguments = SyntaxFactory.ParseAttributeArgumentList("(Value = \""+ item + "\")");
                var attribute = SyntaxFactory.Attribute(name, arguments); //MyAttribute("some_param")

                var attributeList = new SeparatedSyntaxList<AttributeSyntax>();
                attributeList = attributeList.Add(attribute);
                var list = SyntaxFactory.AttributeList(attributeList);

                string formatedname = "";
                if ((new string[] { "countries", "languages" }).Contains(dtt.Attributes.Slug))
                    formatedname = item.Replace("-","_").ToUpper();
                else
                    formatedname = PascalCase(item);

                var enumMemberDeclaration = SyntaxFactory.EnumMemberDeclaration(formatedname).AddAttributeLists(list);
                enumDeclaration = enumDeclaration.AddMembers(enumMemberDeclaration);
            }

            // Add the class to the namespace.
            @namespace = @namespace.AddMembers(enumDeclaration);

            // Normalize and get code as string.
            var code = @namespace.NormalizeWhitespace(" ", true)
                .ToFullString();

            using(StreamWriter sw  =new StreamWriter(@"..\..\..\..\AnimeRaiku.SDK\Model\Generated\" + ddtname + ".cs"))
            {
                sw.Write(GetHeader());
                sw.Write(code);
            }
        }

        private static String GetHeader()
        {
            String header = "//------------------------------------------------------------------------------" + Environment.NewLine;
            header +=       "// <auto-generated>" + Environment.NewLine;
            header +=       "//     This code was generated by a tool." + Environment.NewLine;
            header +=       "//" + Environment.NewLine;
            header +=       "//     Changes to this file may cause incorrect behavior and will be lost if" + Environment.NewLine;
            header +=       "//     the code is regenerated." + Environment.NewLine;
            header +=       "// </auto-generated>" + Environment.NewLine;
            header +=       "//------------------------------------------------------------------------------" + Environment.NewLine + Environment.NewLine + Environment.NewLine;

            return header;
        }

        static String PascalCase(String text)
        {
            var yourString = text.Replace("Ō", "O").ToLower().Replace("_", " ").Replace("-", " ");
            TextInfo info = CultureInfo.CurrentCulture.TextInfo;
            var str = info.ToTitleCase(yourString).Replace(" ", string.Empty);
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            return rgx.Replace(str, "");
        }

        static String EnumName(String text)
        {
            var newValue = Regex.Replace(text, "([a-z])([A-Z])", "$1 $2");

            TextInfo info = CultureInfo.CurrentCulture.TextInfo;
            var str = info.ToTitleCase(newValue).Replace(" ", string.Empty);

            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            return rgx.Replace(str, "");
        }
    }
}
