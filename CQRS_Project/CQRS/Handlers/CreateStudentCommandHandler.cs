using CQRS_Project.CQRS.Commands;
using CQRS_Project.Data;

namespace CQRS_Project.CQRS.Handlers
{
    public class CreateStudentCommandHandler
    {
        private  readonly StudentContext _studentContext;

        public CreateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(CreateStudentCommand command)
        {
            _studentContext.Students.Add(new Student{ Age = command.Age, Name = command.Name, Surname = command.Surname });
            _studentContext.SaveChanges();
        }
    }
}
