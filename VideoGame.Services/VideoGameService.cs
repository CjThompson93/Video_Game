using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.Data;
using VideoGame.Models;

namespace VideoGame.Services
{
    public class VideoGameService
    {
        private readonly Guid _userId;

        //Creating New VideoGame
        public bool CreateVideoGame(VideoGameCreate model)
        {
            var entity = new VideoGame.Data.VideoGame()
            {
                
                Title = model.Title,
                GameType = model.GameType,
                DateCreated = model.DateCreated,
                GameLength = model.GameLength,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.VideoGames.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        // Getting a list of all video games
        public IEnumerable<VideoGameList> GetVideoGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.VideoGames.Select(e => new VideoGameList
                {
                    GameId = e.GameId,
                    Title = e.Title,
                    GameRatings = e.GameRatings.Select(n => new GameRatingList { RatingName = n.GameRating.RatingName, RatingId = n.GameRating.RatingId }).ToList(),
                    Developers = e.Developers.Select(n => new GameDeveloperList { DeveloperName = n.Developer.DeveloperName }).ToList()

                });
                return query.ToArray();
            }
        }
        //Getting Games By Title
        public VideoGameDetails GetVideoGameByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.VideoGames.Single(e => e.Title == title);
                return new VideoGameDetails
                {
                    GameId = entity.GameId,
                    Title = entity.Title,
                    GameLength = entity.GameLength,
                    GameType = entity.GameType,
                    DateCreated = entity.DateCreated,
                    DeveloperName = entity.Developers.Select(n => new GameDeveloper
                    {
                        DeveloperId = n.Developer.DeveloperId,
                        DeveloperName = n.Developer.DeveloperName
                    }).ToList()
                };
            }
        }
        public IEnumerable<VideoGameList> GetVideoGamesByDeveloper(string developerName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.GameDeveloper.Where(e => e.Developer.DeveloperName == developerName).Select(e => new VideoGameList
                {
                    GameId = e.GameId,
                    Title = e.Game.Title,
                    GameRatings = e.Game.GameRatings.Select(n => new GameRatingList { RatingName = n.GameRating.RatingName }).ToList(),
                    Developers = e.Game.Developers.Select(n => new GameDeveloperList { DeveloperName = n.Developer.DeveloperName }).ToList()
                });
                return query.ToArray();
            }
        }
        // Get Games by Rating
        public IEnumerable<VideoGameList> GetVideoGamesByRating(string ratingName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.GameRating.Where(e => e.GameRating.RatingName == ratingName)
                    .Select(e => new VideoGameList
                    {
                        GameId = e.GameId,
                        Title = e.Game.Title,
                        Developers = e.Game.Developers.Select(n => new GameDeveloperList { DeveloperName = n.Developer.DeveloperName }).ToList(),
                        GameRatings = e.Game.GameRatings.Select(n => new GameRatingList { RatingName = n.GameRating.RatingName }).ToList()
                    });
                return query.ToArray();
            }
        }
        //Updating Games
        public bool UpdateVideoGame(VideoGameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.VideoGames.Single(e => e.GameId == model.GameId);
                entity.Title = model.Title;
                entity.GameLength = model.GameLength;
                entity.GameType = model.GameType;
                entity.DateCreated = model.DateCreated;
                return ctx.SaveChanges() == 1;
            }
        }
        //Delete Video Gaame
        public bool DeleteVideoGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.VideoGames.Single(e => e.GameId == gameId);
                ctx.VideoGames.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Adding Rating 
        public bool AddRatingToVideoGame(int ratingId, int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Rating_Game
                {
                    RatingId = ratingId,
                    GameId = gameId
                };

                ctx.GameRating.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool AddDeveloperToVideoGame(int developerId, int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Developer_Game
                {
                    GameId = gameId,
                    DeveloperId = developerId
                };
                ctx.GameDeveloper.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
