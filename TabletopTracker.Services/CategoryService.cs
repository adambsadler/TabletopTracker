using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTracker.Data;
using TabletopTracker.Models.Category;
using TabletopTracker.Models.Game;

namespace TabletopTracker.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Description = model.Description
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
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

        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Categories.Single(e => e.CategoryId == id && e.OwnerId == _userId);
                return new CategoryDetail
                {
                    CategoryId = entity.CategoryId,
                    Name = entity.Name,
                    Description = entity.Description
                };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == model.CategoryId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == categoryId && e.OwnerId == _userId);
                var games = new GameService(_userId).GetGames();

                foreach(GameListItem game in games)
                {
                    var affectedGame = ctx.Games.Single(a => a.GameId == game.GameId);
                    if(affectedGame.CategoryId == categoryId)
                    {
                        affectedGame.CategoryId = null;
                    }
                }

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
