using MyAttendance.Models.Components;
using MyAttendance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAttendance.Controllers
{
    [Authorize]
    public class StandardController : Controller
    {
        // GET: Standard
        IRepository<Standard> _stdContext;
        public StandardController(IRepository<Standard> _stdContext)
        {
            this._stdContext = _stdContext;
        }
        public ActionResult Index()
        {
            var standards = _stdContext.Collection();
            return View(standards);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Standard model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                if (model != null)
                {
                    _stdContext.Insert(model);
                    _stdContext.Commit();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }
        public ActionResult Edit(int Id)
        {
            return View();
        }

        

    }
}