﻿
using Carter;
using LibraryOperation.Application.Dtos.Author;
using LibraryOperation.Application.Dtos.Book;
using LibraryOperation.Application.IService;
using LibraryOperation.Domain.Entities;
using LibraryOperation.Infrastructure.Services.BookService;
using LibraryOperation.Presentation.Constants;
using LibraryOperation.Presentation.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryOperation.Presentation.Api;

public class BookApi : ICarterModule
{


    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api").RequireRateLimiting("fixed");

        group.MapGet("books", GetAllBooks).RequireAuthorization(policy=>policy.RequireRole("Admin"));
        group.MapGet("books/{id:int}", GetBookById).RequireAuthorization(policy => policy.RequireRole("Admin"));
        group.MapPost("books", AddNewBook).RequireAuthorization(policy=>policy.RequireRole("Admin"));
        group.MapPut("books/{id:int}", UpdateBook).RequireAuthorization(policy=>policy.RequireRole("Admin"));
        group.MapDelete("books/{id:int}", DeleteBook).RequireAuthorization(policy=>policy.RequireRole("Admin"));
    }


    public async Task<IResult> GetAllBooks(IBookService bookService)
    {
        var result = await bookService.GetBooksAsync();
        return Results.Ok(new ApiResponse<List<Book>>(true, data: result,
            string.Format(ApiMessages.Template.Retrieved, ApiMessages.Entities.Book)));
    }
    public async Task<IResult> GetBookById(int id , IBookService bookService)
    {
        var result = await bookService.GetBookAsync(id);
        return Results.Ok(new ApiResponse<Book>(true, data: result,
            string.Format(ApiMessages.Template.Retrieved, ApiMessages.Entities.Book)));
    }
    public async Task<IResult> AddNewBook(CreateBookDto model,IBookService bookService)
    {
        var result = await bookService.CreateBookAsync(model);
        return Results.Ok(new ApiResponse<List<Book>>(true, data: null,
            string.Format(ApiMessages.Template.Created, ApiMessages.Entities.Book)));
    }
    public async Task<IResult> UpdateBook(int id, UpdateBookDto model, IBookService bookService)
    {
        var result = await bookService.UpdateBookAsync(id, model);
        return Results.Ok(new ApiResponse<List<Book>>(true, data: null,
            string.Format(ApiMessages.Template.Updated, ApiMessages.Entities.Book)));
    }
    public async Task<IResult> DeleteBook(int id,IBookService bookService)
    {
        var result = await bookService.DeleteBookAsync(id);
        return Results.Ok(new ApiResponse<List<Book>>(true, data: null,
            string.Format(ApiMessages.Template.Deleted, ApiMessages.Entities.Book)));
    }
}