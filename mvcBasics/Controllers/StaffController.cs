using Microsoft.AspNetCore.Mvc;
using mvcBasics.Models;

namespace mvcBasics.Controllers
{
    public class StaffController : Controller
    {
        StaffContext db = new StaffContext();
        public IActionResult Index()
        {
            return View(StaffContext.staffObject);
        }
        public IActionResult Details(int id)
        {
            Staff temp = StaffContext.staffObject.Where(x => x.Id == id).FirstOrDefault();
            return View(temp);
        }
        public IActionResult Edit(int id)
        {
            Staff temp = StaffContext.staffObject.Where(x => x.Id == id).FirstOrDefault();
            return View(temp);
        }
        [HttpPost]
        public IActionResult Edit(Staff temp)
        {
            Staff data = temp;
            if (data.Id < 0 || data.Name == null || data.Password == null
                || data.Dob == null || data.Title == null)
            {
                ViewBag.Error = "Please don't be simple:)";
                return View();
            }
            else
            {
                (from p in StaffContext.staffObject
                 where p.Id == data.Id
                 select p).ToList().ForEach(x =>
                 {
                     x.Password = data.Password;
                     x.Dob = data.Dob;
                     x.Title = data.Title;
                     x.Name = data.Name;
                 });
                return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int id)
        {
            Staff temp = StaffContext.staffObject.Where(x => x.Id == id).FirstOrDefault();
            return View(temp);
        }
        [HttpPost]
        public IActionResult Delete(Staff temp)
        {
            StaffContext.staffObject = StaffContext.staffObject.Where(x => x.Id != temp.Id).ToList();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Staff temp)
        {
            Staff data = temp;
            if (data.Id < 0 || data.Name == null || data.Password == null
                || data.Dob == null || data.Title == null)
            {
                ViewBag.Error = "Please don't be simple:)";
                return View();
            }
            else
            {
                StaffContext.staffObject.Add(data);
                return RedirectToAction("Index");
            }
        }
    }
}
