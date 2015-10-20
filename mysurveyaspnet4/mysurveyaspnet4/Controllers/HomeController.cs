using mysurveyaspnet4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mysurveyaspnet4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var survey = new SurveyAnswer()
            {
                SurveyId = "1",
                SurveyName = "FirstSurvey",
                EventDate = DateTime.Now,
                SurveyDate = DateTime.Now,
                Answers = new List<Answers>()
                {
                    new Answers()
                    {
                        QuestionId = 1,
                        SelectedAnswer = "myanswer"
                    }
                }
            };
            ViewBag.Message = "Your application description page.";
            return View(survey);
        }
        public ActionResult submitsurvey() {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}