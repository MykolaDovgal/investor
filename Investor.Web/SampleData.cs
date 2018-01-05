using Investor.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Investor.Entity;
using Investor.Model;
using Investor.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Investor.Web
{
    public static class SampleData
    {
        public static void Initialize(NewsContext context,
            SignInManager<UserEntity> signInManager,
            UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!context.Users.Any())
            {

                if (!roleManager.RoleExistsAsync("user").Result)
                {
                    var roleResult = roleManager.CreateAsync(new IdentityRole("user")).Result;
                }
                if (!roleManager.RoleExistsAsync("bloger").Result)
                {
                    var roleResult1 = roleManager.CreateAsync(new IdentityRole("bloger")).Result;
                }
                if (!roleManager.RoleExistsAsync("admin").Result)
                {
                    var roleResult2 = roleManager.CreateAsync(new IdentityRole("admin")).Result;
                }

                var user = new UserEntity
                {
                    Name = "user",
                    Description = "user",
                    Email = "user@gmail.com",
                    UserName = "user",
                    Surname = "user",
                    Photo = "7956B0990989F1BF94306E45F9221DF1.jpg",
                    SerializedCropPoints = "79;3;525;449"
                };
                var user1 = new UserEntity
                {
                    Name = "user1",
                    Description = "user1",
                    Email = "user1@gmail.com",
                    UserName = "user1",
                    Surname = "user1",
                    Photo = "42F302DB6CD89CE29F1C0D70B792E686.jpg",
                    SerializedCropPoints = "99;0;368;269"
                };
                var bloger1 = new UserEntity
                {
                    Name = "bloger",
                    Description = "bloger",
                    Email = "bloger1@gmail.com",
                    UserName = "bloger1",
                    Surname = "bloger",
                    Photo = "7956B0990989F1BF94306E45F9221DF1.jpg",
                    SerializedCropPoints = "79;3;525;449"
                };
                var bloger2 = new UserEntity
                {
                    Name = "Анна",
                    Description = "bloger",
                    Email = "bloger2@gmail.com",
                    UserName = "bloger2",
                    Surname = "Волицька",
                    Photo = "607FE0CDD44800E3C52E6E656F9D3EA0.jpg",
                    SerializedCropPoints = "87;2;458;373"
                };
                var bloger3 = new UserEntity
                {
                    Name = "Влад",
                    Description = "bloger",
                    Email = "bloger@gmail.com",
                    UserName = "bloger3",
                    Surname = "Ковальчук",
                    Photo = "6E78BCE7D7787B79645169B799A6C57E.jpg",
                    SerializedCropPoints = "226;0;1574;1347"
                };
                var bloger4 = new UserEntity
                {
                    Name = "Роман",
                    Description = "bloger",
                    Email = "bloger@gmail.com",
                    UserName = "bloger4",
                    Surname = "Захарків",
                    Photo = "50DF83C386548F47B731E0259F943E9F.jpg",
                    SerializedCropPoints = "92;0;498;406"
                };
                var bloger5 = new UserEntity
                {
                    Name = "Оксана",
                    Description = "bloger",
                    Email = "bloger@gmail.com",
                    UserName = "bloge5r",
                    Surname = "Зеленська",
                    SerializedCropPoints = "87;2;458;373",
                    Photo = "607FE0CDD44800E3C52E6E656F9D3EA0.jpg"
                };
                var bloger6 = new UserEntity
                {
                    Name = "Діана",
                    Description = "bloger",
                    Email = "bloger@gmail.com",
                    UserName = "bloger6",
                    Surname = "Яворська",
                    Photo = "50DF83C386548F47B731E0259F943E9F.jpg",
                    SerializedCropPoints = "92;0;498;406"
                };
                var admin = new UserEntity
                {
                    Name = "admin",
                    Description = "admin",
                    Email = "admin@gmail.com",
                    UserName = "admin",
                    Surname = "admin",
                    Photo = "6E78BCE7D7787B79645169B799A6C57E.jpg",
                    SerializedCropPoints = "226;0;1574;1347"
                };

                var userRegisterResult = userManager.CreateAsync(user, "user123123").Result;
                if (userRegisterResult.Succeeded)
                {
                    var x = userManager.AddToRoleAsync(user, "user").Result;
                }

                var userRegisterResult1 = userManager.CreateAsync(user1, "user1123123").Result;
                if (userRegisterResult1.Succeeded)
                {
                    var x1 = userManager.AddToRoleAsync(user1, "admin").Result;
                }

                var identityResult1 = userManager.CreateAsync(bloger1, "bloger123123").Result;
                if (identityResult1.Succeeded)
                {
                    var x2 = userManager.AddToRoleAsync(bloger1, "bloger").Result;
                }
                var identityResult2 = userManager.CreateAsync(bloger2, "bloger123123").Result;
                if (identityResult2.Succeeded)
                {
                    var x3 = userManager.AddToRoleAsync(bloger2, "bloger").Result;
                }

                var identityResult3 = userManager.CreateAsync(bloger3, "bloger123123").Result;
                if (identityResult3.Succeeded)
                {
                    var x4 = userManager.AddToRoleAsync(bloger3, "bloger").Result;
                }

                var identityResult4 = userManager.CreateAsync(bloger4, "bloger123123").Result;
                if (identityResult4.Succeeded)
                {
                    var x5 = userManager.AddToRoleAsync(bloger4, "admin").Result;
                }

                var identityResult5 = userManager.CreateAsync(bloger5, "bloger123123").Result;
                if (identityResult5.Succeeded)
                {
                    var x6 = userManager.AddToRoleAsync(bloger5, "bloger").Result;
                }
                var identityResult6 = userManager.CreateAsync(bloger6, "bloger123123").Result;
                if (identityResult6.Succeeded)
                {
                    var x7 = userManager.AddToRoleAsync(bloger6, "bloger").Result;
                }

                context.SaveChanges();
            }
            //if (!context.Articles.Any())
            //{
            //    context.Articles.AddRange(
            //        new Entity.ArticleEntity { Content = "<h1>Hello, everybody</h1>" },
            //        new Entity.ArticleEntity { Content = "В РНБО України заявляють, що реальна кількість учасників навчань - до чверті мільйона військовослужбовців. У НАТО стурбовані активністю російських і білоруських військ і переконані, що навчання спрямовані на провокування країн-членів Альянсу." },
            //        new Entity.ArticleEntity { Content = "<p>Крім України,  реальною загрозою війни ці навчання вважають у Литві та Польщі. Про це йдеться в сюжеті Сніданку з 1 + 1" },
            //        new Entity.ArticleEntity { Content = "<p>Відповідно до міжнародних вимог, у таких масштабних навчаннях, без спостерігачів, можуть брати участь не більше 13 тисяч вояків. Якщо більше - міжнародне спостереження обов'язкове. </p>" },
            //        new Entity.ArticleEntity { Content = "<p>ілвоипличдсшамрвап діовал</p>" },
            //        new Entity.ArticleEntity { Content = "<p>esdrtfyukl</p>" },
            //        new Entity.ArticleEntity { Content = "<p>xfjghmvghmvghmhgmghmghm</p>" },
            //        new Entity.ArticleEntity { Content = "<p>fdxkbnlxdfjgblk xlkfjbxldfkj b</p>" },
            //        new Entity.ArticleEntity { Content = "<p>sldkfjg dflkg ldkfj </p>" },
            //        new Entity.ArticleEntity { Content = "<p>xfblkxfjblxdjf lxkf vb lzxjf vb</p>" },
            //        new Entity.ArticleEntity { Content = "<p>xf cbmkxf gbkl xfclk </p>" },
            //        new Entity.ArticleEntity { Content = "<p>fgcn kljxfhg fxlgb </p>" },
            //        new Entity.ArticleEntity { Content = "<p>xfcgnxfgnxfgnc</p>" },
            //        new Entity.ArticleEntity { Content = "<p>;dlkfjgvb діовал</p>" },
            //        new Entity.ArticleEntity { Content = "<p> xdf;lk oisjdf psoidf [cfgvbo</p>" },
            //        new Entity.ArticleEntity { Content = "<p>qwertyuidfghjk fghjkl</p>" },
            //        new Entity.ArticleEntity { Content = "<p>ілвоипличдсшамрвап діовал</p>" },
            //        new Entity.ArticleEntity { Content = "<p>іждвпрщдішвгапрдолвапиів дваш чдвопми дваоп</p>" }
            //        );
            //    context.SaveChanges();
            //}
            if (!context.Categories.Any())
            {
                Entity.CategoryEntity[] categories =
                {
                    new Entity.CategoryEntity {Name = "Політика", Url = "policy"},
                    new Entity.CategoryEntity {Name = "Культура", Url = "culture"},
                    new Entity.CategoryEntity {Name = "Економіка", Url = "economy"},
                    new Entity.CategoryEntity {Name = "ІТ технології", Url = "it" },
                    new Entity.CategoryEntity {Name = "Соціум", Url = "socium"},
                    new Entity.CategoryEntity {Name = "Блог", Url = "blog"},
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
            if (!context.Blogs.Any())
            {
                var myUsers = context.Users.ToList<UserEntity>();
                context.Blogs.AddRange(
                    new Entity.BlogEntity
                    {
                        Title = "В The Economist вибачилися за фразу «громадянська війна на Донбасі»",
                        Article = "В РНБО України заявляють, що реальна кількість учасників навчань - до чверті мільйона військовослужбовців. У НАТО стурбовані активністю російських і білоруських військ і переконані, що навчання спрямовані на провокування країн-членів Альянсу.",
                        Description = "The Economist Intelligence Unit, дослідницька організація The Economist Group, вибачилася за фразу «громадянська війна”,",
                        Category = context.Categories.ToList()[5],
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg",
                        AuthorId = myUsers[0].Id
                    },
                    new Entity.BlogEntity
                    {
                        Title = "Старший та молодший Буші прокоментували трагедію в Шарлоттсвіллі",
                        Article = "<h1>Hello, everybody</h1>",
                        Description = "Колишні президенти Джордж Буш-старший і Джордж Буш-молодший закликали США «відмовитися від расизму, антисемітизму",
                        Category = context.Categories.ToList()[5],
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "577DCD471FA7D92D5B1850A5CB37F02C.jpg",
                        AuthorId = myUsers[1].Id

                    },
                    new Entity.BlogEntity
                    {
                        Title = "Старший та молодший Буші прокоментували трагедію в Шарлоттсвіллі 2",
                        Article = "<p>Крім України,  реальною загрозою війни ці навчання вважають у Литві та Польщі. Про це йдеться в сюжеті Сніданку з 1 + 1",
                        Description = "Колишні президенти Джордж Буш-старший і Джордж Буш-молодший закликали США «відмовитися від расизму, антисемітизму",
                        Category = context.Categories.ToList()[5],
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "577DCD471FA7D92D5B1850A5CB37F02C.jpg",
                        AuthorId = myUsers[2].Id
                    },
                    new Entity.BlogEntity
                    {
                        Title = "Старший та молодший Буші прокоментували трагедію в Шарлоттсвіллі 3",
                        Article = "<p>Відповідно до міжнародних вимог, у таких масштабних навчаннях, без спостерігачів, можуть брати участь не більше 13 тисяч вояків. Якщо більше - міжнародне спостереження обов'язкове. </p>",
                        Description = "Колишні президенти Джордж Буш-старший і Джордж Буш-молодший закликали США «відмовитися від расизму, антисемітизму",
                        Category = context.Categories.ToList()[5],
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,

                        Image = "577DCD471FA7D92D5B1850A5CB37F02C.jpg",
                        AuthorId = myUsers[0].Id

                    },
                    new Entity.BlogEntity
                    {
                        Title = "Старший та молодший Буші прокоментували трагедію в Шарлоттсвіллі 4",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Колишні президенти Джордж Буш-старший і Джордж Буш-молодший закликали США «відмовитися від расизму, антисемітизму",
                        Category = context.Categories.ToList()[5],
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg",
                        AuthorId = myUsers[3].Id
                    },
                    new Entity.BlogEntity
                    {
                        Title = "Чому Україна програла від «журналістського розслідування»",
                        Article = "<p>ілвоипличдсшамрвап діовал</p>",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[5],
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "5F18619AC74A43065C98941313647F07.jpg",
                        AuthorId = myUsers[2].Id
                    },
                     new Entity.BlogEntity
                     {
                         Title = "Фонд держмайна продав «Західерго» за ціною на 20 % вищою за стартову",
                         Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                         Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                         Category = context.Categories.ToList()[5],
                         CreatedOn = DateTime.Now,
                         ModifiedOn = DateTime.Now,
                         PublishedOn = DateTime.Now,
                         IsPublished = true,
                         Image = "8B434E6DF776872697D72E7BBA33CD9E.jpg",
                         AuthorId = myUsers[1].Id
                     },
                    new Entity.BlogEntity
                    {
                        Title = "Українських завод обслуговуватиме світових лідерів авіабудування",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[5],
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "8B434E6DF776872697D72E7BBA33CD9E.jpg",
                        AuthorId = myUsers[1].Id
                    },
                    new Entity.BlogEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців 2",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[5],
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "904E420568BDB9D329F914D562E091AE.jpg",
                        AuthorId = myUsers[1].Id
                    },
                    new Entity.BlogEntity
                    {
                        Title = "LvivMozArt: Що відвідати і послухати 22 серпня",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[5],
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "904E420568BDB9D329F914D562E091AE.jpg",
                        AuthorId = myUsers[1].Id
                    }
                    );
            }
            if (!context.News.Any())
            {
                var myUsers = context.Users.ToList<UserEntity>();
                context.News.AddRange(

                    new Entity.NewsEntity
                    {
                        Title = "Вижити тут можуть хіба ті, хто тут народився, – українка про життя у Конго(фото)",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Перші «совєти» в Галичині: коли і хто такі ?",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = false,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "5F18619AC74A43065C98941313647F07.jpg"
                    },
                    new Entity.NewsEntity
                    {
                        Title = "У «Борисполі» хочуть збудувати ще одну злітну смугу.",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"
                    },
                    new Entity.NewsEntity
                    {
                        Title = "У «Борисполі» хочуть збудувати ще одну злітну смугу 2.",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[0],
                        IsOnMainPage = false,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "8B434E6DF776872697D72E7BBA33CD9E.jpg"
                    },
                    new Entity.NewsEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"
                    },
                    new Entity.NewsEntity
                    {
                        Title = "На вихідних у Львівській опері стартує новий театральний сезон",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "904E420568BDB9D329F914D562E091AE.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "На вихідних у Львівській опері стартує новий театральний сезон",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "LvivMozArt: Що відвідати і послухати 22 серпня",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "904E420568BDB9D329F914D562E091AE.jpg"

                    },

                    new Entity.NewsEntity
                    {
                        Title = "Львів’ян запрошують на виставку моделей найбільш знакових будівель світу",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "96EFCF1E052A4431ACA79958DA503DC1.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Як Львів відсвяткує День Незалежності: програма заходів",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Новий роман частково буде про пошук ідентичності, – Вікторія Амеліна",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "96EFCF1E052A4431ACA79958DA503DC1.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Чому у Львові виник скандал навколо фільму про батярів",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "96EFCF1E052A4431ACA79958DA503DC1.jpg"
                    },
                    new Entity.NewsEntity
                    {
                        Title = "Чому у Львові виник скандал навколо фільму про батярів 2",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "На «Арені Львів» відбудеться фінал проекту «Українська пісня»: чого очікувати ?",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[1],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "A32DD87FC9ACE674FB62A13564A28C0C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "A32DD87FC9ACE674FB62A13564A28C0C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців 2",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "A32DD87FC9ACE674FB62A13564A28C0C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Поетичні новинки: що презентують на 24 Форумі видавців 2",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "A32DD87FC9ACE674FB62A13564A28C0C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "На «Арені Львів» відбудеться фінал проекту «Українська пісня»: чого очікувати ?",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Чому у Львові виник скандал навколо фільму про батярів",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "B0CFF4CF27F0BAC7EC145AFE29E29C5A.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Як Львів відсвяткує День Незалежності: програма заходів",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "B0CFF4CF27F0BAC7EC145AFE29E29C5A.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Як Львів відсвяткує День Незалежності: програма заходів",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = false,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Як Львів відсвяткує День Незалежності: програма заходів 2",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[2],
                        IsOnMainPage = false,
                        IsImportant = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "B0CFF4CF27F0BAC7EC145AFE29E29C5A.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "В Україні почалась нова хакерська атака",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Google випустив нову Android — Oreo",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "У новій операційній системі з’явилася можливість працювати в режимі «картинка в картинці». Наприклад, можна продовжувати...",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        IsOnSide = false,
                        IsOnSlider = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "BEB774B63B3FC1C93265D738A0A9C295.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Відомий львівський журналіст розповів, чому Садовому...",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        IsOnSide = false,
                        IsOnSlider = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "BEB774B63B3FC1C93265D738A0A9C295.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Відомий львівський журналіст розповів, чому Садовому... 2",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = false,
                        IsOnSide = true,
                        IsOnSlider = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "BEB774B63B3FC1C93265D738A0A9C295.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Petya.A-2: в Україні попереджають про можливу повторну кібератаку",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        IsImportant = true,
                        IsOnSide = false,
                        IsOnSlider = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "BEB774B63B3FC1C93265D738A0A9C295.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Petya.A-2: в Україні попереджають про можливу повторну кібератаку 2",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = false,
                        IsOnSide = false,
                        IsOnSlider = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "BEB774B63B3FC1C93265D738A0A9C295.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Petya.A-2: в Україні попереджають про можливу повторну кібератаку",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[3],
                        IsOnMainPage = true,
                        IsImportant = true,
                        IsOnSide = false,
                        IsOnSlider = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"

                    },
                    new Entity.NewsEntity
                    {
                        Title = "Актори \"гри престолів\" розповіли про \"божевільне\" засекречення фіналу серіалу",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[4],
                        IsOnMainPage = true,
                        IsImportant = false,
                        IsOnSide = false,
                        IsOnSlider = true,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "577DCD471FA7D92D5B1850A5CB37F02C.jpg"
                    },
                    new Entity.NewsEntity
                    {
                        Title = "У Москві шукають аноніма, який за один вечір повідомив про 20 замінувань",
                        Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                        Category = context.Categories.ToList()[4],
                        IsOnMainPage = true,
                        IsImportant = false,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        PublishedOn = DateTime.Now,
                        IsPublished = true,
                        Image = "2F43526F98C22E1E649666A572C7661C.jpg"
                    },
                     new Entity.NewsEntity
                     {
                         Title = "У Харкові Lexus влетів у натовп людей: Геращенко розповів, хто був за кермом",
                         Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                         Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                         Category = context.Categories.ToList()[4],
                         IsOnMainPage = true,
                         IsImportant = true,
                         IsOnSide = false,
                         IsOnSlider = true,
                         CreatedOn = DateTime.Now,
                         ModifiedOn = DateTime.Now,
                         PublishedOn = DateTime.Now,
                         IsPublished = true,
                         Image = "577DCD471FA7D92D5B1850A5CB37F02C.jpg"
                     },
                     new Entity.NewsEntity
                     {
                         Title = "У США придумали намет, який плаває",
                         Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                         Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                         Category = context.Categories.ToList()[4],
                         IsOnMainPage = true,
                         IsImportant = false,
                         CreatedOn = DateTime.Now,
                         ModifiedOn = DateTime.Now,
                         PublishedOn = DateTime.Now,
                         IsPublished = true,
                         Image = "2F43526F98C22E1E649666A572C7661C.jpg"
                     },
                     new Entity.NewsEntity
                     {
                         Title = "Жінка бореться проти \"ідеального світу\" в Instagram дотепними фото з подорожей",
                         Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                         Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                         Category = context.Categories.ToList()[4],
                         IsOnMainPage = true,
                         IsImportant = false,
                         CreatedOn = DateTime.Now,
                         ModifiedOn = DateTime.Now,
                         PublishedOn = DateTime.Now,
                         IsPublished = true,
                         Image = "5F18619AC74A43065C98941313647F07.jpg"
                     },
                     new Entity.NewsEntity
                     {
                         Title = "Дизайнер створює крихітні світи за допомогою звичайних речей",
                         Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                         Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                         Category = context.Categories.ToList()[4],
                         IsOnMainPage = true,
                         IsImportant = false,
                         IsOnSide = false,
                         IsOnSlider = false,
                         CreatedOn = DateTime.Now,
                         ModifiedOn = DateTime.Now,
                         PublishedOn = DateTime.Now,
                         IsPublished = true,
                         Image = "2F43526F98C22E1E649666A572C7661C.jpg"
                     },
                      new Entity.NewsEntity
                      {
                          Title = "Бред Пітт закрутив роман із 21-річною актрисою",
                          Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                          Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                          Category = context.Categories.ToList()[4],
                          IsOnMainPage = true,
                          IsImportant = false,
                          IsOnSide = true,
                          IsOnSlider = true,
                          CreatedOn = DateTime.Now,
                          ModifiedOn = DateTime.Now,
                          PublishedOn = DateTime.Now,
                          IsPublished = true,
                          Image = "5F18619AC74A43065C98941313647F07.jpg"
                      },
                       new Entity.NewsEntity
                       {
                           Title = "Професор пояснив, чому не варто поступатися старшим місцем у транспорті",
                           Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                           Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                           Category = context.Categories.ToList()[4],
                           IsOnMainPage = true,
                           IsImportant = false,
                           IsOnSide = true,
                           IsOnSlider = false,
                           CreatedOn = DateTime.Now,
                           ModifiedOn = DateTime.Now,
                           PublishedOn = DateTime.Now,
                           IsPublished = true,
                           Image = "2F43526F98C22E1E649666A572C7661C.jpg"
                       },
                       new Entity.NewsEntity
                       {
                           Title = "Три погані звички, через які ви виглядаєте старше",
                           Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                           Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                           Category = context.Categories.ToList()[4],
                           IsOnMainPage = true,
                           IsImportant = false,
                           IsOnSide = false,
                           IsOnSlider = false,
                           CreatedOn = DateTime.Now,
                           ModifiedOn = DateTime.Now,
                           PublishedOn = DateTime.Now,
                           IsPublished = true,
                           Image = "8B434E6DF776872697D72E7BBA33CD9E.jpg"
                       },
                       new Entity.NewsEntity
                       {
                           Title = "Чому українська медицина не завжди може допомогти психічно хворим людям",
                           Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                           Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus aliquam sit amet massa sit amet consequat. Mauris metus magna, aliquam quis tellus non, ullamcorper porttitor est. Ut eu pellentesque sem. ",
                           Category = context.Categories.ToList()[4],
                           IsOnMainPage = true,
                           IsImportant = false,
                           IsOnSide = false,
                           IsOnSlider = true,
                           CreatedOn = DateTime.Now,
                           ModifiedOn = DateTime.Now,
                           PublishedOn = DateTime.Now,
                           IsPublished = true,
                           Image = "2F43526F98C22E1E649666A572C7661C.jpg"
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
            if (context.News.ToList()[0].PostTags.Count == 0)
            {
                NewsEntity post = context.News.ToList()[0];
                post.PostTags.AddRange(
               new List<PostTagEntity>
               {
                    new PostTagEntity()
                    {
                        PostId = context.News.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[0].TagId
                    },
                    new PostTagEntity()
                    {
                        PostId = context.News.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[1].TagId
                    },
                    new PostTagEntity()
                    {
                        PostId = context.News.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[2].TagId
                    },
                    new PostTagEntity()
                    {
                        PostId = context.News.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[3].TagId
                    }
               }

               );
                context.News.Update(post);
                context.SaveChanges();
            }
            if (context.Blogs.ToList()[0].PostTags.Count == 0)
            {
                BlogEntity post = context.Blogs.ToList()[0];
                post.PostTags.AddRange(
               new List<PostTagEntity>
               {
                    new PostTagEntity()
                    {
                        PostId = context.Blogs.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[0].TagId
                    },
                    new PostTagEntity()
                    {
                        PostId = context.Blogs.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[1].TagId
                    },
                    new PostTagEntity()
                    {
                        PostId = context.Blogs.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[2].TagId
                    },
                    new PostTagEntity()
                    {
                        PostId = context.Blogs.ToList()[0].PostId,
                        TagId = context.Tags.ToList()[3].TagId
                    }
               }

               );
                context.Blogs.Update(post);
                context.SaveChanges();
            }

        }
    }
}

