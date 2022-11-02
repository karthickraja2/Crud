using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks.Dataflow;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        db dbop = new db();
        string msg = string.Empty;

        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            Employee emp = new Employee();
            emp.Type = "get";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Email = dr["Email"].ToString(),
                    Emp_Name = dr["Emp_Name"].ToString(),
                    Designation = dr["Designation"].ToString(),
                });
            }
            return list;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            Employee emp = new Employee();
            emp.ID = id;
            emp.Type = "getID";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            Employee list = new Employee();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                /* list.Add(new Employee
                 {*/
                list.ID = Convert.ToInt32(dr["ID"]);
                list.Email = dr["Email"].ToString();
                list.Emp_Name = dr["Emp_Name"].ToString();
                list. Designation = dr["Designation"].ToString();

             /*   });*/
            }
            return list;
        }


        // POST api/<EmployeeController>
        [HttpPost]
        public string Post([FromBody] Employee emp)
        {
            string msg = string.Empty;
            try
            {
                msg = dbop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
               msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<EmployeeController>/5 
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public string Put(int id,[FromBody] Employee emp)
        {
            string msg = string.Empty;
            try
            {
                emp.ID = id;
                msg = dbop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    

            // DELETE api/<EmployeeController>/5
            [HttpDelete("{id}")]
            public string Delete(int id)
            {
                string msg = string.Empty;
                try
                {
                    Employee emp = new Employee();
                    emp.Emp_ID = id;
                    emp.Type = "delete";
                
                    msg = dbop.EmployeeOpt(emp);
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                return msg;
            }
        }
    }


