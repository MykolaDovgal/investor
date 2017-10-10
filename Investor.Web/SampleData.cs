using Investor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Investor.Entity;
using Microsoft.EntityFrameworkCore;

namespace Investor.Web
{
    public static class SampleData
    {
        public static void Initialize(NewsContext context)
        {
            if (!context.Articles.Any())
            {
                context.Articles.AddRange(
                    new Entity.ArticleEntity { Content = "<h1>Hello, everybody</h1>" },
                    new Entity.ArticleEntity { Content = "В РНБО України заявляють, що реальна кількість учасників навчань - до чверті мільйона військовослужбовців. У НАТО стурбовані активністю російських і білоруських військ і переконані, що навчання спрямовані на провокування країн-членів Альянсу." },
                    new Entity.ArticleEntity { Content = "<p>Крім України,  реальною загрозою війни ці навчання вважають у Литві та Польщі. Про це йдеться в сюжеті Сніданку з 1 + 1" },
                    new Entity.ArticleEntity { Content = "<p>Відповідно до міжнародних вимог, у таких масштабних навчаннях, без спостерігачів, можуть брати участь не більше 13 тисяч вояків. Якщо більше - міжнародне спостереження обов'язкове. </p>" },
                    new Entity.ArticleEntity { Content = "<p>ілвоипличдсшамрвап діовал</p>" },
                    new Entity.ArticleEntity { Content = "<p>esdrtfyukl</p>" },
                    new Entity.ArticleEntity { Content = "<p>xfjghmvghmvghmhgmghmghm</p>" },
                    new Entity.ArticleEntity { Content = "<p>fdxkbnlxdfjgblk xlkfjbxldfkj b</p>" },
                    new Entity.ArticleEntity { Content = "<p>sldkfjg dflkg ldkfj </p>" },
                    new Entity.ArticleEntity { Content = "<p>xfblkxfjblxdjf lxkf vb lzxjf vb</p>" },
                    new Entity.ArticleEntity { Content = "<p>xf cbmkxf gbkl xfclk </p>" },
                    new Entity.ArticleEntity { Content = "<p>fgcn kljxfhg fxlgb </p>" },
                    new Entity.ArticleEntity { Content = "<p>xfcgnxfgnxfgnc</p>" },
                    new Entity.ArticleEntity { Content = "<p>;dlkfjgvb діовал</p>" },
                    new Entity.ArticleEntity { Content = "<p> xdf;lk oisjdf psoidf [cfgvbo</p>" },
                    new Entity.ArticleEntity { Content = "<p>qwertyuidfghjk fghjkl</p>" },
                    new Entity.ArticleEntity { Content = "<p>ілвоипличдсшамрвап діовал</p>" },
                    new Entity.ArticleEntity { Content = "<p>іждвпрщдішвгапрдолвапиів дваш чдвопми дваоп</p>" }
                    );
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                Entity.CategoryEntity[] categories =
                {
                    new Entity.CategoryEntity {Name = "Політика", Url = "policy"},
                    //new Entity.CategoryEntity {Name = "Соціум", Url = "social"},
                    new Entity.CategoryEntity {Name = "Культура", Url = "culture"},
                    new Entity.CategoryEntity {Name = "Економіка", Url = "economy"},
                    new Entity.CategoryEntity {Name = "ІТ технології", Url = "it" },
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
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "img-slider.jpg"

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
                        Image = "img-slider.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Старший та молодший Буші прокоментували трагедію в Шарлоттсвіллі 2",
                        Article = context.Articles.ToList()[0],
                        Description = "Колишні президенти Джордж Буш-старший і Джордж Буш-молодший закликали США «відмовитися від расизму, антисемітизму",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = false,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "img-slider.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Старший та молодший Буші прокоментували трагедію в Шарлоттсвіллі 3",
                        Article = context.Articles.ToList()[0],
                        Description = "Колишні президенти Джордж Буш-старший і Джордж Буш-молодший закликали США «відмовитися від расизму, антисемітизму",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "img-slider.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Старший та молодший Буші прокоментували трагедію в Шарлоттсвіллі 4",
                        Article = context.Articles.ToList()[0],
                        Description = "Колишні президенти Джордж Буш-старший і Джордж Буш-молодший закликали США «відмовитися від расизму, антисемітизму",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "img-slider.jpg"

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
                        Image = "img-slider.jpg"

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
                        Image = "img-slider.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Перші «совєти» в Галичині: коли і хто такі ?",
                        Article = context.Articles.ToList()[2],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = false,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "img-slider.jpg"
                    },
                    new Entity.PostEntity
                    {
                        Title = "У «Борисполі» хочуть збудувати ще одну злітну смугу.",
                        Article = context.Articles.ToList()[2],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "img-slider.jpg"
                    },
                    new Entity.PostEntity
                    {
                        Title = "У «Борисполі» хочуть збудувати ще одну злітну смугу 2.",
                        Article = context.Articles.ToList()[2],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = false,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "img-slider.jpg"
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
                        Image = "img-slider.jpg"
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
                        Image = "img-slider.jpg"
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
                        Image = "news-politic-1.jpg"
                    },
                    new Entity.PostEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців 2",
                        Article = context.Articles.ToList()[2],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = false,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-1.jpg"
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
                        Image = "news-politic-1.jpg"

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
                        Image = "news-politic-1.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "LvivMozArt: Що відвідати і послухати 22 серпня",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-1.jpg"

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
                        Image = "news-politic-1.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Львів’ян запрошують на виставку моделей найбільш знакових будівель світу",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-1.jpg"

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
                        Image = "news-politic-2.jpg"

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
                        Image = "news-politic-2.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Чому у Львові виник скандал навколо фільму про батярів",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-2.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Чому у Львові виник скандал навколо фільму про батярів 2",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-2.jpg"

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
                        Image = "news-politic-2.jpg"

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
                        Image = "news-politic-2.jpg"

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
                        Image = "news-politic-2.jpg"

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
                        Image = "news-politic-2.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців 2",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-2.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців 2",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-2.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "На «Арені Львів» відбудеться фінал проекту «Українська пісня»: чого очікувати ?",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-2.jpg"

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
                        Image = "news-politic-2.jpg"

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
                        Image = "news-politic-2.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Як Львів відсвяткує День Незалежності: програма заходів",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = false,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-2.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Як Львів відсвяткує День Незалежності: програма заходів 2",
                        Article = context.Articles.ToList()[3],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = false,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-2.jpg"

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
                        Image = "news-politic-2.jpg"

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
                        Image = "news-politic-2.jpg"

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
                        Image = "news-politic-2.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Відомий львівський журналіст розповів, чому Садовому... 2",
                        Article = context.Articles.ToList()[4],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-2.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Petya.A-2: в Україні попереджають про можливу повторну кібератаку",
                        Article = context.Articles.ToList()[4],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-2.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Petya.A-2: в Україні попереджають про можливу повторну кібератаку 2",
                        Article = context.Articles.ToList()[4],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-2.jpg"

                    },
                    new Entity.PostEntity
                    {
                        Title = "Petya.A-2: в Україні попереджають про можливу повторну кібератаку",
                        Article = context.Articles.ToList()[4],
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        Image = "news-politic-2.jpg"

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
                        Post = context.Posts.ToList()[22],
                        IsOnSlider = true
                    },
                    new SliderItemEntity()
                    {
                        Post = context.Posts.ToList()[23],
                        IsOnSlider = true
                    },
                    new SliderItemEntity()
                    {
                        Post = context.Posts.ToList()[24],
                        IsOnSlider = true
                    },
                    new SliderItemEntity()
                    {
                        Post = context.Posts.ToList()[25],
                        IsOnSlider = true
                    },
                    new SliderItemEntity()
                    {
                        Post = context.Posts.ToList()[26],
                        IsOnSide = true
                    },
                    new SliderItemEntity()
                    {
                        Post = context.Posts.ToList()[27],
                        IsOnSide = true
                    },
                    new SliderItemEntity()
                    {
                        Post = context.Posts.ToList()[28],
                        IsOnSide = false
                    }

                    );
                context.SaveChanges();
            }
            if (!context.Tags.Any())
            {
                context.Tags.AddRange(
                    new TagEntity()
                    {
                        Name = "Ураган Ірма",
                        Url = "uragan_irrma"
                    },
                    new TagEntity()
                    {
                        Name = "Саакашвілі і Львів",
                        Url = "saakashvili_i_lviv"
                    },
                    new TagEntity()
                    {
                        Name = "Культурний вибух",
                        Url = "kulturnyi_vybukh"
                    },
                    new TagEntity()
                    {
                        Name = "Політична течія",
                        Url = "politychna_techiya"
                    },
                    new TagEntity()
                    {
                        Name = "теракт у центрі Києва",
                        Url = "teract_u_centri_Kyeva"
                    }
                    );
                context.SaveChanges();
            }
            if (context.Posts.ToList()[0].PostTags.Count == 0)
            {
                PostEntity post = context.Posts.ToList()[0];
                post.PostTags.AddRange(
               new List<PostTagEntity>
               {
                    new PostTagEntity()
                    {
                        PostId = context.Posts.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[0].TagId
                    },
                    new PostTagEntity()
                    {
                        PostId = context.Posts.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[1].TagId
                    },
                    new PostTagEntity()
                    {
                        PostId = context.Posts.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[2].TagId
                    },
                    new PostTagEntity()
                    {
                        PostId = context.Posts.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[3].TagId
                    }
               }
               
               );
                context.Posts.Update(post);

                context.SaveChanges();
            }
           
           
        }



        //if (!context.Posts.ToList()[0].PostTags.Any())
        //{
        //    context.Posts.ToList()[0].PostTags.AddRange(
        //        (IEnumerable<PostTagEntity>)(context.Tags)
        //        );
        //    context.SaveChanges();
        //}
    }
}

