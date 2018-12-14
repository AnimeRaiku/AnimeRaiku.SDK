using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Test.Factory
{
    public class CreativeWorkPlotFactory : BaseFactory<Plot>
    {
        public override Plot Create()
        {
            return new Plot()
            {
                Content = "Good plot",
                Id = Id.NewId(),
                IsVisible = true,
                Lang = Languages.ES,
                Source = null
            };
        }
    }
}
