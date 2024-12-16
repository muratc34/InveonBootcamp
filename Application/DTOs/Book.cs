namespace Application.DTOs;

public record GetBookDto(int Id, string Title, string Author, int PublicationYear, string ISBN, string Genre, string Publisher, int PageCount, string Language, string Summary, int AvailableCopies);

public record GetBooksDto(int Id, string Title, string Author, int PublicationYear, string ISBN);