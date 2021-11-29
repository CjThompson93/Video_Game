using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.Data;
using VideoGame.Models;

namespace VideoGame.Services
{
    public class FavoriteService
    {
        private readonly Guid _userId;

        public FavoriteService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateFavorites(FavoriteCreate model)
        {
            var entity = new Favorite()
            {
                GameId = model.GameId,
                UserId = _userId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Favorites.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FavoriteList> GetFavoriteByUserId(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Favorites.Where(e => e.UserId == userId).Select(e => new FavoriteList { GameTitle = e.Game.Title });
                return query.ToArray();
            }
        }
        public bool UpdateFavorites(FavoriteEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Favorites.Single(e => e.FavoriteId == model.FavoriteId);
                entity.GameId = model.GameId;
                entity.UserId = model.UserId;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteFavorites(int favoriteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Favorites.Single(e => e.FavoriteId == favoriteId);
                ctx.Favorites.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }

    }
}
