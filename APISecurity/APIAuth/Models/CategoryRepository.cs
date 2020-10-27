using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace APIAuth.Models
{
    public class CategoryRepository
    {
        private CompanyContext db;

        public CategoryRepository()
        {
            db = new CompanyContext();
        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return db.Categories.Find(id);
        }

        public int Insert(Category category)
        {
            db.Categories.Add(category);
            return db.SaveChanges();
        }

        public int Update(Category category)
        {
            var updateCategory = db.Categories.Find(category.Id);
            updateCategory.CategoryName = category.CategoryName;
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            var category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
                return db.SaveChanges();
            }
            return 0;
        }
    }
}