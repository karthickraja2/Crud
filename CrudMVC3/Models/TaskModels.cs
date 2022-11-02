using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CrudMvc.Models
{
    public class TaskModels
    {
        public int Task_ID { get; set; }

        [Required(ErrorMessage = "Enter the task name")]
        public string Task_Name { get; set; }
        [Required(ErrorMessage = "Enter the description")]
        public string Description { get; set; }
        public DateTime Created_Date { get; set; }
       
        public DateTime Modify_Date { get; set; }
        public bool Active { get; set; }

        public string Type { get; set; }
    }
}
