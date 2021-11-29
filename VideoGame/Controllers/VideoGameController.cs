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
    public class VideoGameController : ApiController
    {
        private VideoGameService CreateVideoGameService()
        {
            var videoGameService = new VideoGameService();
            return videoGameService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            VideoGameService videoGameService = CreateVideoGameService();
            var videogames = videoGameService.GetVideoGames();
            return Ok(videogames);
        }
        [HttpGet]
        public IHttpActionResult Get(string title)
        {
            VideoGameService videoGameService = CreateVideoGameService();
            var videogame = videoGameService.GetVideoGameByTitle(title);
            return Ok(videogame);
        }
        [HttpGet]
        public IHttpActionResult GetByGameDeveloper(string developerName)
        {
            VideoGameService videoGameService = CreateVideoGameService();
            var videogames = videoGameService.GetVideoGamesByDeveloper(developerName);
            return Ok(videogames);
        }
        [HttpGet]
        public IHttpActionResult GetByGameRating(string ratingName)
        {
            VideoGameService videoGameService = CreateVideoGameService();
            var videogames = videoGameService.GetVideoGamesByRating(ratingName);
            return Ok(videogames);
        }
        [HttpPost]
        public IHttpActionResult Post(VideoGameCreate videoGame)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateVideoGameService();
            if (!service.CreateVideoGame(videoGame))
                return InternalServerError();
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult AddRatingToVideoGame(int ratingId, int gameId)
        {
            var service = CreateVideoGameService();

            if(service.AddRatingToVideoGame(ratingId, gameId))
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPost]
        public IHttpActionResult AddDeveloperToVideoGame(int developerId, int gameId)
        {
            var service = CreateVideoGameService();

            if(service.AddDeveloperToVideoGame(developerId, gameId))
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public IHttpActionResult Put(VideoGameEdit videoGame)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateVideoGameService();
            if (!service.UpdateVideoGame(videoGame))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateVideoGameService();
            if (!service.DeleteVideoGame(id))
                return InternalServerError();
            return Ok();
        }
    }
}
