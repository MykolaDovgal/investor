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
                        Title = "В The Economist вибачилися за фразу «громадянська війна на Донбасі»",
                        Article = context.Articles.ToList()[0],
                        Description = "The Economist Intelligence Unit, дослідницька організація The Economist Group, вибачилася за фразу «громадянська війна”,",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-1.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Старший та молодший Буші прокоментували трагедію в Шарлоттсвіллі",
                        Article = context.Articles.ToList()[0],
                        Description = "Колишні президенти Джордж Буш-старший і Джордж Буш-молодший закликали США «відмовитися від расизму, антисемітизму",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-2.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Чому Україна програла від «журналістського розслідування»",
                        Article = context.Articles.ToList()[0],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-3.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Вижити тут можуть хіба ті, хто тут народився, – українка про життя у Конго(фото)",
                        Article = context.Articles.ToList()[1],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-4.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Перші «совєти» в Галичині: коли і хто такі ?",
                        Article = context.Articles.ToList()[2],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-5.png"
                    },
                    new Entity.PostEntity
                    {
                        Title = "У «Борисполі» хочуть збудувати ще одну злітну смугу.",
                        Article = context.Articles.ToList()[2],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-6.png"
                    },
                    new Entity.PostEntity
                    {
                        Title = "Фонд держмайна продав «Західерго» за ціною на 20 % вищою за стартову",
                        Article = context.Articles.ToList()[2],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-7.png"
                    },
                    new Entity.PostEntity
                    {
                        Title = "Українських завод обслуговуватиме світових лідерів авіабудування",
                        Article = context.Articles.ToList()[2],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-8.png"
                    },
                    new Entity.PostEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців",
                        Article = context.Articles.ToList()[2],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-culture-1.png"
                    },
                    new Entity.PostEntity
                    {
                        Title = "На вихідних у Львівській опері стартує новий театральний сезон",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-culture-2.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "LvivMozArt: Що відвідати і послухати 22 серпня",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-culture-3.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Львів’ян запрошують на виставку моделей найбільш знакових будівель світу",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-culture-4.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Як Львів відсвяткує День Незалежності: програма заходів",
                        Article = context.Articles.ToList()[1],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-culture-5.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Новий роман частково буде про пошук ідентичності, – Вікторія Амеліна",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-culture-6.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Чому у Львові виник скандал навколо фільму про батярів",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-culture-7.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "На «Арені Львів» відбудеться фінал проекту «Українська пісня»: чого очікувати ?",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-culture-8.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-economy-8.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "На «Арені Львів» відбудеться фінал проекту «Українська пісня»: чого очікувати ?",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-economy-2.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Чому у Львові виник скандал навколо фільму про батярів",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-economy-3.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Як Львів відсвяткує День Незалежності: програма заходів",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-economy-4.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "В Україні почалась нова хакерська атака",
                        Article = context.Articles.ToList()[4],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-it-2.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Google випустив нову Android — Oreo",
                        Article = context.Articles.ToList()[4],
                        Description = "У новій операційній системі з’явилася можливість працювати в режимі «картинка в картинці». Наприклад, можна продовжувати...",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-it-1.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Відомий львівський журналіст розповів, чому Садовому...",
                        Article = context.Articles.ToList()[4],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-it-3.png"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Petya.A-2: в Україні попереджають про можливу повторну кібератаку",
                        Article = context.Articles.ToList()[4],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-img-it-4.png"

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
