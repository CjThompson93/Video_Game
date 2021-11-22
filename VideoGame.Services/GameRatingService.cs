using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.Data;
using VideoGame.Models;

namespace VideoGame.Services
{
    public class GameRatingService
    {
        private readonly Guid _userId;


        //CRUD
        //Create GameRating
        public bool CreateGameRating(GameRatingCreate model)
        {
            var entity = new GameRating()
            {
                RatingName = model.RatingName
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Get GameRatings
        public IEnumerable<GameRatingList> GetGameRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var quary = ctx.Ratings.Select(e => new GameRatingList { RatingId = e.RatingId, RatingName = e.RatingName });
                return quary.ToArray();
            }
        }
        //Get GameRatings by Id
        public GameRatingDetails GetGameRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(e => e.RatingId == id);
                return new GameRatingDetails
                {
                    RatingId = entity.RatingId,
                    RatingName = entity.RatingName,
                };
            }
        }
        //Get GameRatings by name
        public GameRatingDetails GetGameRatingByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(e => e.RatingName == name);
                return new GameRatingDetails
                {
                    RatingId = entity.RatingId,
                    RatingName = entity.RatingName,
                };
            }
        }
        //Edit GameRatings
        public bool UpdateGameRating(GameRatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(e => e.RatingId == model.RatingId);
                entity.RatingName = model.RatingName;
                return ctx.SaveChanges() == 1;
            }
        }
        //Delete GameRatings
        public bool DeleteGameRating(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(e => e.RatingId == id);
                ctx.Ratings.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
