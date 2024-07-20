using CQRS_Project.CQRS.Results;
using MediatR;
using System.Collections.Generic;

namespace CQRS_Project.CQRS.Queries
{
    public class GetAllStudentQuery : IRequest<IEnumerable<GetAllStudentQueryResult>>
    {
    }
}
