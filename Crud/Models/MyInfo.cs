using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class MyInfo
    {
        [Key]
        public int ID { get; set; }
        public int Task_ID { get; set; }
        public int Emp_ID { get; set; }

        public string Task_Name { get; set; }
        public string Emp_Name { get; set; }

        public List<SelectListItem> ItemList { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modify_Date { get; set; }
        public string Response { get; set; }
        public bool Active { get; set; }
    }
}
