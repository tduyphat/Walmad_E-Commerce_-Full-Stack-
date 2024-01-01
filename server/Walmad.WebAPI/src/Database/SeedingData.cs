using Walmad.Business.src.Shared;
using Walmad.Core.src.Entity;

namespace Walmad.WebAPI.src.Database;

public class SeedingData
{
    private static Random random = new Random();

    private static int GetRandomNumber()
    {
        return random.Next(1, 11);
    }

    private static int GetRandomNumberForImage()
    {
        return random.Next(100, 1000);
    }

    private static int RandomNumber1 = GetRandomNumber();
    private static int RandomNumber2 = GetRandomNumber();
    private static int RandomNumber3 = GetRandomNumber();
    private static int RandomNumber4 = GetRandomNumber();
    private static int RandomNumber5 = GetRandomNumber();
    private static int RandomNumber6 = GetRandomNumber();

    private static Category category1 = new Category { Id = Guid.NewGuid(), Image = $"https://picsum.photos/200/?random={RandomNumber1}", Name = "Electronic", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };
    private static Category category2 = new Category { Id = Guid.NewGuid(), Image = $"https://picsum.photos/200/?random={RandomNumber2}", Name = "Clothing", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };
    private static Category category3 = new Category { Id = Guid.NewGuid(), Image = $"https://picsum.photos/200/?random={RandomNumber3}", Name = "Home Decor", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };
    private static Category category4 = new Category { Id = Guid.NewGuid(), Image = $"https://picsum.photos/200/?random={RandomNumber4}", Name = "Books", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };
    private static Category category5 = new Category { Id = Guid.NewGuid(), Image = $"https://picsum.photos/200/?random={RandomNumber5}", Name = "Sports", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };
    private static Category category6 = new Category { Id = Guid.NewGuid(), Image = $"https://picsum.photos/200/?random={RandomNumber6}", Name = "Toys", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow };

    public static List<Category> GetCategories()
    {
        return new List<Category>
        {
            category1, category2, category3, category4, category5, category6
        };
    }

    private static List<Product> GenerateProductsForCategory(Category category, int count)
    {
        var products = new List<Product>();
        // var productImages = new List<ProductImage>();

        for (int i = 1; i <= count; i++)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Inventory = 100,
                Title = $"{category.Name} Product {i}",
                Price = (decimal)(i * 10),
                Description = $"Description for {category.Name} Product {i}",
                CategoryId = category.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            products.Add(product);
        }

        return products;
    }

    public static List<Product> GetProducts()
    {
        var products = new List<Product>();
        products.AddRange(GenerateProductsForCategory(category1, 20));
        products.AddRange(GenerateProductsForCategory(category2, 20));
        products.AddRange(GenerateProductsForCategory(category3, 20));
        products.AddRange(GenerateProductsForCategory(category4, 20));
        products.AddRange(GenerateProductsForCategory(category5, 20));
        products.AddRange(GenerateProductsForCategory(category6, 20));

        return products;
    }

    public static List<Product> Products = GetProducts();

    public static List<ProductImage> GetProductImages()
    {
        var productImages = new List<ProductImage>();
        foreach (var product in Products)
        {
            for (int i = 0; i < 3; i++)
            {
                var productImage = new ProductImage
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Url = $"https://picsum.photos/200/?random={GetRandomNumberForImage()}",
                    ProductId = product.Id
                };
                productImages.Add(productImage);
            }
        }
        return productImages;
    }

    public static List<User> GetUsers()
    {
        PasswordService.HashPassword("SuperAdmin1234", out string hashedPassword, out byte[] salt);
        return new List<User>
        {
            new()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Name = "SuperAdmin",
                Email = "superadmin@gmail.com",
                Password = hashedPassword,
                Avatar = $"https://picsum.photos/200/?random={GetRandomNumberForImage()}",
                Salt = salt,
                Role = Role.Admin,
                AddressLine1 = "Olympiakatu 12",
                AddressLine2 = "C1",
                PostCode = 65100,
                City = "Vaasa",
                Country = "Finland"
            }
        };
    }
}
