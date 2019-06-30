using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudTest.Models;

namespace CrudTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return View(nameof(Index));
        }

        [HttpPost]
        public JsonResult List()
        {
            var _r = new Repository();
            return Json(_r.ListAll());
        }

        [HttpPost]
        public JsonResult Add([FromBody]Employee emp)
        {
            var _r = new Repository();
            return Json(_r.Add(emp));
        }
        [HttpPost]
        public JsonResult GetbyID(int ID)
        {
            var _r = new Repository();
            var emp = _r.ListAll().Find(x => x.EmpId == ID);
            return Json(emp);
        }

        [HttpPost]
        public JsonResult Update([FromBody]Employee data)
        {
            var _r = new Repository();
            return Json(_r.Update(data));
        }

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            var _r = new Repository();
            return Json(_r.Delete(ID));
        }
    }
}
