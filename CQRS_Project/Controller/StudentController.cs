using CQRS_Project.CQRS.Commands;
using CQRS_Project.CQRS.Handlers;
using CQRS_Project.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace CQRS_Project.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        // MEDIATR KULLANMADAN ÖNCE TÜM HANDLER'LARI DI İLE ELE ALIYORDUK. BU KOD KALABALIĞINA SEBEP VERDİ.
        //private readonly GetStudentByIdQueryHandler _getStudentByIdHandler;
        //private readonly GetAllStudentQueryHandler _getAllStudentHandler;
        //private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        //private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        //private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;

        //public StudentController(GetStudentByIdQueryHandler getStudentByIdHandler, GetAllStudentQueryHandler getAllStudentHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        //{
        //    _getStudentByIdHandler = getStudentByIdHandler;
        //    _getAllStudentHandler = getAllStudentHandler;
        //    _createStudentCommandHandler = createStudentCommandHandler;
        //    _removeStudentCommandHandler = removeStudentCommandHandler;
        //    _updateStudentCommandHandler = updateStudentCommandHandler;
        //}

        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var result = await _mediator.Send(new GetAllStudentQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResult(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveStudent(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
