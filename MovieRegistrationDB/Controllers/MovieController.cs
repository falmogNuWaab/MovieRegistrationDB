using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieRegistrationDB.Models;
using Dapper;
using MySqlConnector;

namespace MovieRegistrationDB.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            Movie m = new Movie();
            return View(m);
        }
        [HttpPost]
        public IActionResult Index(Movie m)
        {
            if (ModelState.IsValid)
            {
                using (var connect = new MySqlConnection(Secret.Connection))
                {

                    string insertString = $"insert into movie values(0,@Title,@Gen,@releaseYear,@runtime)";
                    string queryString = $"select * from movie";

                    connect.Open();
                    connect.Execute(insertString, new
                    {
                        Title = m.Title,
                        Gen = m.Genre,
                        releaseYear = m.releaseYear,
                        Runtime = m.Runtime
                    });
                    List<Movie> inventory = connect.Query<Movie>(queryString).ToList();
                    connect.Close();

                    return RedirectToAction("List", "Movie");
                }
            }
            else
            {
                return View(m);
            }
        }

        public IActionResult List()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {

                
                string queryString = $"select * from movie";

                connect.Open();
                List<Movie> inventory = connect.Query<Movie>(queryString).ToList();
                connect.Close();
                return View(inventory);
            }
                
        }

    }
}
