using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Criterion;
using TodoNET.Model;

namespace TodoNET.Controllers
{
    public class ItemsController : Controller
    {
         public ISession Db { get; private set; }

        public ItemsController(ISession session)
        {
            Db = session;
        }

        public ActionResult Index(int projectId, int? page)
        {
            // read the project and lazy load the items
            //var project = Db.Get<Project>(projectId);
            //IEnumerable<Item> items = project.Items;

            // paging
            int maxResults = 5;
            int firstResult = 5*((page ?? 1) - 1);

            // TODO: We need to pass throught he total number of items though, not just in the collection

            // This loads the project and all items in one go rather than lazily
            var project = Db.CreateCriteria<Project>()
                .SetFetchMode("Items", FetchMode.Eager)
                .SetMaxResults(maxResults)
                .SetFirstResult(firstResult)
                .Add(Restrictions.Eq("Id", projectId))
                .UniqueResult<Project>();

            if (project != null)
            {

                var items = project.Items;

                return View(items);
            }
            else
            {
                return Content("Not found!");
            }
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
