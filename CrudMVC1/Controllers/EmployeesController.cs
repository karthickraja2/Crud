using Crud.Controllers;
using Crud.Models;
using CrudMvc.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace CrudMVC1.Controllers
{
    public class EmployeesController : Controller
    {
        db dbop = new db();
        string msg = string.Empty;
        public readonly List<Employee> list;
        public EmployeesController()
        {
            list = _services.Get();
        }
        EmployeeController _services = new EmployeeController();
        /* public EmployeesController(EmployeeController services)
         {
             _services = services;

         }*/
        // GET: EmployeeController
        public ActionResult Index()
        {
            /* List<CrudMvc.Models.EmployeeModels> emp = new List<Models.EmployeeModels>();*/
            var emp = _services.Get();

            return View(emp.ToList());
        }

        public ActionResult EmployeeList([DataSourceRequest] DataSourceRequest request)
        {
            var emp = _services.Get();
            return Json(emp.ToDataSourceResult(request));
        }

        // GET: EmployeeController/Details/5

        public ActionResult Details(int id)
        {
            var emp = new Employee();
            emp.ID = id;
            emp.Type = "getID";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            Employee list = new Employee();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                emp.ID = Convert.ToInt32(dr["ID"]);
                emp.Email = dr["Email"].ToString();
                emp.Emp_Name = dr["Emp_Name"].ToString();
                emp.Designation = dr["Designation"].ToString();


            }

            return View(emp);
        }
        /*  public ActionResult Details(int id)
          {
              var emp = _services.Get(id);
              return View(emp);

          }
  */
        // GET: EmployeeController/Create
        public ActionResult Create(string response)
        {



            Employee employee = new Employee();
            employee.Response = response;



            var data = new List<EmployeeModels> {
            new EmployeeModels { ID=1, Designation="HR"},
            new EmployeeModels { ID=2, Designation="Sales Department"},
            new EmployeeModels { ID=3, Designation="senior Engineer"},
            new EmployeeModels { ID=4, Designation="Engineer" },
            new EmployeeModels { ID=5, Designation="Trainee Engineer"},
            new EmployeeModels { ID=6, Designation="Testing"},

            };

            employee.ItemList = data.Select(x => new SelectListItem { Text = x.Designation, Value = x.ID.ToString() }).ToList();
            return View(employee);
        
            return RedirectToAction("Index");


        }


        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Employee emp)
        {
            try
            {
                var flag = "";
                emp.Response = "";
                foreach (var items in list)
                {
                    if (items.Email == emp.Email)
                    {
                        flag = "1";
                    }

                }
                if (flag == "1")
                {
                    emp.Response = "Email Already exists";
                    return RedirectToAction("Create", new { Response = emp.Response });
                }
                else
                {
                    var employee = _services.Post(emp);
                    if (employee != null)
                    {
                        return RedirectToAction("Index");

                    }
                    return View();

                }

                return View(emp);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = new Employee();
            emp.ID = id;
            emp.Type = "getID";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            Employee list = new Employee();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                emp.ID = Convert.ToInt32(dr["ID"]);
                emp.Email = dr["Email"].ToString();
                emp.Emp_Name = dr["Emp_Name"].ToString();
                emp.Designation = dr["Designation"].ToString();


            }

            return View(emp);
        }



        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Employee emp)
        {
            try
            {
                var flag = "";
                emp.Response = "";
                foreach (var items in list)
                {
                    if (items.Email == emp.Email)
                    {
                        flag = "1";
                    }

                }
                if (flag == "1")
                {
                    emp.Response = "Email Already exists";
                    return RedirectToAction("Create", new { Response = emp.Response });
                }
                else
                {
                    var employee = _services.Post(emp);
                    if (employee != null)
                    {
                        return RedirectToAction("Index");

                    }
                    return View();

                }

                return View(emp);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = new Employee();
            emp.ID = id;
            emp.Type = "getID";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            Employee list = new Employee();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                emp.ID = Convert.ToInt32(dr["ID"]);
                emp.Email = dr["Email"].ToString();
                emp.Emp_Name = dr["Emp_Name"].ToString();
                emp.Designation = dr["Designation"].ToString();
            }
            return View(emp);
        }


        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var emp = _services.Delete(id);
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
