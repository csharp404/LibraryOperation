namespace LibraryOperation.Presentation.Constants;

public static class ApiMessages
{
    public static class Template
    {
       
        public const string Retrieved = "{0} retrieved successfully";
        public const string Created = "{0} created successfully";
        public const string Updated = "{0} updated successfully";
        public const string Deleted = "{0} deleted successfully";


        public const string NotFound = "{0} not found";
        public const string CreateFailed = "Failed to create {0}";
        public const string UpdateFailed = "Failed to update {0}";
        public const string DeleteFailed = "Failed to delete {0}";
        public const string RetrieveFailed = "Failed to retrieve {0}";
    }


    public static class Entities
    {
        public const string User = "User";
        public const string Borrower = "Borrower";
        public const string Book = "Book";
        public const string Author = "Author";
        public const string Loan = "Loan";
       
    }
}
