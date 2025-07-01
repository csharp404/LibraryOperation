using AutoMapper;
using LibraryOperation.Application.Dtos.Author;
using LibraryOperation.Application.Dtos.Book;
using LibraryOperation.Application.Dtos.Borrower;
using LibraryOperation.Application.Dtos.Loan;
using LibraryOperation.Application.Dtos.User;
using LibraryOperation.Domain.Entities;
using System.Collections.Generic;
using System.Reflection;

namespace LibraryOperation.Application.Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
       
        CreateMap<CreateProfileDto, User>().ReverseMap();
        CreateMap<UpdateProfileDto, User>().ForMember(x => x.Id, x => x.Ignore()).ReverseMap();

        CreateMap<CreateAuthorDto, Author>().ReverseMap();
        CreateMap<UpdateAuthorDto, Author>().ForMember(x => x.Id, x => x.Ignore()).ReverseMap();

        CreateMap<CreateLoanDto, Loan>().ReverseMap();
        CreateMap<UpdateLoanDto, Loan>().ForMember(x => x.Id, x => x.Ignore()).ReverseMap();

        CreateMap<CreateBookDto, Book>().ReverseMap();
        CreateMap<UpdateBookDto, Book>().ForMember(x => x.Id, x => x.Ignore()).ReverseMap();

        CreateMap<CreateBorrowerDto, Borrower>().ReverseMap();
        CreateMap<UpdateBorrowerDto, Borrower>().ForMember(x => x.Id, x => x.Ignore()).ReverseMap();

    }
}