using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOperation.Application.Exception
{
    public class ApiException : System.Exception
    {
        public int StatusCode { get; }
        public string Title { get; }
        public string? DetailMessage { get; }

        public ApiException(string title, int statusCode = 400, string? detail = null)
            : base(title)
        {
            Title = title;
            StatusCode = statusCode;
            DetailMessage = detail;
        }
    }

}
