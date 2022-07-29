using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CommerceContextSeed
    {
        public static async Task SeedAsync(CommerceContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                await SeedBrandsIfEmptyAsync(context);
                await SeedProductTypesIfEmptyAsync(context);
                await SeedProductsIfEmptyAsync(context);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<CommerceContextSeed>();
                logger.LogError(ex.Message);
            }
        }

        private static async Task SeedBrandsIfEmptyAsync(CommerceContext context)
        {
            if (!context.ProductBrands.Any())
            {
                string brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                List<ProductBrand> brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                foreach (var brand in brands)
                {
                    context.ProductBrands.Add(brand);
                    await context.SaveChangesAsync();
                }
            }
        }
        private static async Task SeedProductTypesIfEmptyAsync(CommerceContext context)
        {
            if (!context.ProductTypes.Any())
            {
                string productTypesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                List<ProductType> types = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);
                foreach (var type in types)
                {
                    context.ProductTypes.Add(type);
                    await context.SaveChangesAsync();
                }
            }
        }
        private static async Task SeedProductsIfEmptyAsync(CommerceContext context)
        {
            if (!context.Products.Any())
            {
                string productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                List<Product> products = JsonSerializer.Deserialize<List<Product>>(productsData);
                foreach (var product in products)
                {
                    context.Products.Add(product);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
