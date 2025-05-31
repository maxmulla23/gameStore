using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Models;

namespace gameStore.Interface
{
    public interface ICategory
    {
        Task <Category> CreateCategory(Category category);
        Task<List<Category>> GetAllCategories();
    }
}