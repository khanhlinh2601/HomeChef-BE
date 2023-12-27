using Microsoft.AspNetCore.Http;
namespace HC.Domain.Dto.Requests;

public class StorageRequest
{
    //upload file
    public IFormFile File { get; set; } = null!;
}

