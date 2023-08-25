using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            /*Employee Tablosu Hariç*/
            //string query = "Select ProductID,Title,Price,City,District,Address,Type,CoverImage,CategoryName From Product inner join Category on Product.ProductCategory=Category.CategoryID";

            /*Employee Tablosu Dahil*/
            string query = "SELECT Product.ProductID, Product.Title, Product.Price, Product.CoverImage, Product.City, Product.District, Product.Address, Product.Description, Product.Type, Category.CategoryName, Employee.Name" +
                " FROM Product " +
                "INNER JOIN Category ON Product.ProductCategoryID = Category.CategoryID " +
                "INNER JOIN Employee ON Product.EmployeeID = Employee.EmployeeID";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
