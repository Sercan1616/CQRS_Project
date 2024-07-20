using CQRS_Project.CQRS.Queries;
using CQRS_Project.CQRS.Results;
using CQRS_Project.Data;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRS_Project.CQRS.Handlers
{

    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery,GetStudentByIdQueryResult>
    {
        private readonly StudentContext _context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Geriye döneceğimiz değer GetStudentByIdQueryResult -- Mediatr olmadan kullanılan yöntem
        /// </summary>
        //public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        //{
        //    var student = _context.Set<Student>().Find(query.Id);
        //    return new GetStudentByIdQueryResult
        //    {
        //        Age = student.Age,
        //        Name = student.Name,
        //        Surname = student.Surname
        //    };
        //}

        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Set<Student>().FindAsync(request.Id);
            return new GetStudentByIdQueryResult
            {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname
            };
        }
    }
}
