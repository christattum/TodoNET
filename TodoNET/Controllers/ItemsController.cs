using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Criterion;
using TodoNET.Helpers;
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
          
            // paging
            int maxResults = 5;
            int firstResult = 5*((page ?? 1) - 1);


            IList<Item> items = Db.CreateCriteria<Item>()
                                    .Add(Restrictions.Eq("Project.Id", projectId))
                                    .SetFirstResult(firstResult)
                                    .SetMaxResults(maxResults)
                                    .List<Item>();


            int rowCount = Db.CreateCriteria<Item>()
                                    .Add(Restrictions.Eq("Project.Id", projectId))
                                    .SetProjection(Projections.RowCount())
                                    .UniqueResult<int>();

            if (items != null)
            {

                var pagedItems = new PagedList<Item>(items, rowCount);

                return View(pagedItems);
            }

            return Content("Not found!");
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
