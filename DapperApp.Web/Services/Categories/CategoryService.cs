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

        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            const string query = @"
                INSERT INTO Categories (Name)
                VALUES (@Name)";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(
                query,
                new { Name = categoryDto.Name }
            );
        }

        public async Task DeleteAsync(int id)
        {
            const string query = @"
                DELETE FROM Categories
                WHERE CategoryId = @Id";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(
                query,
                new { Id = id }
            );
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            const string query = @"
                SELECT CategoryId, Name
                FROM Categories
                ORDER BY CategoryId DESC";

            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<ResultCategoryDto>(query);
        }

        public async Task<ResultCategoryDto?> GetByIdAsync(int id)
        {
            const string query = @"
                SELECT CategoryId, Name
                FROM Categories
                WHERE CategoryId = @Id";

            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<ResultCategoryDto>(
                query,
                new { Id = id }
            );
        }

        public async Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            const string query = @"
                UPDATE Categories
                SET Name = @Name
                WHERE CategoryId = @Id";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(
                query,
                new
                {
                    Id = categoryDto.CategoryId,
                    Name = categoryDto.Name
                }
            );
        }
    }
}