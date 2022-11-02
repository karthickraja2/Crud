using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CrudMvc.Models
{
    public class Task
    {
        [Key]
        public int Task_ID { get; set; }
        [Required]
        [DisplayName("Task Name")]
        public string Task_Name { get; set; }
        [Required(ErrorMessage = "Enter the description")]
        public string Description { get; set; }
        public DateTime Created_Date { get; set; }
       
        public DateTime Modify_Date { get; set; }
        public bool Active { get; set; }

        public string Type { get; set; }
    }
}
