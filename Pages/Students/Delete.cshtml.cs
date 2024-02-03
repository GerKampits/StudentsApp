using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsWebApplication.DTO;
using StudentsWebApplication.Service;

namespace StudentsWebApplication.Pages.Students
{
    public class DeleteModel : PageModel
    {

        private readonly IStudentService studentService;
        public string ErrorMessage { get; set; } = "";
        public StudentDTO StudentDto { get; set; } = new StudentDTO();


        public DeleteModel(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public void OnGet()
        {

            try
            {
                int id = int.Parse(Request.Query["id"]);
                studentService.DeleteStudent(id);
                Response.Redirect("/Students/index");
            }
            catch (Exception e)
            {
                Response.Redirect("/Error");
            }
        }
    }
}
