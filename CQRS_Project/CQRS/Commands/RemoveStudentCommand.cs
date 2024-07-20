using CQRS_Project.Data;
using MediatR;
using System.Runtime.CompilerServices;

namespace CQRS_Project.CQRS.Commands
{
    public class RemoveStudentCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveStudentCommand(int id)
        {
            Id = id;
        }
    }
}
