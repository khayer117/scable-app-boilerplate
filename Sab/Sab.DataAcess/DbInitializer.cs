using Microsoft.EntityFrameworkCore;
using Sab.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sab.DataAcess
{
    public static class DbInitializer
    {
        public static void Initialize(SabDataContext dataContext)
        {
            dataContext.Database.EnsureCreated();

            if (dataContext.Categories.Any())
            {
                return;
            }

            dataContext.ExecuteWithIdentityInsertRemoval<Category>(ctx =>
            {
                var categories = new Category[]
                {
                new Category(){CategoryId=1, Title = "Home Appliance"},
                new Category(){CategoryId=2, Title = "Baby Care"},
                };

                foreach (var category in categories)
                {
                    ctx.Add(category);
                }
            });

            dataContext.ExecuteWithIdentityInsertRemoval<SubCategory>(ctx =>
            {
                var subCategories = new SubCategory[]
                {
                new SubCategory{SubCategoryId = 1, Title = "TV", CategoryId = 1},
                new SubCategory{SubCategoryId = 2, Title = "Micro-Oven", CategoryId = 1},
                new SubCategory{SubCategoryId = 3, Title = "Refrigerator", CategoryId = 1},
                new SubCategory{SubCategoryId = 4, Title = "Daiper", CategoryId = 2},
                new SubCategory{SubCategoryId = 5, Title = "Wipe", CategoryId = 2}
                };

                foreach (var subCategory in subCategories)
                {
                    ctx.Add(subCategory);
                }
            });

            dataContext.ExecuteWithIdentityInsertRemoval<Brand>(ctx =>
            {
                var brands = new Brand[]
                {
                    new Brand{BrandId = 1, Title = "Sony"},
                    new Brand{BrandId = 2, Title = "Samsung"},
                    new Brand{BrandId = 3, Title = "LG"},
                    new Brand{BrandId = 4, Title = "CHUCHU"},
                    new Brand{BrandId = 5, Title = "Huggies"},
                };

                foreach (var brand in brands)
                {
                    ctx.Add(brand);
                }

            });

        }

    }
}
