using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_RNWA.Models;

namespace MVC_RNWA.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        CrudEmployee ci = new CrudEmployee();
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(ci.GetEmp());
        }

        // GET: Emp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Emp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(CrudEmp empinser)
        {

            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (ci.insertemp(empinser))
                    {
                        ViewBag.message = "Uspjesno dodan novi djelatnik";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ci.GetEmp().Find(itemodel => itemodel.employeeNumber == id));
        }

        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CrudEmp edittemp)
        {
            try
            {
                ci.editemp(edittemp);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
            ci.deleteemp(id);

            return RedirectToAction("Index");
        }

        // POST: Emp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
