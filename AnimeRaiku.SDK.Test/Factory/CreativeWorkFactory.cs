using AnimeRaiku.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRaiku.SDK.Test.Factory
{
    public class CreativeWorkFactory : BaseFactory<CreativeWork>
    {
        public override CreativeWork Create()
        {
            return new CreativeWork()
            {
                Type = "",
                Slug = "",
                Name = new Name[]{
                     new Name()
                     {
                          Id = Id.NewId(),
                           Content = "",
                            Lang = "ES",
                             IsForced = true,
                                IsVisible = true,
                                 Type = ""
                     }
                },
                Plot = new Plot[]{
                    new Plot()
                    {
                         Id = Id.NewId(),
                         Lang = "",
                          Content = "",
                           Source = "",
                           IsVisible = true
                    }
                },
                Audience = "",
                Country = "",
                DateStart = DateTime.Now,
                DateStartPrecision = "",
                DateEnd = DateTime.Now,
                DateEndPrecision = "",
                Genre = new String[] { "" },
                IsVisible = true,
                NumberOfEpisodes = 1,
                NumberOfSeason = 1,
                Organization = new Organization[]{

                },
                Rating = "",
                Related = new Related[]{

                },
                Status = "",
            };
        }
    }
}
