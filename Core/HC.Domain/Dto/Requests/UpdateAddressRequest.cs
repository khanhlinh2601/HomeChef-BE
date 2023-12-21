namespace HC.Domain.Dto.Requests;

public class UpdateAddressRequest
{
    public string HouseNumber { get; set; } = null!;
    public string HouseType { get; set; } = null!;
    public string Ward { get; set; } = null!;
    public Guid DistrictId { get; set; }
    public Guid CustomerId { get; set; }
}