namespace CQRS_Project.CQRS.Results
{
    public class GetStudentByIdQueryResult
    {
        /// <summary>
        ///  Id'yi ilettikten sonra dönecek result
        /// </summary>
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
