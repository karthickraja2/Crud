 using Crud.Controllers;
using Crud.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Task = Crud.Models.Task;

namespace CrudMVC3.Controllers
{
    public class TasksController : Controller
    {
        db dbop = new db();
        string msg = string.Empty;
        public readonly List<Task> list;
        public TasksController()
        {
            list = _services.Get();
        }
        TaskController _services = new TaskController();

        // GET: TaskController
        public ActionResult Index()
        {
            /* List<CrudMvc.Models.EmployeeModels> emp = new List<Models.EmployeeModels>();*/
            var tsk = _services.Get();

            return View(tsk.ToList());
        }

        public ActionResult TaskList([DataSourceRequest] DataSourceRequest request)
        {
            var task = _services.Get();
            return Json(task.ToDataSourceResult(request));
        }

        // GET: TaskController/Create
        public ActionResult Create(string response)
        {

            Task task = new Task();
            task.Response = response;
            return View(task);

            return RedirectToAction("Index");
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Task tsk)
        {
            try
            {
                var flag = "";
                tsk.Response = "";
                foreach (var items in list)
                {
                    if (items.Task_Name == tsk.Task_Name)
                    {
                        flag = "1";
                    }

                }
                if (flag == "1")
                {
                    tsk.Response = "This Task Already given to Someone";
                    return RedirectToAction("Create", new { Response = tsk.Response });
                }
                else
                {
                    var task = _services.Post(tsk);
                    if (task != null)
                    {
                        return RedirectToAction("Index");

                    }
                    return View();

                }

                return View(tsk);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Edit(int id )
        {



            try
            {

                var task = new Task();
                task.Task_ID = id;
                DataSet ds = dbop.getTaskById(task,out msg);
                List<Task> list = new List<Task>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {


                    task.Task_ID = Convert.ToInt32(dr["Task_ID"]);
                    task.Task_Name = dr["Task_Name"].ToString();
                    task.Description = dr["Description"].ToString();



                }


                return View(task);

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }



        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Task tsk)
        {
            try
            {
                var emp = _services.Put(id, tsk);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }



        }





        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var tsk = _services.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return View();
        }
    }
}
