using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayTransaction.Application.Commands.Admin;
using RailwayTransaction.Application.Commands.MasterManagement.Station;
using RailwayTransaction.Application.Queries.Admin;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Handler.Admin;

namespace RailwayTransaction.Controllers.Admin
{
<<<<<<< HEAD:Back-end/RailwayTransaction/RailwayTransaction/Controllers/UsersController.cs
    [Authorize (Roles="Admin, MasterManagement")]
=======
    [Authorize(Roles = "Admin")]
>>>>>>> 3c199aca0e4ed3fd6f46400c29c1e11c3edc146b:Back-end/RailwayTransaction/RailwayTransaction/Controllers/Admin/UsersController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

<<<<<<< HEAD:Back-end/RailwayTransaction/RailwayTransaction/Controllers/UsersController.cs
        [HttpGet("getall")]  
=======
        [HttpGet]
>>>>>>> 3c199aca0e4ed3fd6f46400c29c1e11c3edc146b:Back-end/RailwayTransaction/RailwayTransaction/Controllers/Admin/UsersController.cs
        public async Task<IActionResult> GetAll()
        {
            var userList = await _mediator.Send(new GetAllUsersQuery());
            if (userList == null || userList.Count == 0)
            {
                return NotFound("No userList found");
            }
            return Ok(userList);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var userDetail = await _mediator.Send(new GetUserDetailQuery() { Id = id });
            if (userDetail == null)
            {
                return NotFound("User not found");
            }
            return Ok(userDetail);
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddUser([FromBody] CreateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = await _mediator.Send(command);

            if (newUser == null)
            {
                return BadRequest("User could not be created.");
            }

            return Ok(newUser);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            if (result == Unit.Value)
            {
                return NoContent(); // Thành công nhưng không có nội dung trả về
            }

            return BadRequest("Failed to update user");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteStation(string id)
        {
            await _mediator.Send(new DeleteUserCommand { Id = id });
            return NoContent();
        }
        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleResponse>>> GetAllRoles()
        {
            var roles = await _mediator.Send(new GetAllRolesQuery());
            return Ok(roles);
        }
    }
}
