using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentsWebApplication.DTO;
using StudentsWebApplication.Service;
using StudentsWebApplication.Validator;

namespace StudentsWebApplication.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentService studentService;
        public string ErrorMessage { get; set; } = "";
        public StudentDTO StudentDto { get; set; } = new StudentDTO();


        public CreateModel(IStudentService studentService)
        {
            this.studentService = studentService;
        }



        public void OnGet()
        {

        }

        public void OnPost()
        {
            
            

            

            try
            {
                StudentDto.Firstname = Request.Form["firstname"];
                StudentDto.Lastname = Request.Form["lastname"];

                ErrorMessage = StudentValidator.Validate(StudentDto);

                if (!ErrorMessage.Equals("")) return;

                studentService.InsertStudent(StudentDto);
                Response.Redirect("/Students/Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
