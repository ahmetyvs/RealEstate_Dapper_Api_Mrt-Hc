using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Repositories.ProductDetailRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {

        private readonly IProductDetailRepository _productDetailRepository;
        public ProductDetailsController(IProductDetailRepository productDetailRepository)
        {
            _productDetailRepository = productDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailRepository.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            _productDetailRepository.CreateProductDetail(createProductDetailDto);
            return Ok("Daire Detayı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(int id)
        {
            _productDetailRepository.DeleteProductDetail(id);
            return Ok("Daire Detayı Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            _productDetailRepository.UpdateProductDetail(updateProductDetailDto);
            return Ok("Daireye Ait Detay Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            var value = await _productDetailRepository.GetProductDetail(id);
            return Ok(value);
        }
    }
}
