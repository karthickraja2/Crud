using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;

namespace CrudMvc.Models
{
    public class Task
    {
        public int Task_ID { get; set; }
        public string Task_Name { get; set; }
        public string Description { get; set; }
        public DateTime Created_Date { get; set; }
       
        public DateTime Modify_Date { get; set; }
        public bool Active { get; set; }

        public string Type { get; set; }
    }
}
