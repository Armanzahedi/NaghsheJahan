using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
    public class CategoriesRepository : BaseRepository<Category, MyDbContext>
    {
        public CategoriesRepository(MyDbContext context) : base(context)
        {

        }
        // We can add new methods specific to the artist repository here in the future
    }
}
