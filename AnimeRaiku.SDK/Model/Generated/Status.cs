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
 public enum Status
 {
  [EnumMember(Value = "UNKNOWN")]
  Unknown,
  [EnumMember(Value = "PENDING")]
  Pending,
  [EnumMember(Value = "AIRING")]
  Airing,
  [EnumMember(Value = "ON BREAK")]
  OnBreak,
  [EnumMember(Value = "CANCELLED")]
  Cancelled,
  [EnumMember(Value = "ENDED")]
  Ended
 }
}