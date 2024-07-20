using CQRS_Project.CQRS.Queries;
using CQRS_Project.CQRS.Results;
using CQRS_Project.Data;

namespace CQRS_Project.CQRS.Handlers
{

    public class GetStudentByIdQueryHandler
    {
        private readonly StudentContext _context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Geriye döneceğimiz değer GetStudentByIdQueryResult
        /// </summary>
        public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        {
            var student = _context.Set<Student>().Find(query.Id);
            return new GetStudentByIdQueryResult
            {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname
            };
        }
    }
}
