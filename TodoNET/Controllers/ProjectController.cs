using System;
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

        //
        // GET: /Project/

        public ActionResult Index()
        {
            // pull the data directly from database
            //ICriteria criteria = Db.CreateCriteria<Item>();
            //IList<Item> items = criteria.List<Item>();

            // using linq
            var query = Db.Query<Item>();
            IList<Item> items = query.ToList();

            return View(items);
        }

    }
}
