namespace HC.Domain.Dto.Responses;

public class DistrictResponse {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Guid ProvinceId { get; set; }
    
}