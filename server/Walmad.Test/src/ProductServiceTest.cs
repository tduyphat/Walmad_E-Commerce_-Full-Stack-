using AutoMapper;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Parameter;
using Walmad.Core.src.Entity;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Service;
using Walmad.Business.src.Shared;
using Moq;

namespace Walmad.Test.src;

public class ProductServiceTest
{
    private static IMapper _mapper;
    public ProductServiceTest()
    {
        if (_mapper == null)
        {
            var mappingConfig = new MapperConfiguration(map =>
            {
                map.AddProfile(new MapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }
    }

    [Fact]
    public void GetAllProducts_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IProductRepo>();
        var categoryRepo = new Mock<ICategoryRepo>();
        var mapper = new Mock<IMapper>();
        var productService = new ProductService(repo.Object, _mapper, categoryRepo.Object);
        var options = new GetAllParams { Limit = 120, Offset = 0, sortType = SortType.byTitle, sortOrder = SortOrder.asc };

        productService.GetAll(options);

        repo.Verify(repo => repo.GetAll(options), Times.Once);
    }

    [Fact]
    public void GetProductById_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IProductRepo>();
        var categoryRepo = new Mock<ICategoryRepo>();
        Product product = new Product() { };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(product);
        var mapper = new Mock<IMapper>();
        var productService = new ProductService(repo.Object, _mapper, categoryRepo.Object);

        productService.GetOneById(It.IsAny<Guid>());

        repo.Verify(repo => repo.GetOneById(It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public void CreateOne_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IProductRepo>();
        var categoryRepo = new Mock<ICategoryRepo>();
        categoryRepo.Setup(categoryRepo => categoryRepo.GetOneById(It.IsAny<Guid>())).Returns(new Category() { });
        var mapper = new Mock<IMapper>();
        var productService = new ProductService(repo.Object, _mapper, categoryRepo.Object);
        ProductCreateDTO productCreateDto = new ProductCreateDTO() { };

        productService.CreateOne(productCreateDto);

        repo.Verify(repo => repo.CreateOne(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public void DeleteProduct_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IProductRepo>();
        var categoryRepo = new Mock<ICategoryRepo>();
        Product product = new Product() { };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(product);
        var mapper = new Mock<IMapper>();
        var productService = new ProductService(repo.Object, _mapper, categoryRepo.Object);

        productService.DeleteOne(It.IsAny<Guid>());

        repo.Verify(repo => repo.DeleteOne(It.IsAny<Product>()), Times.Once);
    }
}
