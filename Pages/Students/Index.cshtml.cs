using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsWebApplication.Service;
using StudentsWebApplication.Model;

namespace StudentsWebApplication.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentService service;

        public List<Student> Students { get; set; } = new();
        public string? ErrorMessage { get; set; }


        public IndexModel(IStudentService service)
        {
            this.service = service;
        }

        public void OnGet()
        {
            ErrorMessage = "";

            try
            {
                Students = service.GetAllStudents();
                // return Page();    
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                //return;
                Response.Redirect("/Error");
            }
        }
    }
}
