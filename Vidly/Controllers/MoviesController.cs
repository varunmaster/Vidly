using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { _Name = "Bourne Identity", _ID = 1, _Director = "IDK who the director is", _YearReleased = 2004}; //coming from the Movie class in Models

            ///The class MoviesController is inheriting from Controller which has these ActionResult and we are
            ///overriding the methods
            /// ActionResult has many different subtypes:
            ///
            ///+--------------------------------------------+
            ///|Type                    | HelperMethod      |
            ///|________________________|___________________|
            ///|ViewResult              | View()            | --> Most Common
            ///|PartialViewResult       | PartialView()     | --> Partial View
            ///|ContentResult           | Content()         | --> Return simple text
            ///|RedirectResult          | Redirect()        | --> redirect to url    
            ///|RedirectToRouteResult   | RedirectToAction()| --> redircect action
            ///|JsonResult              | Json()            | --> return serialized json
            ///|FileResult              | File()            | --> return file
            ///|HttpNotFoundResult      | HttpNotFound()    | --> return 404
            ///|EmptyResult             | n/a               | --> return nothing
            ///|________________________|___________________|
            
            return View(movie);
            //return Content("Returning simple text");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index","Home", new {page = 1, sortBy="name"}); //(Action, Controller, 
                                                                                      //anon obj)
        }

        /// <summary>
        /// +-------+      +-------------+      +------+
        /// |Request| ---> |MVC Framework| ---> |Action|
        /// +-------+      +-------------+      +------+
        /// 
        /// Here we are creating a request (or a page) called Edit that takes in a parameter (ID in this case)
        /// that the controller (MVC) will then call an action (ActionResult [content]). The parameter (ID) 
        /// can be in 3 formats:
        ///     * URL:              /movies/edit/1
        ///     * query string:     /movies/edit?ID=1
        ///     * form data:        ID=1
        /// Go to: localhost:58907/Movies/Edit?ID=1 || localhost:58907/Movies/Edit/1
        /// The parameter name "ID" must be in the URL or you get error. Try localhost:58907/Movies/Edit?movieID=1
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult Edit(int ID)
        {
            return Content("ID = " + ID);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            //creating defaults in event that params are not passed in
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrEmpty(sortBy))
                sortBy = "Name";

            //localhost:58907/Movies/Index?pageIndex=25&sortBy=%22Name%22 
            //localhost:58907/Movies
            return Content(string.Format("pageIndex={0}, sortBy={1}", pageIndex, sortBy));
        }

        public ActionResult ByReleaseDate(int year, int? month)
        {
            return Content(year + "/" + month);
        }
    }
}