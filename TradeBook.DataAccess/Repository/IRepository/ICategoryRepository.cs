using System;
using System.Collections.Generic;
using System.Text;
using TradeBook.Models;

namespace TradeBook.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void update(Category category);
    }
}
