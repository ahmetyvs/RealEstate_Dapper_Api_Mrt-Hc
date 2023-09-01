using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductDetailRepository
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly Context _context;
        public ProductDetailRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            string query = "Select * From ProductDetails";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDetailDto>(query);
                return values.ToList();
            }
        }

        public async void CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            string query = "insert into ProductDetails (ProductSize,BedRoomCount,BathCount,RoomCount,GarageSize,BuildYear,Price,Location,VideoUrl,ProductID) values (@productSize,@bedRoomCount,@bathCount,@roomCount,@garageSize,@buildYear,@price,@location,@videoUrl,@productID)";
            var parameters = new DynamicParameters();
            parameters.Add("@productSize", createProductDetailDto.ProductSize);
            parameters.Add("@bedRoomCount", createProductDetailDto.BedRoomCount);
            parameters.Add("@bathCount", createProductDetailDto.BathCount);
            parameters.Add("@roomCount", createProductDetailDto.RoomCount);
            parameters.Add("@garageSize", createProductDetailDto.GarageSize);
            parameters.Add("@buildYear", createProductDetailDto.BuildYear);
            parameters.Add("@price", createProductDetailDto.Price);
            parameters.Add("@location", createProductDetailDto.Location);
            parameters.Add("@videoUrl", createProductDetailDto.VideoUrl);
            parameters.Add("@productID", createProductDetailDto.ProductID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteProductDetail(int id)
        {
            string query = "Delete From ProductDetails Where ProductDetailID=@productDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@productDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIDProductDetailDto> GetProductDetail(int id)
        {
            string query = "Select * From ProductDetails Where ProductDetailID=@ProductDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDProductDetailDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            string query = "Update ProductDetails Set ProductSize=@productSize,BedRoomCount=@bedRoomCount,BathCount=@bathCount,RoomCount=@roomCount,GarageSize=@garageSize,BuildYear=@buildYear,Price=@price,Location=@location,VideoUrl=@videoUrl,ProductID=@productID where ProductDetailID=@productDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@productDetailID", updateProductDetailDto.ProductDetailID);
            parameters.Add("@productSize", updateProductDetailDto.ProductSize);
            parameters.Add("@bedRoomCount", updateProductDetailDto.BedRoomCount);
            parameters.Add("@bathCount", updateProductDetailDto.BathCount);
            parameters.Add("@roomCount", updateProductDetailDto.RoomCount);
            parameters.Add("@garageSize", updateProductDetailDto.GarageSize);
            parameters.Add("@buildYear", updateProductDetailDto.BuildYear);
            parameters.Add("@price", updateProductDetailDto.Price);
            parameters.Add("@location", updateProductDetailDto.Location);
            parameters.Add("@videoUrl", updateProductDetailDto.VideoUrl);
            parameters.Add("@productID", updateProductDetailDto.ProductID);
            using (var connectiont = _context.CreateConnection())
            {
                await connectiont.ExecuteAsync(query, parameters);
            }
        }

        //public async Task<List<ResultProductDetailCategoryDto>> GetAllProductDetailWithCategoryAsync()
        //{
        //    /*Employee Tablosu Hariç*/
        //    //string query = "Select ProductID,Title,Price,City,District,Address,Type,CoverImage,CategoryName From Product inner join Category on Product.ProductCategory=Category.CategoryID";

        //    /*Employee Tablosu Dahil*/
        //    string query = "SELECT Product.ProductID, Product.Title, Product.Price, Product.CoverImage, Product.City, Product.District, Product.Address, Product.Description, Product.Type, Category.CategoryName, Employee.Name" +
        //        " FROM Product " +
        //        "INNER JOIN Category ON Product.ProductCategoryID = Category.CategoryID " +
        //        "INNER JOIN Employee ON Product.EmployeeID = Employee.EmployeeID";

        //    using (var connection = _context.CreateConnection())
        //    {
        //        var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
        //        return values.ToList();
        //    }
        //}

    }
}
