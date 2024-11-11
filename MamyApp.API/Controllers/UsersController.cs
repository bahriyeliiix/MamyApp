using AutoMapper;
using MamyApp.Application.Constants;
using MamyApp.Application.Dtos;
using MamyApp.Application.DTOs;
using MamyApp.Application.Features.Users.Commands;
using MamyApp.Application.Features.Users.Queries;
using MamyApp.Application.Models;
using MamyApp.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MamyApp.Application.Enums;

namespace MamyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetUserByIdQuery(id));

                if (result == null)
                {
                    return NotFound(ApiResponse<ErrorDetails>.Failure(
                        MessageConstants.UserNotFound,
                        HttpStatusCode.NotFound,
                        new List<string> { "User ID not found in the database" }));
                }

                return Ok(ApiResponse<UserDto>.Success(result, MessageConstants.UserCreated));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    ApiResponse<ErrorDetails>.Failure(MessageConstants.InternalServerError, HttpStatusCode.InternalServerError, new List<string> { ex.Message }));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse<ErrorDetails>.Failure(
                    MessageConstants.ValidationFailed,
                    HttpStatusCode.BadRequest,
                    validationErrors));
            }

            try
            {
                var command = _mapper.Map<CreateUserCommand>(createUserDto);
                var userId = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetUserById), new { id = userId },
                    ApiResponse<int>.Success(userId, MessageConstants.UserCreated));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    ApiResponse<ErrorDetails>.Failure(MessageConstants.InternalServerError, HttpStatusCode.InternalServerError, new List<string> { ex.Message }));
            }
        }
    }
}
