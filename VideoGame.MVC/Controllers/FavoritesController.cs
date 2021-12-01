using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGame.Services;

namespace VideoGame.MVC.Controllers
{
    public class FavoritesController : Controller
    {
        private FavoriteService CreateFavoriteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var favoriteService = new FavoriteService(userId);
            return favoriteService;
        }
        // GET: Favorites
        public ActionResult Index()
        {
            return View();
        }
    }
}