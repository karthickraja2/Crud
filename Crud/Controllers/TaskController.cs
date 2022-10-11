using Crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        db dbop = new db();
        string msg = string.Empty;

        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Task> Get()
            {
            Task tsk = new Task();
            DataSet ds = dbop.TaskGet(tsk, out msg);
            List<Task> list = new List<Task>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Task
                {
                    Task_ID = Convert.ToInt32(dr["Task_ID"]),
                    Task_Name = dr["Task_Name"].ToString(),
                    Description = dr["Description"].ToString(),



                });
            }
            return list;
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public Task Get(int id)
        {
            Task tsk = new Task();
            tsk.Task_ID = id;
            DataSet ds = dbop.TaskGet(tsk, out msg);
            Task list = new Task();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                /* list.Add(new Employee
                 {*/
                list.Task_ID = Convert.ToInt32(dr["Task_ID"]);
                list.Task_Name = dr["Task_Name"].ToString();
                list.Description = dr["Description"].ToString();
                //list.Created_Date = DateTime.Now;
                //list.Modify_Date = DateTime.UtcNow;
                

                /*   });*/
            }
            return list;
        }


        // POST api/<TaskController>
        [HttpPost]
        public string Post([FromBody] Task tsk)
        {
            string msg = string.Empty;
            try
            {
                msg = dbop.CreateTask(tsk);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<TaskController>/5 
        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Task tsk)
        {
            string msg = string.Empty;
            try
            {
                tsk.Task_ID = id;
                msg = dbop.EditTask(tsk);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                Task tsk = new Task();
                tsk.Task_ID = id;
          

                msg = dbop.DeleteTask(tsk);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
