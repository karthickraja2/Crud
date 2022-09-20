using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CrudsMvc.Models
{
    public class EmployeesModels
    {
        public int ID { get; set; }
        [RegularExpression("[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Emp_Name { get; set; }
        public string Designation { get; set; }

        public List<SelectListItem> ItemList { get; set; }

        public string Type { get; set; }
    }
}
