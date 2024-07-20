using CQRS_Project.CQRS.Commands;
using CQRS_Project.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Project.CQRS.Handlers
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public RemoveStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        /// <summary>
        /// Mediatr olmadan kullanılan yöntem
        /// </summary>
        /// 
        //public void Handle(RemoveStudentCommand command) 
        //{
        //    var deleteStudent = _studentContext.Students.Find(command.Id);  
        //    _studentContext.Students.Remove(deleteStudent);
        //    _studentContext.SaveChanges();
        //}

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var deleteStudent = await _studentContext.Students.FindAsync(request.Id);
            _studentContext.Students.Remove(deleteStudent);
            _studentContext.SaveChanges();
            return Unit.Value;
        }
    }
}
