using AutoMapper;
using BookChallengeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BookChallenge.Test;

[TestFixture]
  public class BooksControllerTests
{

    private BooksController _controller;

    private  Mock<IChallengeRepository> _challengeRepoMock;
    private  Mock<IMapper> _mapperMock;

    private  Mock<ILogger<BooksController>> _loggerMock;

    private List<Book> _books = new List<Book>();


    [OneTimeSetUp]
    public void OneTimeSetup()
    {
      
    }

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<BooksController>>();
        _mapperMock = new Mock<IMapper>();
        _challengeRepoMock = new Mock<IChallengeRepository>();

        _controller = new BooksController(_challengeRepoMock.Object, _loggerMock.Object, _mapperMock.Object);

       _books.Add(new Book() { Id = 1, Title = "Book1", Author = "Author1", Description = "Description1" });
       _books.Add(new Book() { Id = 2, Title = "Book2", Author = "Author2", Description = "Description2" });
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
    }
    
    [TearDown]
    public void TearDown()
    {
    }
    
    [Test]
    public async Task GetBooks_WhenChallengeDoesNotExist_ReturnsNotFound()
    {
        _challengeRepoMock.Setup(repo => repo.CheckChallengeExistsAsync(100)).ReturnsAsync(false);

        var result = await _controller.GetBooks(100);

        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public async Task GetBooks_WhenChallengeExists_ReturnsBooks()
    {
        _challengeRepoMock.Setup(repo => repo.CheckChallengeExistsAsync(1)).ReturnsAsync(true);

        _challengeRepoMock.Setup(repo => repo.GetBooksForChallengeAsync(1))
                          .ReturnsAsync(_books);

        _mapperMock.Setup(m => m.Map<IEnumerable<BookDto>>(It.IsAny<IEnumerable<Book>>()))
            .Returns(_books.Select(b => new BookDto { Id = b.Id, Title = b.Title }).ToList());

        var result = await _controller.GetBooks(1);

        Assert.That(result, Is.TypeOf<OkObjectResult>());

        var okResult = result as OkObjectResult;
        var returnedBookDtos = okResult.Value as IEnumerable<BookDto>;

        Assert.That(returnedBookDtos, Is.Not.Empty);

        var firstBook = returnedBookDtos.FirstOrDefault();

        Assert.That(firstBook.Id, Is.EqualTo(1));
    }

    
}