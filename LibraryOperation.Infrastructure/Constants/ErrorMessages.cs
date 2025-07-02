namespace LibraryOperation.Infrastructure.Constants;

public static class ErrorMessages
{



    public static class RetrieveFailed
    {
        public const string Title = "Failed to Retrieve {0}";
        public const string Detail = "An error occurred while retrieving the {0}.";
    }

    public static class NotFound
    {
        public const string Title = "{0} Not Found";
        public const string Detail = "{0} with ID {1} was not found.";
    }



    public static class CreateFailed
    {
        public const string Title = "Failed to Create {0}";
        public const string Detail = "An error occurred while creating the {0}.";
    }

    public static class UpdateFailed
    {
        public const string Title = "Failed to Update {0}";
        public const string Detail = "An error occurred while updating the {0} with ID {1}.";
    }

    public static class DeleteFailed
    {
        public const string Title = "Failed to Delete {0}";
        public const string Detail = "An error occurred while deleting the {0} with ID {1}.";
    }

    public static class Validation
    {
        public const string Title = "Validation Failed";
        public const string Detail = "One or more validation errors occurred.";
    }

    public static class Credential
    {
        public const string Title = "Invalid Credentials";
        public const string Detail = "The username or password provided is incorrect.";
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