using CQRS_Project.CQRS.Commands;
using CQRS_Project.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS_Project.CQRS.Handlers
{
    public class CreateStudentCommandHandler :IRequestHandler<CreateStudentCommand>
    {
        private  readonly StudentContext _studentContext;

        public CreateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        /// <summary>
        /// Mediatr olmadan kullanılan yöntem
        /// </summary>
        //public void Handle(CreateStudentCommand command)
        //{
        //    _studentContext.Students.Add(new Student{ Age = command.Age, Name = command.Name, Surname = command.Surname });
        //    _studentContext.SaveChanges();
        //}

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            await _studentContext.Students.AddAsync(new Student { Age = request.Age, Name = request.Name, Surname = request.Surname });
            _studentContext.SaveChanges();
            return Unit.Value;
        }
    }
}
