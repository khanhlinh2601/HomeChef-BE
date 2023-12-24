namespace HC.Domain.Common.Models;

public class Response<T>
{
    public Response(T data)
    {
        Data = data;
    }

    public Response(string message)
    {
        Message = message;
    }

    public Response(string message, bool success)
    {
        Message = message;
        Success = success;
    }

    public Response(T data, string message, bool success)
    {
        Data = data;
        Message = message;
        Success = success;
    }

    public T Data { get; set; }

    public string? Message { get; set; }

    public bool Success { get; set; } = true;
}