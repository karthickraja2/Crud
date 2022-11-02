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
    public class MyInfoController : ControllerBase
    {
        db dbop = new db();
        string msg = string.Empty;

        // GET: api/<MyInfoController>
        [HttpGet]
        public List<MyTaskInfo> Get()
        {
            MyTaskInfo mi = new MyTaskInfo();
            DataSet ds = dbop.MyInfoGet(mi, out msg);
            List<MyTaskInfo> list = new List<MyTaskInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new MyTaskInfo
                {
                    Emp_ID  = Convert.ToInt32(dr["Emp_ID"]),
                    Emp_Name = dr["Emp_Name"].ToString(),
                    Task_Name = dr["Task_Name"].ToString(),

                });
            }
            return list;
        }



        // GET api/<MyInfoController>/5
        [HttpGet("{id}")]
        public MyTaskInfo Get(int id)
        {
            MyTaskInfo mi = new MyTaskInfo();
            mi.ID = id;
            DataSet ds = dbop.MyInfoGet(mi, out msg);
            MyTaskInfo list = new MyTaskInfo();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                /* list.Add(new Employee
                 {*/
                list.Emp_ID = Convert.ToInt32(dr["Emp_ID"]);
                list.Task_Name = dr["Task_Name"].ToString();
                list.Emp_Name = dr["Emp_Name"].ToString();
                //list.Created_Date = DateTime.Now;
                //list.Modify_Date = DateTime.UtcNow;


                /*   });*/
            }
            return list;
        }


        // POST api/<TaskController>
        [HttpPost]
        public string Post([FromBody] MyInfo mi)
        {
            string msg = string.Empty;
            try
            {
                msg = dbop.CreateMyInfo(mi);
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
                MyInfo mi = new MyInfo();
                mi.Emp_ID = id;

                msg = dbop.DeleteMyInfo(mi);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
