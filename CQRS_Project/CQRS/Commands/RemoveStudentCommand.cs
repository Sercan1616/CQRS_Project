using CQRS_Project.Data;
using System.Runtime.CompilerServices;

namespace CQRS_Project.CQRS.Commands
{
    public class RemoveStudentCommand
    {
        public int Id { get; set; }

        public RemoveStudentCommand(int id)
        {
            Id = id;
        }
    }
}
