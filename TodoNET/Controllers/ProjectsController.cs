using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
using TodoNET.Model;

namespace TodoNET.Controllers
{
    public class ProjectsController : Controller
    {
        public ISession Db { get; private set; }

        public ProjectsController(ISession session)
        {
            Db = session;
        }

        public ActionResult Index(int? page)
        {
            using (var tx = Db.BeginTransaction())
            {
                ICriteria criteria = Db.CreateCriteria<Project>();
                IList<Project> items = criteria.List<Project>();

                tx.Commit();

                return View(items);
            }

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var tx = Db.BeginTransaction())
            {
                var item = Db.Get<Project>(id);

                tx.Commit();

                return View(item);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Project formProject)
        {
            if (ModelState.IsValid)
            {
                using (var tx = Db.BeginTransaction())
                {
                    var project = Db.Get<Project>(id);
                    if (project != null)
                    {
                        project.Name = formProject.Name;
                        project.Description = formProject.Description;

                        Db.Update(project);
                        tx.Commit();

                        return RedirectToAction("Index");
                    }

                }

            }

            return View(formProject);
        }

    }
}
