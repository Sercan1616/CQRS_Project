namespace CQRS_Project.CQRS.Queries
{
    public class GetStudentByIdQuery
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
