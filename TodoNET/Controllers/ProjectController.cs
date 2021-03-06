﻿using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
using TodoNET.Model;

namespace TodoNET.Controllers
{
    public class ProjectController : Controller
    {
        public ISession Db { get; private set; }

        public ProjectController(ISession session)
        {
            Db = session;
        }

        public ActionResult Index()
        {
            // using ICriteria
            ICriteria criteria = Db.CreateCriteria<Project>();
            IList<Project> items = criteria.List<Project>();


            return View(items);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = Db.Get<Project>(id);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, Project formItem)
        {
            if (ModelState.IsValid)
            {
                var item = Db.Get<Project>(id);
                if (item != null)
                {

                    var tx = Db.BeginTransaction();

                    Db.Update(item);

                    tx.Commit();

                    return RedirectToAction("Index");
                }
            
            }

            return View(formItem);
        }

    }
}
