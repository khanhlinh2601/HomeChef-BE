namespace HC.Domain.Dto.Responses;

public class AddressResponse {
    public string HouseNumber { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string Ward { get; set; } = default!;
    public string? Description { get; set; }
    public DistrictResponse District { get; set; } = default!;
}