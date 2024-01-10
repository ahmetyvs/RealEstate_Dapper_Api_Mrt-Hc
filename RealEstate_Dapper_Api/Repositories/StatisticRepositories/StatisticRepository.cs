using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticsRepository
    {
        private readonly Context _context;
        public StatisticRepository(Context context)
        {
            _context = context;
        }

        // Burası iptal şimdilik kullanmıyorum.
        public int CategoryCount()
        {
            string query = "Select * From Category";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
