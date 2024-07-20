using CQRS_Project.CQRS.Commands;
using CQRS_Project.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS_Project.CQRS.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public UpdateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        /// <summary>
        /// Mediatr olmadan kullanılan yöntem
        /// </summary>
        //public void Handle(UpdateStudentCommand command)
        //{
        //    var updateStudent = _studentContext.Students.Find(command.Id);
        //    if (updateStudent != null) 
        //    {
        //        updateStudent.Name = command.Name;
        //        updateStudent.Surname = command.Surname;
        //        updateStudent.Age = command.Age;
        //    }            
        //    _studentContext.SaveChanges();
        //}

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updateStudent = await _studentContext.Students.FindAsync(request.Id);
            if (updateStudent != null)
            {
                updateStudent.Name = request.Name;
                updateStudent.Surname = request.Surname;
                updateStudent.Age = request.Age;
            }
            _studentContext.SaveChanges();
            return Unit.Value;
        }
    }
}
