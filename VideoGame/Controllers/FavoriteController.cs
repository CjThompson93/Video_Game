using Microsoft.AspNet.Identity;
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
    public class FavoriteController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(FavoriteCreate game)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                var service = CreateFavoriteService();
            if (!service.CreateFavorites(game))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(Guid userId)
        {
            FavoriteService favoriteService = CreateFavoriteService();
            var games = favoriteService.GetFavoriteByUserId(userId);
            return Ok(games);
        }
        private FavoriteService CreateFavoriteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var favoriteService = new FavoriteService(userId);
            return favoriteService;
        }
        public IHttpActionResult Put(FavoriteEdit favorites)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateFavoriteService();
            if (!service.UpdateFavorites(favorites))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int favoriteId)
        {
            var service = CreateFavoriteService();
            if (!service.DeleteFavorites(favoriteId))
                return InternalServerError();
            return Ok();
        }
    }
}
