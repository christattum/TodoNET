using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
using TodoNET.Helpers;
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

        public ActionResult Index(int? page, string sort, string sortdir)
        {
            using (var tx = Db.BeginTransaction())
            {
                ICriteria criteria = Db.CreateCriteria<Project>();

                var pagedProjects = PagedList<Project>.CreatePagedList(criteria, 5, page ?? 1, sort, sortdir);

                tx.Commit();

                return View(pagedProjects);
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            var project = new Project();
            return View(project);
        }

        [HttpPost]
        public ActionResult Create(Project formProject)
        {
            if (ModelState.IsValid)
            {
                using (var tx = Db.BeginTransaction())
                {
                    Db.Save(formProject);
                    tx.Commit();

                    return RedirectToAction("Index");
                }
            }

            return View(formProject);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var tx = Db.BeginTransaction())
            {
                var project = Db.Get<Project>(id);
                
                tx.Commit();

                if (project != null)
                {
                    return View(project);
                }

                return View("NotFound");

            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            using (var tx = Db.BeginTransaction())
            {
                var project = Db.Get<Project>(id);
                if (project != null)
                {
                    Db.Delete(project);
                    tx.Commit();
                    return RedirectToAction("Index");
                }

                return View("NotFound");

            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var tx = Db.BeginTransaction())
            {
                var project = Db.Get<Project>(id);

                tx.Commit();

                if (project != null)
                {
                    return View(project);
                }

                return View("NotFound");
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
