using ReportingCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportingCapstone.Controllers
{
    public class ChartsController : Controller
    {
        private Models.ReportingCapstoneDBContext db = new Models.ReportingCapstoneDBContext();
        // GET: Charts
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Perato()
        {
            List<KeyValuePair<int,string>> sortKV = new List<KeyValuePair<int, string>>();

            List<string> Keys = new List<string>();
            List<int> Values = new List<int>();

            foreach(DownTimeType DTT in db.DownTimeTypes)
            {
                int durationTotal = 0;
                List<DownTimeEvent> Events = db.DownTimeEvents.Where(O => O.DownTimeTypeId == DTT.Id & O.Date.Month == DateTime.Now.Month).ToList();

                foreach(DownTimeEvent x in Events)
                {
                    durationTotal += x.Duration;
                }

                sortKV.Add(new KeyValuePair<int, string>( durationTotal, DTT.Description));            

            }

            sortKV = sortKV.OrderByDescending(o => o.Key).ToList();

            foreach(KeyValuePair<int,string> x in sortKV)
            {
                Values.Add(x.Key);
                Keys.Add(x.Value);
            }


            ViewBag.Values = Values;
            ViewBag.Keys = Keys;

            return View();
        }
        public ActionResult Trend()
        {

            List<DownTimeEvent> sortedEvents = db.DownTimeEvents.ToList();
            sortedEvents = sortedEvents.OrderBy(o => o.Date).ToList();


            List<decimal> percentages = new List<decimal>();
            List<int> dates = new List<int>();

            foreach (DownTimeEvent DTE in sortedEvents)
            {
                decimal dec = (DTE.Duration / 435m);

                percentages.Add((DTE.Duration / 435m));
                dates.Add(DTE.Date.Year);
                dates.Add((DTE.Date.Month) - 1);
                dates.Add(DTE.Date.Day);
            }

            ViewBag.percentages = percentages;
            ViewBag.dates = dates;
            return View();
        }
    }
}