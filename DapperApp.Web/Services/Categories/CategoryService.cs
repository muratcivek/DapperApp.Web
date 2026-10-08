using Dapper;
using DapperApp.Web.Context;
using DapperApp.Web.DTOs.Categories;

namespace DapperApp.Web.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(CreateCategoryDto categoryDto)
        {
           string query = "insert into categories (name) values (@Name)";

            var parameters = new DynamicParameters();
            parameters.Add("name", categoryDto.Name);

            var connection = _context.CreateConnection();

            return connection.ExecuteAsync(query, parameters);
        }

        public Task DeleteAsync(int id)
        {
            string query = "delete from categories where categoryid = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            var connection = _context.CreateConnection();

            return connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            string query = "select * from categories";

            var connection = _context.CreateConnection();

            return await connection.QueryAsync<ResultCategoryDto>(query);
        }

        public async Task<ResultCategoryDto> GetByIdAsync(int id)
        {
            string query = "select * from categories where categoryid = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<ResultCategoryDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            string query = "update categories set name = @Name where categoryid = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("name", categoryDto.Name);
            parameters.Add("id", categoryDto.CategoryId);

            var connection = _context.CreateConnection();

            return connection.ExecuteAsync(query, parameters);
        }
    }
}
