namespace LibraryOperation.Presentation.Model;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public ApiResponse( bool success ,T? data, string message)
    {
        Success = success;
        Message = message;
        if (data != null)
        {
            Data = data;
        }
    }

    
}
