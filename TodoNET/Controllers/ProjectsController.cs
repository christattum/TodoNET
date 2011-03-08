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
        public ActionResult Edit(int id, Project formProject)
        {
            if (ModelState.IsValid)
            {
                var project = Db.Get<Project>(id);
                if (project != null)
                {
                    project.Name = formProject.Name;
                    project.Description = formProject.Description;

                    var tx = Db.BeginTransaction();

                    Db.Update(project);

                    tx.Commit();

                    return RedirectToAction("Index");
                }
            
            }

            return View(formProject);
        }

    }
}
