using AutoMapper;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Parameter;
using Walmad.Core.src.Entity;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Service;
using Walmad.Business.src.Shared;
using Moq;

namespace Walmad.Test.src;

public class CategoryServiceTest
{
    private static IMapper _mapper;

    public CategoryServiceTest()
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
    public void GetAllCategories_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<ICategoryRepo>();
        var mapper = new Mock<IMapper>();
        var categoryService = new CategoryService(repo.Object, _mapper);
        var options = new GetAllParams { Limit = 120, Offset = 0, sortType = SortType.byTitle, sortOrder = SortOrder.asc };

        categoryService.GetAll(options);

        repo.Verify(repo => repo.GetAll(options), Times.Once);
    }

    [Fact]
    public void GetCategoryById_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<ICategoryRepo>();
        Category category = new Category() { Name = "Electronic", Image = "https://picsum.photos/200" };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(category);
        var mapper = new Mock<IMapper>();
        var categoryService = new CategoryService(repo.Object, _mapper);

        categoryService.GetOneById(It.IsAny<Guid>());

        repo.Verify(repo => repo.GetOneById(It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public void CreateCategory_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<ICategoryRepo>();
        var mapper = new Mock<IMapper>();
        var categoryService = new CategoryService(repo.Object, _mapper);
        CategoryCreateDTO categoryCreateDto = new CategoryCreateDTO() { Name = "Electronic", Image = "https://picsum.photos/200" };

        categoryService.CreateOne(categoryCreateDto);

        repo.Verify(repo => repo.CreateOne(It.IsAny<Category>()), Times.Once);
    }

    [Fact]
    public void DeleteCategory_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<ICategoryRepo>();
        Category category = new Category() { Name = "Electronic", Image = "https://picsum.photos/200" };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(category);
        var mapper = new Mock<IMapper>();
        var categoryService = new CategoryService(repo.Object, _mapper);

        categoryService.DeleteOne(It.IsAny<Guid>());

        repo.Verify(repo => repo.DeleteOne(It.IsAny<Category>()), Times.Once);
    }

    [Fact]
    public void UpdateCategory_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<ICategoryRepo>();
        Category category = new Category() { Name = "Electronic", Image = "https://picsum.photos/200" };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(category);
        var mapper = new Mock<IMapper>();
        var categoryService = new CategoryService(repo.Object, _mapper);
        CategoryUpdateDTO categoryUpdateDto = new CategoryUpdateDTO() { Name = "Computer", Image = "https://picsum.photos/200" };

        categoryService.UpdateOne(It.IsAny<Guid>(), categoryUpdateDto);

        repo.Verify(repo => repo.UpdateOne(It.IsAny<Category>()), Times.Once);
    }
}
