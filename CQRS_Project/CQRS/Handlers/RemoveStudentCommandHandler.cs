using CQRS_Project.CQRS.Commands;
using CQRS_Project.Data;

namespace CQRS_Project.CQRS.Handlers
{
    public class RemoveStudentCommandHandler
    {
        private readonly StudentContext _studentContext;

        public RemoveStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(RemoveStudentCommand command) 
        {
            var deleteStudent = _studentContext.Students.Find(command.Id);  
            _studentContext.Students.Remove(deleteStudent);
            _studentContext.SaveChanges();
        }
    }
}
