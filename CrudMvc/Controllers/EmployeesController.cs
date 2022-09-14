using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Crud.Controllers;
using System.Linq;
using System.Collections.Generic;
using Crud.Models;
using System.Data;
using System;

namespace CrudMvc.Controllers
{

    public class EmployeesController : Controller
    {
        db dbop = new db();
        string msg = string.Empty;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Employee emp)
        {
            var employee = _services.Post(emp);
            if (emp != null)
            {
                return RedirectToAction("Index");

            }
            return View();

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
            var employee = _services.Put(id, emp);
            if (emp != null)
            {
                return RedirectToAction("Index");

            }
            return View();
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

