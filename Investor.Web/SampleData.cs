using Investor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Investor.Web
{
    public static class SampleData
    {
        public static void Initialize(NewsContext context)
        {
            if (!context.Articles.Any())
            {
                context.Articles.AddRange(
                    new Entity.ArticleEntity { Context = "<h1>Hello, everybody</h1>" },
                    new Entity.ArticleEntity { Context = "<a>likelikelike</a>" },
                    new Entity.ArticleEntity { Context = "<p>sawsawsawsasa</p>" },
                    new Entity.ArticleEntity { Context = "<p>вдлопжваптдвлопидваолп віапиівапвап</p>" },
                    new Entity.ArticleEntity { Context = "<p>ілвоипличдсшамрвап діовал</p>" },
                    new Entity.ArticleEntity { Context = "<p>іждвпрщдішвгапрдолвапиів дваш чдвопми дваоп</p>" }
                    );
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                Entity.CategoryEntity[] categories =
                {
                    new Entity.CategoryEntity {Name = "Політика"},
                    new Entity.CategoryEntity {Name = "Соціум"},
                    new Entity.CategoryEntity {Name = "Культура"},
                    new Entity.CategoryEntity {Name = "Економіка"},
                    new Entity.CategoryEntity {Name = "ІТ технології"},
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
           
            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Entity.PostEntity
                    {
                        Title = "В The Economist вибачилися за фразу «громадянська війна на Донбасі»",
                        Article = context.Articles.ToList()[0],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now

                    },
                    new Entity.PostEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців",
                        Article = context.Articles.ToList()[1],
                        Description = "gfhk;dlfkjh;dlfk",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now

                    },
                    new Entity.PostEntity
                    {
                        Title = "Пенсійна реформа України у питаннях і відповідях",
                        Article = context.Articles.ToList()[3],
                        Description = "gfhk;dlfkjh;dlfk",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now

                    }
                    );
                context.SaveChanges();
            }

        }
    }
}
