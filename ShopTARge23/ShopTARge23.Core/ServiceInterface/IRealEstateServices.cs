using ShopTARge23.Core.Domain;
using ShopTARge23.Core.Dto;

namespace ShopTARge23.Core.ServiceInterface
{
    public interface IRealEstateServices
    {

        Task<RealEstate> Create(RealEstateDto dto);

        public async Task<RealEstate> GetAsync(Guid id);
    }
}
