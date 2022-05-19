using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Async_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetListAsync()
        {
            var watch = new Stopwatch();
            watch.Start();

            var country = GetCountryAsync();
            var state = GetStateAsync();
            var city = GetCityAsync();

            var count = await country;
            var stat = await state;
            var cit = await city;

            watch.Stop();
            ViewBag.WatchMilliSecondsElapsed = watch.ElapsedMilliseconds;
            return View();
        }

        public ActionResult GetList()
        {
            var watch = new Stopwatch();
            watch.Start();

            var country = GetCountry();
            var state = GetState();
            var city = GetCity();

            watch.Stop();
            ViewBag.WatchMilliSecondsElapsed = watch.ElapsedMilliseconds;
            return View();
        }

        #region --> GetCountry Methods for GetList && GetListAsync
        public string GetCountry()
        {
            Thread.Sleep(3000); //Use - when you want to block the current thread.
            return "India";
        } 

        public async Task<string> GetCountryAsync()
        {
            await Task.Delay(3000); //Use - when you want a logical delay without blocking the current thread.
            return "India";
        }
        #endregion


        #region --> GetState Methods for GetList && GetListAsync
        public string GetState()
        {
            Thread.Sleep(3000); //Use - when you want to block the current thread.
            return "GUJARAT";
        }

        public async Task<string> GetStateAsync()
        {
            await Task.Delay(3000); //Use - when you want a logical delay without blocking the current thread.
            return "GUJARAT";
        }
        #endregion

        #region --> GetCity Methods for GetList && GetListAsync
        public string GetCity()
        {
            Thread.Sleep(3000); //Use - when you want to block the current thread.
            return "Vadodara";
        }

        public async Task<string> GetCityAsync()
        {
            await Task.Delay(3000); //Use - when you want a logical delay without blocking the current thread.
            return "Vadodara";
        }
        #endregion

    }
}