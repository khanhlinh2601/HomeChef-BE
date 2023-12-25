namespace HC.Application.Common.Interfaces;

public interface ITokenService : ITransientService
{
    string GetTokenAsync(UserResponse request);
}

