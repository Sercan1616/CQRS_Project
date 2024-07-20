using CQRS_Project.CQRS.Commands;
using CQRS_Project.CQRS.Handlers;
using CQRS_Project.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CQRS_Project.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly GetStudentByIdQueryHandler _getStudentByIdHandler;
        private readonly GetAllStudentQueryHandler _getAllStudentHandler;
        private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;

        public StudentController(GetStudentByIdQueryHandler getStudentByIdHandler, GetAllStudentQueryHandler getAllStudentHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        {
            _getStudentByIdHandler = getStudentByIdHandler;
            _getAllStudentHandler = getAllStudentHandler;
            _createStudentCommandHandler = createStudentCommandHandler;
            _removeStudentCommandHandler = removeStudentCommandHandler;
            _updateStudentCommandHandler = updateStudentCommandHandler;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var result = _getAllStudentHandler.Handle(new GetAllStudentQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetResult(int id)
        {
            var result = _getStudentByIdHandler.Handle(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentCommand command)
        {
            this._createStudentCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveStudent(int id)
        {
            this._removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateStudent(UpdateStudentCommand command)
        {
            this._updateStudentCommandHandler.Handle(command);
            return NoContent();
        }

    }
}
