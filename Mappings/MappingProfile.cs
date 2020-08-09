using AutoMapper;
using BookStore.Entities;
using BookStore.Resources;

namespace BookStore.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to Resource
            CreateMap<Author, AuthorResource>();

            CreateMap<Book, BookResource>()
                .ForMember(book => book.Author, opt => opt.MapFrom(resource => resource.Author));

            // Resource to Entity
            CreateMap<AuthorResource, Author>();
            CreateMap<SaveAuthorResource, Author>();

            CreateMap<BookResource, Book>();
            CreateMap<SaveBookResource, Book>();

            CreateMap<SignUpResource, User>()
                .ForMember(user => user.UserName, opt => opt.MapFrom(resource => resource.UserName))
                .ForMember(user => user.Email, opt => opt.MapFrom(resource => resource.Email))
                .ForMember(user => user.FirstName, opt => opt.MapFrom(resource => resource.FirstName))
                .ForMember(user => user.LastName, opt => opt.MapFrom(resource => resource.LastName));
        }
    }
}