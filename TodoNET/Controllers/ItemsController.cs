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
        // TODO: pull out all the NHib querying stuff into ItemsService
        // every controller which needs projecting data into view models etc.
        // will use its own service.  This is better than trying to write repositories which serve mtuliple use cases
        // as they become fat and bloated

        public ISession Db { get; private set; }

        public ItemsController(ISession session)
        {
            Db = session;
        }

        public ActionResult Index(int projectId, int? page, string sort, string sortdir)
        {
            using (var tx = Db.BeginTransaction())
            {
                ICriteria criteria = Db.CreateCriteria<Item>()
                    .Add(Restrictions.Eq("Project.Id", projectId));

                var pagedItems = PagedList<Item>.CreatePagedList(criteria, 5, page ?? 1, sort, sortdir);

                tx.Commit();

                return View(pagedItems);
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var tx = Db.BeginTransaction())
            {
                var item = Db.Get<Item>(id);
                tx.Commit();

                return View(item);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Item formItem)
        {
            if (ModelState.IsValid)
            {
                using (var tx = Db.BeginTransaction())
                {
                    var item = Db.Get<Item>(id);
                    if (item != null)
                    {
                        item.Summary = formItem.Summary;
                        item.CompletedDate = formItem.CompletedDate;
                        item.Detail = formItem.Detail;

                        Db.Update(item);
                        tx.Commit();

                        return RedirectToAction("Index", new {projectid = item.Project.Id});
                    }
                }

            }

            return View(formItem);
        }


    }
}
