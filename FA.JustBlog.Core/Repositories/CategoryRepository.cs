using FA.JustBlog.Core.Context;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly IJustBlogContext _context;
        public CategoryRepository(IJustBlogContext context)
        {
            _context = context;
        }
        public int AddCategory(Category category)
        {
            if (category == null)
            {
                return 1;
            }
            _context.Categories.Add(category);
            return _context.SaveChanges();
        }

        //Implemnt async/await method
        public async Task AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Category Find(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
