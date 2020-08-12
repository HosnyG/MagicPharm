using MagicPharm.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicPharm.Models.Context
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Carousels.Any())
            {
                context.Carousels.AddRange(
                    new Carousel
                    {
                        ImageUrl = "1.jpg",
                        Priority = 1
                    },
                    new Carousel
                    {
                        ImageUrl = "2.jpg",
                        Priority = 2
                    },
                    new Carousel
                    {
                        ImageUrl = "us3.jpg",
                        Priority = 3
                    }
                    );

            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "שעונים",
                        ImageUrl = "watches"
                    },
                    new Category
                    {
                        Name = "תיקים",
                        ImageUrl = "bags.jpg",
                        
                    },
                    new Category
                    {
                        Name = "בושם",
                        ImageUrl = "perfumes.jpg"
                    }
                    );
            }
            if (!context.Products.Any())
            {

                context.AddRange
                (
                    new Product
                    {
                        Name = "כחול MASERATI שעון",
                        Price = 1645M,
                        ShortDescription = "MASERATI R8871618007 שעון יד לגבר",
                        LongDescription = "שעון יד לגבר מבית המותג האיטלקי MASERATI. רצועת עור כחולה. גוף מוזהב, לוח כחול אלגנט. קוטר השעון 42 מילימטר. מנגנון יפני כרונוגרף. לשעון עיצוב מיוחד המתאים ליום יום ולאירועים.",
                        CategoryId = new Guid("f57bd38f-1c03-4fce-3dac-08d82e9910b0"),
                        ImageUrl = "maserati1.jpg",
                        InStock = false,
                        IsPreferred = true,
                    },
                    new Product
                    {
                        Name = "Calvin Klein שעון",
                        Price = 1200M,
                        ShortDescription = "שעון יד calvin Klein לגבר",
                        LongDescription = "שעון יד לגבר מבית המותג האיטלקי MASERATI. רצועת עור כחולה. גוף מוזהב, לוח כחול אלגנט. קוטר השעון 42 מילימטר. מנגנון יפני כרונוגרף. לשעון עיצוב מיוחד המתאים ליום יום ולאירועים.",
                        CategoryId = new Guid("f57bd38f-1c03-4fce-3dac-08d82e9910b0"),
                        ImageUrl = "calvin1.jpg",
                        InStock = false,
                        IsPreferred = true,
                    },
                    new Product
                    {
                        Name = "תיק Louis Vuitton",
                        Price = 2000M,
                        ShortDescription = "תיק יד לואי ויטון",
                        LongDescription = "אין",
                        CategoryId = new Guid("ca2161ba-87fc-4221-3dad-08d82e9910b0"),
                        ImageUrl = "louies1.jpg",
                        InStock = false,
                        IsPreferred = false,
                    },
                    new Product
                    {
                        Name = "תיק Gucci ורוד",
                        Price = 699M,
                        ShortDescription = "תיק צד גוצ'י ורוד בייבי",
                        LongDescription = ":)אין",
                        CategoryId = new Guid("ca2161ba-87fc-4221-3dad-08d82e9910b0"),
                        ImageUrl = "gucci1.jpg",
                        InStock = false,
                        IsPreferred = true,
                    },
                    new Product
                    {
                        Name = "Christian Dior Sauvage E.D.P",
                        Price = 699M,
                        ShortDescription = "דה פרפיום 100ml",
                        LongDescription = "בושם לגבר Christian Dior Sauvage מסוג או דה פרפיום E.D.P, תכולה 100ml יבואן מקביל",
                        CategoryId = new Guid("df3e83e7-11cc-405a-3dae-08d82e9910b0"),
                        ImageUrl = "sauvage.png",
                        InStock = false,
                        IsPreferred = false,
                    }
                );
            }

            context.SaveChanges();

        }
    }
}
