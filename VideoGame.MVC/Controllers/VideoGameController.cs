using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGame.Models;
using VideoGame.Services;

namespace VideoGame.MVC.Controllers
{
    public class VideoGameController : Controller
    {
        private VideoGameService CreateVideoGameService()
        {
            var videoGameService = new VideoGameService();
            return videoGameService;
        }
        // GET: VideoGame
        public ActionResult Index()
        {
            VideoGameService videoGameService = CreateVideoGameService();
            var videogames = videoGameService.GetVideoGames();
            return View(videogames);
        }
        // Create - GET
        public ActionResult Create()
        {
            return View();
        }
        //Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoGameCreate model)
        {
            if (!ModelState.IsValid) return View(model);
             var videoGameService = CreateVideoGameService();

             if (videoGameService.CreateVideoGame(model))
             {
                TempData["SaveResult"] = "The video game was created.";
                return RedirectToAction("Index");
             };
            ModelState.AddModelError("", "Video Game could not be created.");
            return View(model);  
        }
        // Details
        public ActionResult Details(string title)
        {
            var svc = CreateVideoGameService();
            var model = svc.GetVideoGameByTitle(title);
            return View(model);
        }
        //Edit
        public ActionResult Edit(string title)
        {
            var videoGameService = CreateVideoGameService();
            var detail = videoGameService.GetVideoGameByTitle(title);
            var model = new VideoGameEdit
            {
                GameId = detail.GameId,
                Title = detail.Title,
                GameLength = detail.GameLength,
                GameType = detail.GameType,
                DateCreated = detail.DateCreated

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string title, VideoGameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.Title != title)
            {
                ModelState.AddModelError("", "title Mismatch");
                return View(model);
            }
            var videoGameService = CreateVideoGameService();
            if (videoGameService.UpdateVideoGame(model))
            {
                TempData["SaveResult"] = "You're video game was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "You're video game could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(string title)
        {
            var svc = CreateVideoGameService();
            var model = svc.GetVideoGameByTitle(title);
            
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(string title)
        {
            var videoGameService = CreateVideoGameService();
            var model = videoGameService.GetVideoGameByTitle(title);
            videoGameService.DeleteVideoGame(model.GameId);
            TempData["SaveResult"] = "Your Video Game Has Been Deleted.";
            return RedirectToAction("Index");
        }
    }
}