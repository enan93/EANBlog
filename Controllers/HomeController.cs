using BlogProject42020.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BlogProject42020.Helpers;

namespace BlogProject42020.Controllers
{
   [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SearchHelper searchHelper = new SearchHelper();
        public ActionResult Index(int? page, string searchStr)
        {
            ViewBag.Search = searchStr;
            var blogList = searchHelper.IndexSearch(searchStr);
            int pageSize = 3;
            int pageNumber = page ?? 1;
            return View(blogList.Where(bp => bp.IsPublished).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(Email model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: <bold>{0}</bold>({1})</p><p>Message:</p><p>{2}</p>";
                    var from = $"Ethan A. Nance <{WebConfigurationManager.AppSettings["emailfrom"]}>";
                    //model.Body = "This is a message from your portfolio site. The name and the email of the contacting person is above.";

                    var email = new MailMessage(from, WebConfigurationManager.AppSettings["emailto"])
                    {
                        Subject = $"{model.Subject}",
                        Body = string.Format(body, model.FromName, model.FromEmail, model.Body),
                        IsBodyHtml = true
                    };
                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);

                    return View(new Email());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }

        public ActionResult Contact()
        {
            Email model = new Email();

            return View();
        }
    }
}