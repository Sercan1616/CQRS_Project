using CQRS_Project.CQRS.Results;
using MediatR;

namespace CQRS_Project.CQRS.Queries
{
    public class GetStudentByIdQuery : IRequest<GetStudentByIdQueryResult>
    {
        /// <summary>
        /// Sorgu için iletilecek Id 
        /// </summary>
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
