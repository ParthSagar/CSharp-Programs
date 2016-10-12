using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstWebApplication.Entities;
using FirstWebApplication.Models;
using FirstWebApplication.Services;
using MongoDB.Bson;

namespace FirstWebApplication.Controllers
{
    public class PlayerController :Controller
    {
         public ActionResult AddScore(string playerId, string gameId, string gameName)
        {
            var playerService = new PlayerService();
            var score = new Score
            {
                GameId = new ObjectId(gameId),
                GameName = gameName,
                ScoreDateTime = DateTime.Now,
                //// Generate a random score
                ScoreValue = new Random().Next(0, Int32.MaxValue)
            };
 
            playerService.AddScore(playerId, score);
            
            return RedirectToAction("Details", new { id = playerId});
        }
 
        //
        // GET: /Player/Create
 
        public ActionResult Create()
        {
            return View(new Player());
        }
 
        //
        // POST: /Player/Create
 
        [HttpPost]
        public ActionResult Create(Player player)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var playerService = new PlayerService();
                    playerService.Create(player);
                    return RedirectToAction("Index");
                }
 
                return View();
            }
            catch
            {
                return View();
            }
        }
 
        //
        // GET: /Player/Delete/514b46581cbfe31ad86ec630
 
        /*public ActionResult Delete(string id)
        {
            var playerService = new PlayerService();
            var player = playerService.GetById(id);
            return View(player);
        }*/
 
        //
        // POST: /Player/Delete/514b46581cbfe31ad86ec630
 
        [HttpPost]
        /*public ActionResult Delete(Player player)
        {
            try
            {
                var playerService = new PlayerService();
                playerService.Delete(player.Id.ToString());
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
 
        //
        // GET: /Player/Details/514b46581cbfe31ad86ec630
 
        public ActionResult Details(string id)
        {
            var playerService = new PlayerService();
            var player = playerService.GetById(id);
 
            return View(player);
        }
 
        //
        // GET: /Player/Edit/514b46581cbfe31ad86ec630
 
        public ActionResult Edit(string id)
        {
            var playerService = new PlayerService();
            var player = playerService.GetById(id);
 
            return View(player);
        }
 
        //
        // POST: /Player/Edit/514b46581cbfe31ad86ec630
 
        [HttpPost]
        public ActionResult Edit(Player player)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var playerService = new PlayerService();
                    playerService.Update(player);
                    return RedirectToAction("Index");
                }
 
                return View();
            }
            catch
            {
                return View();
            }
        }
 
        //
        // GET: /Player/
 
        public ActionResult Index()
        {
            var playerService = new PlayerService();
            var playersDetails = playerService.GetPlayersDetailes(100, 0);
 
            return View(playersDetails);
        }
 
        //
        // GET: /Player/PlayGames/514b46581cbfe31ad86ec630
 
        public ActionResult PlayGames(string id)
        {
            var playerService = new PlayerService();
            var player = playerService.GetById(id);
            var gameService = new GameService();
            var availableGames = gameService.GetGamesDetails(100, 0);
 
            var playerGames = new PlayerGames()
            {
                Player = player,
                AvailableGames = new List<Game>(availableGames)
            };
 
            return View(playerGames);
        }
 
    }
}
