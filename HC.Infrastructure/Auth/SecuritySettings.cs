namespace HC.Infrastructure.Auth;

public class SecuritySettings
{
    public string? Provider { get; set; }
    public bool RequireConfirmedAccount { get; set; }
}