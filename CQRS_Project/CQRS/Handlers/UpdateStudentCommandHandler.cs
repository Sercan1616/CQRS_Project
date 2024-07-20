using CQRS_Project.CQRS.Commands;
using CQRS_Project.Data;

namespace CQRS_Project.CQRS.Handlers
{
    public class UpdateStudentCommandHandler
    {
        private readonly StudentContext _studentContext;

        public UpdateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(UpdateStudentCommand command)
        {
            var updateStudent = _studentContext.Students.Find(command.Id);
            if (updateStudent != null) 
            {
                updateStudent.Name = command.Name;
                updateStudent.Surname = command.Surname;
                updateStudent.Age = command.Age;
            }            
            _studentContext.SaveChanges();
        }
    }
}
