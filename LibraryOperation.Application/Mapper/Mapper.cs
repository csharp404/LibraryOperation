using AutoMapper;
using LibraryOperation.Application.Dtos.Author;
using LibraryOperation.Application.Dtos.Book;
using LibraryOperation.Application.Dtos.Borrower;
using LibraryOperation.Application.Dtos.Loan;
using LibraryOperation.Application.Dtos.User;
using LibraryOperation.Domain.Entities;

namespace LibraryOperation.Application.Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<CreateProfileDto, User>().ReverseMap();
        CreateMap<UpdateProfileDto, User>().ReverseMap();

        CreateMap<CreateAuthorDto, Author>().ReverseMap();
        CreateMap<UpdateAuthorDto, Author>().ReverseMap();

        CreateMap<CreateLoanDto, Loan>().ReverseMap();
        CreateMap<UpdateLoanDto, Loan>().ReverseMap();

        CreateMap<CreateBookDto, Book>().ReverseMap();
        CreateMap<UpdateBookDto, Book>().ReverseMap();

        CreateMap<CreateBorrowerDto, Borrower>().ReverseMap();
        CreateMap<UpdateBorrowerDto, Borrower>().ReverseMap();

    }
}