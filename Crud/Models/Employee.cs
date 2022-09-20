using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace Crud.Models
{
    public class Employee
    {
        public int ID { get; set; }=0;
        public string Email { get; set; } = "";
        public string Emp_Name { get; set; } = "";
        public string Designation { get; set; } = "";
        /*  public string Created_date { get; set; }*/

        public List<SelectListItem> ItemList { get; set; }
        public string Response { get; set; }
        public string Type { get; set; } = "";

        public string Action { get; set; }
      

    }
}
