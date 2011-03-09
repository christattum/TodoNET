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

            ICriteria criteria = Db.CreateCriteria<Item>()
                                    .Add(Restrictions.Eq("Project.Id", projectId));

            var pagedItems = new PagedList<Item>(criteria, 5, page ?? 1);

            return View(pagedItems);
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
