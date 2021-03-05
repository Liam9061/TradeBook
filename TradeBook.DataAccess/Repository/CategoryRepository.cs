using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradeBook.DataAccess.Data;
using TradeBook.DataAccess.Repository.IRepository;
using TradeBook.Models;

namespace TradeBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Category category)
        {
            var objFromDb = _db.Categories.FirstOrDefault(s => s.Id == category.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = category.Name;
                
            }
        }
    }
}