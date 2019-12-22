using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShareMVC.Models.ViewComponent
{
    //must end with viewComponent
    //must be decorated with view component 
    //or must extend view component base class
    [ViewComponent]
    public class MonthlySpecialsViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {

        private readonly PlayerDataContext db;

        public MonthlySpecialsViewComponent(PlayerDataContext db)
        {
            this.db = db;
        }
        //public string Invoke()
        public IViewComponentResult Invoke()
        {
            var specials = db.MonthlySpecials.ToArray();
            //return "TODO: show monthly specials";
            return View(specials);
        }

    }
}
