using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGame.Models;
using VideoGame.Services;

namespace VideoGame.MVC.Controllers
{
    [Authorize]
    public class GameDeveloperController : Controller
    {
        private GameDeveloperService CreateGameDeveloperService()
        {
            var developerService = new GameDeveloperService();
            return developerService;
        }
        // GET: GameDeveloper
        public ActionResult Index()
        {
            GameDeveloperService developerService = CreateGameDeveloperService();
            var gameDevelopers = developerService.GetGameDevelopers();
            return View(gameDevelopers);
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameDeveloperCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var developerService = CreateGameDeveloperService();

            if (developerService.CreateGameDeveloper(model))
            {
                TempData["SaveResult"] = "The developer was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Developer could not be created.");
            return View(model);
        }
        // Details
        public ActionResult Details(int id)
        {
            var svc = CreateGameDeveloperService();
            var model = svc.GetGameDeveloperById(id);
            return View(model);
        }
        //Edit
        public ActionResult Edit(int id)
        {
            var gameDeveloperService = CreateGameDeveloperService();
            var detail = gameDeveloperService.GetGameDeveloperById(id);
            var model = new GameDeveloperEdit
            {
              DeveloperId = detail.DeveloperId,
              DeveloperName = detail.DeveloperName

            };
            return View(model);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameDeveloperEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DeveloperId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var gameDeveloperService = CreateGameDeveloperService();
            if (gameDeveloperService.UpdateGameDeveloper(model))
            {
                TempData["SaveResult"] = "The Game Developer was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Game Developer could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGameDeveloperService();
            var model = svc.GetGameDeveloperById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var gameDeveloperService = CreateGameDeveloperService();
            gameDeveloperService.DeleteGameDeveloper(id);
            TempData["SaveResult"] = "The developer Has Been Deleted.";
            return RedirectToAction("Index");
        }
    }
}