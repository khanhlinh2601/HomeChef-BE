using System.Net;

namespace HC.BE.Application.Common.Exceptions;

public class InternalServerException : CustomException
{
    public InternalServerException(string message, List<string>? errors = default)
        : base(message, errors, HttpStatusCode.InternalServerError)
    {
    }
}