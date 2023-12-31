using Beltek.HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beltek.HelloMVC.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("ListTeacher");
        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTeacher(Ogretmen ogt)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogretmenler.Add(ogt);
                ctx.SaveChanges();
            }
            return RedirectToAction("ListTeacher");
        }

        public IActionResult ListTeacher()
        {
            List<Ogretmen> lst;
            using (var ctx = new OkulDbContext())
            {
                lst = ctx.Ogretmenler.ToList();
            }

            return View(lst);
        }

        public IActionResult DeleteTeacher(string id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogtDel = ctx.Ogretmenler.FirstOrDefault(o => o.Tckimlik == id);

                if (ogtDel != null)
                {
                    ctx.Ogretmenler.Remove(ogtDel);
                    ctx.SaveChanges();
                    return RedirectToAction("ListTeacher");
                }

                return NotFound();
            }
        }


        public IActionResult UpdateTeacher(string tc)
        {
            Ogretmen ogt;
            using (var ctx = new OkulDbContext())
            {
                ogt = ctx.Ogretmenler.Find(tc);
            }
            return View(ogt);
        }

        [HttpPost]
        public IActionResult UpdateTeacher(Ogretmen ogt)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Entry(ogt).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("ListTeacher");
        }

    }
}