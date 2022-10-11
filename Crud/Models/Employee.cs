using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class Employee
    {
        public int ID { get; set; }=0;
        [RegularExpression("[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; } = "";
        public string Emp_Name { get; set; } = "";
        public string Designation { get; set; } = "";
        /*  public string Created_date { get; set; }*/

        public List<SelectListItem> ItemList { get; set; }
        public string Response { get; set; }
        public string Type { get; set; } = "";

        public string Action { get; set; }
        public int Emp_ID{ get; set; }
      

    }
}
