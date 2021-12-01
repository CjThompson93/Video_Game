using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGame.Models;
using VideoGame.Services;

namespace VideoGame.MVC.Controllers
{
    public class GameRatingController : Controller
    {
        private GameRatingService CreateGameRatingService()
        {
            var gameRatingService = new GameRatingService();
            return gameRatingService;
        }
        // GET: GameRating
        public ActionResult Index()
        {
            GameRatingService gameRatingService = CreateGameRatingService();
            var gameratings = gameRatingService.GetGameRatings();
            return View(gameratings);
        }
        // CREATE - GET
        public ActionResult Create()
        {
            return View();
        }
        // Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameRatingCreate model)
        {
            if (!ModelState.IsValid) return View(model);
                 var gameRatingService = CreateGameRatingService();
            if (gameRatingService.CreateGameRating(model))
            {
                TempData["Save Result"] = "Your Game Rating was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Game Rating could not be created.");
            return View(model);
        }
        //Details
        public ActionResult Details(int id)
        {
            var svc = CreateGameRatingService();
            var model = svc.GetGameRatingById(id);
            return View(model);
        }
        //EDIT
        public ActionResult Edit(int id)
        {
            var gameRatingService = CreateGameRatingService();
            var detail = gameRatingService.GetGameRatingById(id);
            var model = new GameRatingEdit
            {
                RatingId = detail.RatingId,
                RatingName = detail.RatingName
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameRatingEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            
            if(model.RatingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var gameRatingService = CreateGameRatingService();
            if (gameRatingService.UpdateGameRating(model))
            {
                TempData["SaveResult"] = "The Game Rating has been updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Game Rating has not been saved");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGameRatingService();
            var model = svc.GetGameRatingById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var gameRatingService = CreateGameRatingService();
            gameRatingService.DeleteGameRating(id);
            TempData["SaveResult"] = "The Game Rating has been deleted.";
            return RedirectToAction("Index");
        }
    }
}