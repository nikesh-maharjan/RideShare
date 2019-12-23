using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RideShareMVC.Models;
using RideShare.LLBLGEN.EntityClasses;
using RideShare.LLBLGEN.TypedListClasses;
using RideShare.LLBLGEN.TypedViewClasses;


namespace RideShareMVC.Controllers
{
    //[Route("rideshare")]
    //[Route("Users")]
    public class UsersController : Controller
    {
        private RideShareContext _context;
        private readonly PlayerDataContext _PlayerDb;
        public UsersController(RideShareContext context, PlayerDataContext playerDb)
        {
            _context = context;
            _PlayerDb = playerDb;
        }

        //[Route("..")]
        public IActionResult Index()
        {
            RideShare.LLBLGEN.EntityClasses.TblUser tblUser = new RideShare.LLBLGEN.EntityClasses.TblUser();
            
            return View(_context.TblUser.ToList());
        }

        public IActionResult Details(Guid? id)
        {
            dynamic myModel = new ExpandoObject();
            myModel.User = _context.Tbladdress.FirstOrDefault(m => m.UserGuid == id);
            myModel.Address = _context.TblUser.FirstOrDefault(m => m.UserGuid == id);
           
            
            //Data _dummyData = new Data();
            //ViewModelDemo vmDemo = new ViewModelDemo();
            //vmDemo.allCourses = _dummyData.GetAllCourse();
            //vmDemo.allDepartments = _dummyData.GetAllDepartment();
            //vmDemo.allEmployees = _dummyData.GetAllEmployee();
            //return View(vmDemo);

            return View(myModel);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //Actionresult type content demo
        public IActionResult Index1()
        {
            return View();
            //return new ContentResult { Content = "RideShare users" };
        }

        //using default value
        public IActionResult Index2(int id = -1)
        //int? is Nullable value that can be passed into the function
        //public IActionResult Index2(int? id)
        //public IActionResult Index2(string id)
        {
            return View();

            //if(id == null)
            //{
            //    return new ContentResult { Content = "null" };
            //}
            //else
            //{
                //return new ContentResult { Content = id.ToString() };
            //}
            //return new ContentResult { Content = id };
        }


        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult Player()
        {
            var player = new Player
            {
                Name = "Nikesh",
                Age = 30,
                Country = "USA"
            };
            return View(player);
        }

        [HttpGet, Route("Users/CreatePlayer")]
        public IActionResult CreatePlayer()
        {

            return View();
        }


        [HttpPost, Route("users/CreatePlayer")]
        public IActionResult CreatePlayer([Bind("Name","Age","Country","Comment")] Player player)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //player.Name =
            player.Rank = 1;
            player.Created = DateTime.Now;

            _PlayerDb.Players.Add(player);
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateRider()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateRider(Player rider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            rider.Country = "Nepal";
            rider.Rank = 1;
            rider.Created = DateTime.Now;

            _PlayerDb.Players.Add(rider);
            _PlayerDb.SaveChanges();

            //return View();
            return RedirectToAction(
                "Rider", "Users", new
                {
                    year = rider.Created.Year,
                    month = rider.Created.Month,
                    key = rider.Key
                });
        }

        public IActionResult DisplayRiders(int page = 0) 
        {
            var pageSize = 2;
            var totalPosts = _PlayerDb.Players.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;
            
            var players = _PlayerDb.Players
                .OrderByDescending(x => x.Created)
                .Skip(pageSize*page)
                .Take(pageSize)
                .ToArray();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView(players);

            return View(players);
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Rider(int year, int month, string key)
        {
            var player = _PlayerDb.Players.FirstOrDefault(x => x.Key == key);
            return View(player);
        }


        //[Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        //[Route("rideshare/{year:int}/{month:int}/{key}")]
        //public IActionResult Index3(int year, int month, string key)
        //{
        //return View();
        //return new ContentResult { Content = string.Format(
        //    "year: {0}; Month: {1}; Key: {2}", year, month, key)};
        //}
        
    }
}