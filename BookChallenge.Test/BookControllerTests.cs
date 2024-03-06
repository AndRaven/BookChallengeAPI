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

    private  Mock<IChallengeService> _challengeServiceMock;

    private Mock<IBookService> _bookServiceMock;
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
        _challengeServiceMock = new Mock<IChallengeService>();
        _bookServiceMock = new Mock<IBookService>();

        _controller = new BooksController(_challengeServiceMock.Object, _bookServiceMock.Object, _loggerMock.Object, _mapperMock.Object);

       _books.Add(new Book("Book1", "Author1") { Id = 1,  Description = "Description1" });
       _books.Add(new Book("Book2", "Author2") { Id = 2,  Description = "Description2" });
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
        _challengeServiceMock.Setup(service => service.ChallengeExistsAsync(100)).ReturnsAsync(false);

        var result = await _controller.GetBooks(100);

        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public async Task GetBooks_WhenChallengeExists_ReturnsBooks()
    {
        _challengeServiceMock.Setup(service => service.ChallengeExistsAsync(1)).ReturnsAsync(true);

        _challengeServiceMock.Setup(service => service.GetBooksForChallengeAsync(1)).ReturnsAsync(_books);

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