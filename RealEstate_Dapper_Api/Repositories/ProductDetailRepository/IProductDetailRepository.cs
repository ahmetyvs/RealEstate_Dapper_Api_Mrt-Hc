using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductDetailRepository
{
    public interface IProductDetailRepository
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        void CreateProductDetail(CreateProductDetailDto createProductDetailDto);
        void DeleteProductDetail(int id);
        void UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto);
        Task<GetByIDProductDetailDto> GetProductDetail(int id);
    }
}
