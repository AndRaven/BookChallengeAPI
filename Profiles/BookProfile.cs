

using AutoMapper;

public class BookProfile : Profile
{
    public BookProfile()
    {
         CreateMap<Book, BookDto>();
    }
}