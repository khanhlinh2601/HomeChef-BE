namespace HC.Application.Common.Persistence;

public interface IConnectionStringValidator
{
    bool TryValidate(string connectionString);
}