using CQRS_Project.CQRS.Queries;
using CQRS_Project.CQRS.Results;
using CQRS_Project.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_Project.CQRS.Handlers
{
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<GetAllStudentQueryResult>>
    {
        private readonly StudentContext _studentContext;

        public GetAllStudentQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }


        public async Task<IEnumerable<GetAllStudentQueryResult>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            return await _studentContext.Students.Select
                (x => new GetAllStudentQueryResult { Age = x.Age, Name = x.Name, Surname = x.Surname })
                .AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Mediatr olmadan kullanılan yöntem
        /// </summary>
        //public IEnumerable<GetAllStudentQueryResult> Handle(GetAllStudentQuery query)
        //{
        //    return _studentContext.Students.Select
        //        (x => new GetAllStudentQueryResult { Age = x.Age, Name = x.Name, Surname = x.Surname })
        //        .AsNoTracking().AsEnumerable();
        //}



    }
}
