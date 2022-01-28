using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTracker.Data;
using TabletopTracker.Models.Category;

namespace TabletopTracker.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                        .Select(
                            e => new CategoryListItem
                            {
                                CategoryId = e.CategoryId,
                                Name = e.Name,
                                Description = e.Description
                            }
                        );

                return query.ToArray();
            }
        }
    }
}
