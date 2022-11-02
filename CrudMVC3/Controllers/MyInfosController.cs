using Crud.Controllers;
using Crud.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVC3.Controllers
{
    public class MyInfosController : Controller
    {
        db dbop = new db();
        string msg = string.Empty;
        public readonly List<MyTaskInfo> list;


      
        public MyInfosController()
        {
            list = _services.Get();
        }
        MyInfoController _services = new MyInfoController();
        TaskController _service = new TaskController();
        EmployeeController _ser = new EmployeeController();

        // GET: TaskController
        public ActionResult Index()
        {
           
            var mi = _services.Get();

            return View(mi.ToList());
        }

        public ActionResult MyInfoList([DataSourceRequest] DataSourceRequest request)
        {
            var myin = _services.Get();
            return Json(myin.ToDataSourceResult(request));
        }

        // GET: TaskController/Create
        public ActionResult Create(string response)
        {

            MyInfo myin = new MyInfo();
            myin.Response = response;
            return View(myin);

            return RedirectToAction("Index");
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, MyInfo myin)
        {
            try
            {
                var flag = "";
                myin.Response = "";
                foreach (var items in list)
                {
                    var itemsarry = items.Task_Name.ToString().Split(",").ToList();
                    if (itemsarry.Contains( myin.Task_Name))
                    {
                        flag = "1";
                        break;
                    }

                }
                if (flag == "1")
                {
                    myin.Response = "This Task Already given to Someone";
                    return RedirectToAction("Create", new { Response = myin.Response });
                }
                else
                {
                    List<string> result = myin.Task_Name.Split(',').ToList();

                    foreach (var task in result)
                    {
                        _services.Post(new MyInfo() { Emp_Name = myin.Emp_Name, Task_Name = task });

                    }
                    return RedirectToAction("Index");

                }

                return View(myin);
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
                var mi = _services.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return View();
        }

        public JsonResult AutocompleteTaskName(DropDown dropDown, [DataSourceRequest] DataSourceRequest request )
        {
            var Task_Name = dropDown.Task_Name;

            List<DropDown> output = new List<DropDown>();
            output = _service.Get().Select(selector: s => new DropDown()
                {
                Task_Name = s.Task_Name,
                Name= s.Task_Name

            }).ToList();
            return Json(output);
        }


        public JsonResult AutocompleteEmpName(DropDown dropDown, [DataSourceRequest] DataSourceRequest request)
        {
            var Emp_Name = dropDown.Emp_Name;

            List<DropDown> output = new List<DropDown>();
            output = _ser.Get().Select(selector: s => new DropDown()
            {
                Emp_Name = s.Emp_Name,
                Name = s.Emp_Name

            }).ToList();
            return Json(output);
        }

    }
}
