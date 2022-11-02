using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class Task
    {
        public int Task_ID { get; set; }
        [Required(ErrorMessage ="Enter the task name")]
        [DisplayName("Task Name")]
        public string Task_Name { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
     
        public string Description { get; set; }
        public DateTime Created_Date { get; set; }
        public List<SelectListItem> ItemList { get; set; }

        public string Response { get; set; }
        public DateTime Modify_Date { get; set; }
        public bool Active { get; set; }

        public string Type { get; set; }
    } 
}
