using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;
        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async void CreateTestimonial(CreateTestimonialDto createTestimonilDto)
        {
            string query = "insert into Testimonial (NameSurname,Title,Comment,Status) values (@nameSurname,@title,@comment,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@nameSurname", createTestimonilDto.NameSurname);
            parameters.Add("@title", createTestimonilDto.Title);
            parameters.Add("@comment", createTestimonilDto.Comment);
            parameters.Add("@tatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteTestimonial(int id)
        {
            string query = "Delete From Testimonial Where TestimonialID=@testimonialID";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDTestimonialDto> GetTestimonial(int id)
        {
            string query = "Select * From Testimonial Where TestimonialID=@testimonialID";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDTestimonialDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateTestimonial(UpdateTestimonialDto categoryDto)
        {
            string query = "Update Testimonial Set NameSurname=@nameSurname,Title=@title,Comment=@comment,Status=@status where TestimonialID=@testimonialID";
            var parameters = new DynamicParameters();
            parameters.Add("@nameSurname", categoryDto.NameSurname);
            parameters.Add("@title", categoryDto.Title);
            parameters.Add("@comment", categoryDto.Comment);
            parameters.Add("@status", categoryDto.Status);
            parameters.Add("@testimonialID", categoryDto.TestimonialID);
            using (var connectiont = _context.CreateConnection())
            {
                await connectiont.ExecuteAsync(query, parameters);
            }
        }
    }
}
