//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace AnimeRaiku.SDK.Model
{
 using System;
 using System.Runtime.Serialization;
 using Newtonsoft.Json;
 using Newtonsoft.Json.Converters;

 [JsonConverter(typeof(StringEnumConverter))]
 public enum CreativeWorkType
 {
  [EnumMember(Value = "Anime")]
  Anime,
  [EnumMember(Value = "OVA")]
  Ova,
  [EnumMember(Value = "Movie")]
  Movie,
  [EnumMember(Value = "Manga")]
  Manga,
  [EnumMember(Value = "Novel")]
  Novel
 }
}