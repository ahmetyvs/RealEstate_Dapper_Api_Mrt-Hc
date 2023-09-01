using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductDetailRepository
{
    public interface IProductDetailRepository
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
      //  Task<List<ResultProductDetailWithCategoryDto>> GetAllProductDetailWithCategoryAsync();
        void CreateProductDetail(CreateProductDetailDto createProductDetailDto);
        void DeleteProductDetail(int id);
        void UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto);
        Task<GetByIDProductDetailDto> GetProductDetail(int id);
    }
}
