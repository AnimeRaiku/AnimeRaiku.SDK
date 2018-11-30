using AnimeRaiku.SDK.Model;
using AnimeRaiku.SDK.Model.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Test.Factory
{
    public class PersonFactory : BaseFactory<Person>
    {
        public override Person Create()
        {
            return new Person()
            {
                Slug = "Test",
                BirthDate = DateTime.Now,
                BirthPlace = "CR",
                Blood = "A+",
                DeathDate = DateTime.Now.AddYears(10),
                DeathPlace = "MD",
                Description = new Description[]{
                    new Description() {
                        Id = Id.NewId(),
                        Content = "Autor",
                        IsVisible = true,
                        Lang = "ES"
                    },
                    new Description() {
                        Id = Id.NewId(),
                        Content = "Autor2",
                        IsVisible = false,
                        Lang = "EN"
                    }
                },
                Name = new PersonName[]
                {
                    new PersonName(){
                        Id = Id.NewId(),
                        Lang = "JA-X",
                        Type = "MAIN",
                        FirstName = "Tomokazu",
                        LastName = "Seki",
                        IsVisible = true
                    },
                    new PersonName(){
                        Id = Id.NewId(),
                        Lang = "JA",
                        Type = "MAIN",
                        FirstName = "智一",
                        LastName = "関",
                        IsVisible = false
                    }
                },
                CreativeWorks = new PersonCreativeWorks[]{
                    new PersonCreativeWorks(){
                        Id = Id.NewId(),
                        Type = "voice",
                        Role = "role"
                    }
                },
                ExternalSources = new ExternalSources[]
                {
                    new ExternalSources(){
                        Id = "MAL:People:1",
                        Type ="MyAnimeList",
                        Url = "https://myanimelist.net/people/1/Tomokazu_Seki"
                    }
                }
            };
        }
    }
}
