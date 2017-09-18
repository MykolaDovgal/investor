using Investor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Investor.Entity;

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
                    new Entity.ArticleEntity { Context = "В РНБО України заявляють, що реальна кількість учасників навчань - до чверті мільйона військовослужбовців. У НАТО стурбовані активністю російських і білоруських військ і переконані, що навчання спрямовані на провокування країн-членів Альянсу." },
                    new Entity.ArticleEntity { Context = "<p>Крім України,  реальною загрозою війни ці навчання вважають у Литві та Польщі. Про це йдеться в сюжеті Сніданку з 1 + 1" },
                    new Entity.ArticleEntity { Context = "<p>Відповідно до міжнародних вимог, у таких масштабних навчаннях, без спостерігачів, можуть брати участь не більше 13 тисяч вояків. Якщо більше - міжнародне спостереження обов'язкове. </p>" },
                    new Entity.ArticleEntity { Context = "<p>ілвоипличдсшамрвап діовал</p>" },
                    new Entity.ArticleEntity { Context = "<p>esdrtfyukl</p>" },
                    new Entity.ArticleEntity { Context = "<p>xfjghmvghmvghmhgmghmghm</p>" },
                    new Entity.ArticleEntity { Context = "<p>fdxkbnlxdfjgblk xlkfjbxldfkj b</p>" },
                    new Entity.ArticleEntity { Context = "<p>sldkfjg dflkg ldkfj </p>" },
                    new Entity.ArticleEntity { Context = "<p>xfblkxfjblxdjf lxkf vb lzxjf vb</p>" },
                    new Entity.ArticleEntity { Context = "<p>xf cbmkxf gbkl xfclk </p>" },
                    new Entity.ArticleEntity { Context = "<p>fgcn kljxfhg fxlgb </p>" },
                    new Entity.ArticleEntity { Context = "<p>xfcgnxfgnxfgnc</p>" },
                    new Entity.ArticleEntity { Context = "<p>;dlkfjgvb діовал</p>" },
                    new Entity.ArticleEntity { Context = "<p> xdf;lk oisjdf psoidf [cfgvbo</p>" },
                    new Entity.ArticleEntity { Context = "<p>qwertyuidfghjk fghjkl</p>" },
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
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[0],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "img-slider.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[0],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "img-slider.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[0],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "img-slider.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[1],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "img-slider.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[2],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "img-slider.jpg"
                    },
                    new Entity.PostEntity
                    {
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[2],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "img-slider.jpg"
                    },
                    new Entity.PostEntity
                    {
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[2],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-7.png"
                    },
                    new Entity.PostEntity
                    {
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[2],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-8.png"
                    },
                    new Entity.PostEntity
                    {
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[2],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-culture-1.png"
                    },
                    new Entity.PostEntity
                    {
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[3],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-culture-2.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[3],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-culture-3.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "У Малайзії понад 20 дітей згоріли заживо у школі",
                        Article = context.Articles.ToList()[3],
                        Description = "blgblglblglblglblg",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-culture-4.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців",
                        Article = context.Articles.ToList()[1],
                        Description = "gfhk;dlfkjh;dlfk",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-culture-5.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Пенсійна реформа України у питаннях і відповідях",
                        Article = context.Articles.ToList()[3],
                        Description = "gfhk;dlfkjh;dlfk",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-culture-6.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Пенсійна реформа України у питаннях і відповідях",
                        Article = context.Articles.ToList()[3],
                        Description = "gfhk;dlfkjh;dlfk",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-culture-7.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Пенсійна реформа України у питаннях і відповідях",
                        Article = context.Articles.ToList()[3],
                        Description = "gfhk;dlfkjh;dlfk",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-culture-8.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Пенсійна реформа України у питаннях і відповідях",
                        Article = context.Articles.ToList()[4],
                        Description = "gfhk;dlfkjh;dlfk",
                        Category = context.Categories.ToList()[4],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-economy-1.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Пенсійна реформа України у питаннях і відповідях",
                        Article = context.Articles.ToList()[4],
                        Description = "gfhk;dlfkjh;dlfk",
                        Category = context.Categories.ToList()[4],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-economy-2.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Пенсійна реформа України у питаннях і відповідях",
                        Article = context.Articles.ToList()[4],
                        Description = "gfhk;dlfkjh;dlfk",
                        Category = context.Categories.ToList()[4],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-economy-3.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Пенсійна реформа України у питаннях і відповідях",
                        Article = context.Articles.ToList()[4],
                        Description = "gfhk;dlfkjh;dlfk",
                        Category = context.Categories.ToList()[4],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Image = "news-img-economy-4.png"

                    }

                    );
                context.SaveChanges();
            }
                if (!context.SliderItems.Any())
                {
                    context.SliderItems.AddRange(
                        new SliderItemEntity()
                        {
                            Post = context.Posts.ToList()[0],
                            IsOnSlider = true
                        },
                        new SliderItemEntity()
                        {
                            Post = context.Posts.ToList()[1],
                            IsOnSlider = true
                        },
                        new SliderItemEntity()
                        {
                            Post = context.Posts.ToList()[2],
                            IsOnSlider = true
                        },
                        new SliderItemEntity()
                        {
                            Post = context.Posts.ToList()[3],
                            IsOnSlider = true
                        },
                        new SliderItemEntity()
                        {
                            Post = context.Posts.ToList()[4],
                            IsOnSlider = true
                        },
                        new SliderItemEntity()
                        {
                            Post = context.Posts.ToList()[5],
                            IsOnSide = true
                        },
                        new SliderItemEntity()
                        {
                            Post = context.Posts.ToList()[6],
                            IsOnSide = true
                        }

                        );
                context.SaveChanges();
            }
                
            

        }
    }
}
