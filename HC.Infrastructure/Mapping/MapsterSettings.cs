using HC.Domain.Dto.Requests;
using HC.Domain.Entities;
using Mapster;

namespace HC.Infrastructure.Mapping;

public class MapsterSettings
{
    public static void Configure()
    {
        TypeAdapterConfig<CreateUserRequest, User>.NewConfig()
        .Map(dest => dest.FcmToken, src => new List<string> { src.FcmToken });
        


        // here we will define the type conversion / Custom-mapping
        // More details at https://github.com/MapsterMapper/Mapster/wiki/Custom-mapping

        // This one is actually not necessary as it's mapped by convention
        // TypeAdapterConfig<Product, ProductDto>.NewConfig().Map(dest => dest.BrandName, src => src.Brand.Name);
    }
}