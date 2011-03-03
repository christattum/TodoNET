﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
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
            // using linq
            //var query = Db.Query<Item>();
            //IList<Item> items = query.ToList();

            // using ICriteria
            ICriteria criteria = Db.CreateCriteria<Item>();
            IList<Item> items = criteria.List<Item>();


            return View(items);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = Db.Get<Item>(id);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, Item formItem)
        {
            if (ModelState.IsValid)
            {
                var item = Db.Get<Item>(id);
                if (item != null)
                {
                    item.Summary = formItem.Summary;
                    item.CompletedDate = formItem.CompletedDate;
                    item.Detail = formItem.Detail;

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
