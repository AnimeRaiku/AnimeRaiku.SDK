using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Test.Factory
{
    class CreativeWorkNameFactory : BaseFactory<CreativeWorkName>
    {
        public override CreativeWorkName Create()
        {
            return new CreativeWorkName()
            {
                Content = "test",
                Id = Id.NewId(),
                IsForced = true,
                IsVisible = false,
                Lang = Languages.ES,
                Type = NameTypes.Main
            };
        }
    }
}
