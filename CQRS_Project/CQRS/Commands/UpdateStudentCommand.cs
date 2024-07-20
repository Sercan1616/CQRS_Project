using MediatR;

namespace CQRS_Project.CQRS.Commands
{
    public class UpdateStudentCommand : IRequest
    {
        public int Id { get; set; }

        public UpdateStudentCommand(int id)
        {
            Id = id;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
