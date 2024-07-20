using MediatR;

namespace CQRS_Project.CQRS.Commands
{
    public class CreateStudentCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
