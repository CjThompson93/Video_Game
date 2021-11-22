using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoGame.Models;
using VideoGame.Services;

namespace VideoGame.Controllers
{
    [Authorize]
    public class GameRatingController : ApiController
    {
        private GameRatingService CreateGameRatingService()
        {
             var gameRatingService = new GameRatingService();
            return gameRatingService;
        }
        //Get All GAme Ratings
        public IHttpActionResult Get()
        {
            GameRatingService gameRatingService = CreateGameRatingService();
            var ratings = gameRatingService.GetGameRatings();
            return Ok(ratings);
        }
        public IHttpActionResult Post(GameRatingCreate gameRating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGameRatingService();
            if (!service.CreateGameRating(gameRating))
                return InternalServerError();
            return Ok();
        }
        // Get game rating by id
        public IHttpActionResult Get(int id)
        {
            GameRatingService gameRatingService = CreateGameRatingService();
            var ratings = gameRatingService.GetGameRatingById(id);
            return Ok();
        }
        //Edit Game Rating
        public IHttpActionResult Put(GameRatingEdit gameRating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGameRatingService();
            if (!service.UpdateGameRating(gameRating))
                return InternalServerError();
            return Ok();
        }
        // Delete Game Rating
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGameRatingService();
            if (!service.DeleteGameRating(id))
                return InternalServerError();
            return Ok();
        }
    }
}
