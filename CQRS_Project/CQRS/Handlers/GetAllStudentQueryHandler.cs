using CQRS_Project.CQRS.Queries;
using CQRS_Project.CQRS.Results;
using CQRS_Project.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CQRS_Project.CQRS.Handlers
{
    public class GetAllStudentQueryHandler
    {
        private readonly StudentContext _studentContext;

        public GetAllStudentQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public IEnumerable<GetAllStudentQueryResult> Handle(GetAllStudentQuery query)
        {
            return _studentContext.Students.Select
                (x => new GetAllStudentQueryResult { Age = x.Age, Name = x.Name, Surname = x.Surname })
                .AsNoTracking().AsEnumerable();
        }
    }
}
