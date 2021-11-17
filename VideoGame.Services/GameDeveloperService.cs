using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGame.Data;
using VideoGame.Models;

namespace VideoGame.Services
{
    public class GameDeveloperService
    {
        private readonly Guid _userId;
        
        //CRUD
        //Create Game Developer
        public bool CreateGameDeveloper(GameDeveloperCreate model)
        {
            var entity = new GameDeveloper()
            {
                DeveloperName = model.DeveloperName
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Developers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        // Get Game Developer
        public IEnumerable<GameDeveloperList> GetGameDevelopers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var quary = ctx.Developers.Select(e => new GameDeveloperList { DeveloperName = e.DeveloperName });
                return quary.ToArray();
            }
        }
        //Get Game Developer by Id
        public GameDeveloperDetails GetGameDeveloperById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Developers.Single(e => e.DeveloperId == id);
                return new GameDeveloperDetails
                {
                    DeveloperId = entity.DeveloperId,
                    DeveloperName = entity.DeveloperName,
                };
            }
        }
        //Get Game Developer by Name
        public GameDeveloperDetails GetGameDeveloperByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Developers.Single(e => e.DeveloperName == name);
                return new GameDeveloperDetails
                {
                    DeveloperId = entity.DeveloperId,
                    DeveloperName = entity.DeveloperName,
                };
            }
        }
        // Edit Game Developers
        public bool UpdateGameDeveloper(GameDeveloperEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Developers.Single(e => e.DeveloperId == model.DeveloperId);
                entity.DeveloperName = model.DeveloperName;
                return ctx.SaveChanges() == 1;
            }
        }
        // Delete Game Developer
        public bool DeleteGameDeveloper(int developerId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Developers;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
