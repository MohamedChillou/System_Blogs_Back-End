using Back_Blogs.Data;
using Back_Blogs.Dto;
using Back_Blogs.Models;

namespace Back_Blogs.Services
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly AppDbContext _dbContext ;

        public ServiceCategory(AppDbContext appDb)
        {
                _dbContext = appDb;
        }

        public async Task<CatgDto> AddCategory(string category)
        {
            Category _category = new Category { Type = category};
            _dbContext.Categories.Add(_category);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return new CatgDto() { Type = category };
        }
    }
}
