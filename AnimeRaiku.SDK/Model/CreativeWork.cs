using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model
{
    public class CreativeWork : LookupModel
    {
        [JsonProperty(propertyName: "name")]
        public Name[] Name { get; set; }

        [JsonProperty(propertyName: "name_main")]
        public string NameMain { get; set; }

        [JsonProperty(propertyName: "name_yomi")]
        public string NameYomi { get; set; }

        [JsonProperty(propertyName: "plot")]
        public Plot[] Plot { get; set; }

        [JsonProperty(propertyName: "plot_main")]
        public string PlotMain { get; set; }

        [JsonProperty(propertyName: "slug")]
        public string Slug { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }


        [JsonProperty(propertyName: "images")]
        public Images Images { get; set; }

        [JsonProperty(propertyName: "date_start")]
        public DateTime DateStart { get; set; }

        [JsonProperty(propertyName: "date_start_precision")]
        public string DateStartPrecision { get; set; }

        [JsonProperty(propertyName: "date_end")]
        public DateTime DateEnd { get; set; }

        [JsonProperty(propertyName: "date_end_precision")]
        public string DateEndPrecision { get; set; }

        [JsonProperty(propertyName: "status")]
        public string Status { get; set; }

        [JsonProperty(propertyName: "rating")]
        public string Rating { get; set; }

        [JsonProperty(propertyName: "numberOfEpisodes")]
        public int NumberOfEpisodes { get; set; }

        [JsonProperty(propertyName: "is_visible")]
        public bool IsVisible { get; set; }

        [JsonProperty(propertyName: "genre")]
        public string[] Genre { get; set; }

        [JsonProperty(propertyName: "country")]
        public string Country { get; set; }

        [JsonProperty(propertyName: "audience")]
        public string Audience { get; set; }

        [JsonProperty(propertyName: "related")]
        public Related[] Related { get; set; }

        [JsonProperty(propertyName: "organization")]
        public Organization[] Organization { get; set; }
    }


    public class Images
    {
        [JsonProperty(propertyName: "cover")]
        public Cover Cover { get; set; }

        [JsonProperty(propertyName: "background")]
        public Background Background { get; set; }
    }

    public class Cover
    {
        [JsonProperty(propertyName: "small")]
        public string Small { get; set; }

        [JsonProperty(propertyName: "medium")]
        public string Medium { get; set; }

        [JsonProperty(propertyName: "big")]
        public string Big { get; set; }

        [JsonProperty(propertyName: "colors")]
        public Color Colors { get; set; }
    }

    public class Color
    {
        [JsonProperty(propertyName: "vibrant")]
        public string Vibrant { get; set; }

        [JsonProperty(propertyName: "light_vibrant")]
        public string LightVibrant { get; set; }

        [JsonProperty(propertyName: "dark_vibrant")]
        public string DarkVibrant { get; set; }

        [JsonProperty(propertyName: "muted")]
        public string Muted { get; set; }

        [JsonProperty(propertyName: "light_muted")]
        public string LightMuted { get; set; }

        [JsonProperty(propertyName: "dark_muted")]
        public string DarkMuted { get; set; }
    }

    public class Background
    {
        [JsonProperty(propertyName: "small")]
        public object Small { get; set; }

        [JsonProperty(propertyName: "big")]
        public object Big { get; set; }
    }

    public class Name
    {
        [JsonProperty(propertyName: "lang")]
        public string Lang { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "content")]
        public string Content { get; set; }

        [JsonProperty(propertyName: "is_visible")]
        public bool IsVisible { get; set; }

        [JsonProperty(propertyName: "is_forced")]
        public bool IsForced { get; set; }
    }

    public class Plot
    {
        [JsonProperty(propertyName: "lang")]
        public string Lang { get; set; }

        [JsonProperty(propertyName: "is_visible")]
        public bool IsVisible { get; set; }

        [JsonProperty(propertyName: "content")]
        public string Content { get; set; }

        [JsonProperty(propertyName: "source")]
        public object Source { get; set; }
    }

    public class Related
    {
        [JsonProperty(propertyName: "_id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "relationship")]
        public string Relationship { get; set; }

        [JsonProperty(propertyName: "links")]
        public Link[] Links { get; set; }
    }

    public class Link
    {

        [JsonProperty(propertyName: "rel")]
        public string Rel { get; set; }

        [JsonProperty(propertyName: "uri")]
        public string Uri { get; set; }
    }

    public class Organization
    {

        [JsonProperty(propertyName: "_id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "slug")]
        public string Slug { get; set; }

        [JsonProperty(propertyName: "task")]
        public string Task { get; set; }
    }


}
