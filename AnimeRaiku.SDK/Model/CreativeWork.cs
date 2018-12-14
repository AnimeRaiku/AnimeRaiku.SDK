using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeRaiku.SDK.Model
{
    public class CreativeWork : BaseModel
    {
        [JsonProperty(propertyName: "name")]
        public CreativeWorkName[] Name { get; set; }

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
        public DatePrecisions DateStartPrecision { get; set; }

        [JsonProperty(propertyName: "date_end")]
        public DateTime DateEnd { get; set; }

        [JsonProperty(propertyName: "date_end_precision")]
        public DatePrecisions DateEndPrecision { get; set; }

        [JsonProperty(propertyName: "status")]
        public Status Status { get; set; }

        [JsonProperty(propertyName: "rating")]
        public Ratings Rating { get; set; }

        [JsonProperty(propertyName: "number_episodes")]
        public int NumberOfEpisodes { get; set; }

        [JsonProperty(propertyName: "number_seasons")]
        public int NumberOfSeason { get; set; }

        [JsonProperty(propertyName: "is_visible")]
        public bool IsVisible { get; set; }

        [JsonProperty(propertyName: "genre")]
        public Genres[] Genre { get; set; }

        [JsonProperty(propertyName: "country")]
        public Countries Country { get; set; }

        [JsonProperty(propertyName: "audience")]
        public Demographics Audience { get; set; }

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

    public class CreativeWorkName : BaseModel
    {
        [JsonProperty(propertyName: "id")]
        public Id Id { get; set; }

        [JsonProperty(propertyName: "lang")]
        public Languages Lang { get; set; }

        [JsonProperty(propertyName: "type")]
        public NameTypes Type { get; set; }

        [JsonProperty(propertyName: "content")]
        public string Content { get; set; }

        [JsonProperty(propertyName: "is_visible")]
        public bool IsVisible { get; set; }

        [JsonProperty(propertyName: "is_forced")]
        public bool IsForced { get; set; }
    }

    public class Plot : BaseModel
    {
        [JsonProperty(propertyName: "id")]
        public Id Id { get; set; }

        [JsonProperty(propertyName: "lang")]
        public Languages Lang { get; set; }

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
        public Id Id { get; set; }

        [JsonProperty(propertyName: "relationship")]
        public string Relationship { get; set; }
    }

  
    public class Organization
    {

        [JsonProperty(propertyName: "_id")]
        public Id Id { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "slug")]
        public string Slug { get; set; }

        [JsonProperty(propertyName: "task")]
        public OrganizationTask Task { get; set; }
    }


}
