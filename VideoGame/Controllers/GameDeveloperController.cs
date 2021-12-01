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
    public class GameDeveloperController : ApiController
    {
        public IHttpActionResult Get()
        {
            GameDeveloperService gameDeveloperService = CreateGameDeveloperService();
            var developers = gameDeveloperService.GetGameDevelopers();
            return Ok(developers);
        }
        public IHttpActionResult Post(GameDeveloperCreate gameDeveloper)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGameDeveloperService();
            if (!service.CreateGameDeveloper(gameDeveloper))
                return InternalServerError();
            return Ok();

        }
        private GameDeveloperService CreateGameDeveloperService()
        {
            var gameDeveloperService = new GameDeveloperService();
            return gameDeveloperService;
        }
        public IHttpActionResult GetGameDeveloperByName(string name)
        {
            GameDeveloperService gameDeveloperService = CreateGameDeveloperService();
            var developer = gameDeveloperService.GetGameDeveloperByName(name);
            return Ok(name);
        }
        public IHttpActionResult Put(GameDeveloperEdit gameDeveloper)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateGameDeveloperService();
            if (!service.UpdateGameDeveloper(gameDeveloper))
                return InternalServerError();
            return Ok();
        }
    }
}
