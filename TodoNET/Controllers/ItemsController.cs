using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
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

        public ActionResult Index()
        {
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
