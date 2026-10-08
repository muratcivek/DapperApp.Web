using DapperApp.Web.DTOs.Categories;

namespace DapperApp.Web.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<ResultCategoryDto>> GetAllAsync();
        Task<ResultCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCategoryDto categoryDto);
        Task UpdateAsync(UpdateCategoryDto categoryDto);
        Task DeleteAsync(int id);
    }
}
