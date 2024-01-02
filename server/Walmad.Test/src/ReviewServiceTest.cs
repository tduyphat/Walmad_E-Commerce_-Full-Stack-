using AutoMapper;
using Walmad.Core.src.Abstraction;
using Walmad.Core.src.Parameter;
using Walmad.Core.src.Entity;
using Walmad.Business.src.DTO;
using Walmad.Business.src.Service;
using Walmad.Business.src.Shared;
using Moq;

namespace Walmad.Test.src;

public class ReviewServiceTest
{
    private static IMapper _mapper;

    public ReviewServiceTest()
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
    public void GetAllReviews_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IReviewRepo>();
        var productRepo = new Mock<IProductRepo>();
        var userRepo = new Mock<IUserRepo>();
        var mapper = new Mock<IMapper>();
        var reviewService = new ReviewService(repo.Object, _mapper, productRepo.Object, userRepo.Object);
        var options = new GetAllParams { Limit = 120, Offset = 0, sortType = SortType.byTitle, sortOrder = SortOrder.asc };

        reviewService.GetAll(options);

        repo.Verify(repo => repo.GetAll(options), Times.Once);
    }

    [Fact]
    public void GetReviewById_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IReviewRepo>();
        var productRepo = new Mock<IProductRepo>();
        var userRepo = new Mock<IUserRepo>();
        Review review = new Review { Rating = 3, Content = "Good product" };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(review);
        var mapper = new Mock<IMapper>();
        var reviewService = new ReviewService(repo.Object, _mapper, productRepo.Object, userRepo.Object);

        reviewService.GetOneById(It.IsAny<Guid>());

        repo.Verify(repo => repo.GetOneById(It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public void CreateReview_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IReviewRepo>();
        var mapper = new Mock<IMapper>();
        var productRepo = new Mock<IProductRepo>();
        var userRepo = new Mock<IUserRepo>();
        productRepo.Setup(productRepo => productRepo.GetOneById(It.IsAny<Guid>())).Returns(new Product() { });
        userRepo.Setup(userRepo => userRepo.GetOneById(It.IsAny<Guid>())).Returns(new User() { });
        var reviewService = new ReviewService(repo.Object, _mapper, productRepo.Object, userRepo.Object);
        ReviewCreateDTO reviewCreateDto = new ReviewCreateDTO() { Rating = 3, Content = "Good product" };

        reviewService.CreateOne(It.IsAny<Guid>(), reviewCreateDto);

        repo.Verify(repo => repo.CreateOne(It.IsAny<Review>()), Times.Once);
    }

    [Fact]
    public void DeleteCategory_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IReviewRepo>();
        var productRepo = new Mock<IProductRepo>();
        var userRepo = new Mock<IUserRepo>();
        Review review = new Review { Rating = 3, Content = "Good product" };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(review);
        var mapper = new Mock<IMapper>();
        var reviewService = new ReviewService(repo.Object, _mapper, productRepo.Object, userRepo.Object);

        reviewService.DeleteOne(It.IsAny<Guid>());

        repo.Verify(repo => repo.DeleteOne(It.IsAny<Review>()), Times.Once);
    }

    [Fact]
    public void UpdateCategory_ShouldInvokeRepoMethod()
    {
        var repo = new Mock<IReviewRepo>();
        var productRepo = new Mock<IProductRepo>();
        var userRepo = new Mock<IUserRepo>();
        Review review = new Review { Rating = 3, Content = "Good product" };
        repo.Setup(repo => repo.GetOneById(It.IsAny<Guid>())).Returns(review);
        var mapper = new Mock<IMapper>();
        var reviewService = new ReviewService(repo.Object, _mapper, productRepo.Object, userRepo.Object);
        ReviewUpdateDTO reviewUpdateDto = new ReviewUpdateDTO() { Rating = 4, Content = "Excellent product" };

        reviewService.UpdateOne(It.IsAny<Guid>(), reviewUpdateDto);

        repo.Verify(repo => repo.UpdateOne(It.IsAny<Review>()), Times.Once);
    }
}

