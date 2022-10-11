using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Crud.Models
{
    public class MyTaskInfo
    {
        public int ID { get; set; }
        public string Task_Name { get; set; }
        public string Emp_Name { get; set; }

        public List<SelectListItem> ItemList { get; set; }

        public int Task_ID { get; set; }
        public int Emp_ID { get; set; }
        public int Name { get; set; }

    }
}
