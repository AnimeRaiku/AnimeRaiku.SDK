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
 public enum Folders
 {
  [EnumMember(Value = "PLAN-TO-WATCH")]
  PlanToWatch,
  [EnumMember(Value = "WATCHING")]
  Watching,
  [EnumMember(Value = "COMPLETED")]
  Completed,
  [EnumMember(Value = "DROPPED")]
  Dropped,
  [EnumMember(Value = "ON-HOLD")]
  OnHold,
  [EnumMember(Value = "MAYBE")]
  Maybe
 }
}