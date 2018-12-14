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
                Type = "Anime",
                Slug = "test",
                Name = new CreativeWorkName[]{
                     new CreativeWorkName()
                     {
                        Id = Id.NewId(),
                        Content = "Test",
                        Lang = Languages.ES,
                        IsForced = true,
                        IsVisible = true,
                        Type = NameTypes.Main
                     }
                },
                Plot = new Plot[]{
                    new Plot()
                    {
                        Id = Id.NewId(),
                        Lang = Languages.ES,
                        Content = "Good Plot",
                        Source = null,
                        IsVisible = true
                    }
                },
                Audience = Demographics.Shonen,
                Country = Countries.ES,
                DateStart = DateTime.Now,
                DateStartPrecision = DatePrecisions.Hour,
                DateEnd = DateTime.Now,
                DateEndPrecision = DatePrecisions.Hour,
                Genre = new Genres[] { Genres.Action, Genres.Adventure },
                IsVisible = true,
                NumberOfEpisodes = 1,
                NumberOfSeason = 1,
                Organization = new Organization[]{
                    new Organization()
                    {
                         Id = Id.NewId(),
                         Task = OrganizationTask.AnimationProduction,
                         Name = "Test corp",
                         Slug = "test-corp"
                    }
                },
                Rating = Ratings.None,
                Related = new Related[]{

                },
                Status = Status.Ended,
            };
        }
    }
}
