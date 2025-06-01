using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Data;
using gameStore.Interface;
using gameStore.Models;

namespace gameStore.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly GameDbContext _context;

        public CategoryRepository(GameDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            await _context.AddAsync(category);
            _context.SaveChanges();
            return category;
        }

        public Task<List<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }
    }
}