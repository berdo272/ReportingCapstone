using ReportingCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportingCapstone.Controllers
{
    [Authorize(Roles = "admin")]
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
            List<KeyValuePair<int, string>> sortKV = new List<KeyValuePair<int, string>>();

            List<string> Keys = new List<string>();
            List<int> Values = new List<int>();

            foreach (DownTimeType DTT in db.DownTimeTypes)
            {
                int durationTotal = 0;
                List<DownTimeEvent> Events = db.DownTimeEvents.Where(O => O.DownTimeTypeId == DTT.Id & O.Date.Month == DateTime.Now.Month).ToList();

                foreach (DownTimeEvent x in Events)
                {
                    durationTotal += x.Duration;
                }

                sortKV.Add(new KeyValuePair<int, string>(durationTotal, DTT.Description));

            }

            sortKV = sortKV.OrderByDescending(o => o.Key).ToList();

            foreach (KeyValuePair<int, string> x in sortKV)
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
            int daysInMonth = 0;

            switch (DateTime.Now.Month)
            {
                case 1:
                    daysInMonth = 31;
                    break;
                case 2:
                    if (DateTime.Now.Year % 4 == 0)
                    {
                        daysInMonth = 29;
                        break;
                    }
                    else
                    {
                        daysInMonth = 28;
                        break;
                    }
                case 3:
                    daysInMonth = 31;
                    break;
                case 4:
                    daysInMonth = 30;
                    break;
                case 5:
                    daysInMonth = 31;
                    break;
                case 6:
                    daysInMonth = 30;
                    break;
                case 7:
                    daysInMonth = 31;
                    break;
                case 8:
                    daysInMonth = 31;
                    break;
                case 9:
                    daysInMonth = 30;
                    break;
                case 10:
                    daysInMonth = 31;
                    break;
                case 11:
                    daysInMonth = 30;
                    break;
                case 12:
                    daysInMonth = 31;
                    break;

            }

            List<decimal> percentages = new List<decimal>();
            List<int> dates = new List<int>();
            List<DownTimeEvent> Events = db.DownTimeEvents.Where(o => o.Date.Month == DateTime.Now.Month).ToList();

            for(int i = 1; i <= daysInMonth; i++)
            {
                decimal dailyDowntimePercent = 0;

                foreach(DownTimeEvent dte in Events)
                {
                    if(dte.Date.Day == i)
                    {
                        dailyDowntimePercent += (dte.Duration / 435m);
                    }
                }

                dates.Add(DateTime.Now.Year);
                dates.Add((DateTime.Now.Month) - 1);
                dates.Add(i);

                percentages.Add(dailyDowntimePercent);
            }

            ViewBag.percentages = percentages;
            ViewBag.dates = dates;
            return View();
        }
    }
}