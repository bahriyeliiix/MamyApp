using AutoMapper;
using MediatR;
using MamyApp.Application.Features.Users.Commands;
using MamyApp.Application.Features.Users.Queries;
using MamyApp.Application.DTOs;
using MamyApp.Application.Constants;
using MamyApp.Application.Dtos;
using MamyApp.Application.Models;
using Microsoft.AspNetCore.Mvc;
using MamyApp.Application.Enums;
using System.Text.Json;


namespace MamyApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        // Constructor
        public UsersController(IMediator mediator, IMapper mapper, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        // GET api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            _logger.LogInformation($"Received request to get user by id: {id}");

            try
            {
                var result = await _mediator.Send(new GetUserByIdQuery(id));

                if (result == null)
                {
                    _logger.LogWarning($"User with ID {id} not found.");
                    return NotFound(ApiResponse<ErrorDetails>.Failure(
                        MessageConstants.UserNotFound,
                        HttpStatusCode.NotFound,
                        new List<string> { "User ID not found in the database" }));
                }

                _logger.LogInformation($"Successfully retrieved user with ID: {id}");
                return Ok(ApiResponse<UserDto>.Success(result, MessageConstants.UserCreated));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while getting user with ID {id}: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    ApiResponse<ErrorDetails>.Failure(MessageConstants.InternalServerError, HttpStatusCode.InternalServerError, new List<string> { ex.Message }));
            }
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var createUserJson = JsonSerializer.Serialize(createUserDto);
            _logger.LogInformation("Received request to create a new user. Request Body: {RequestBody}", createUserJson);

            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                _logger.LogWarning("Validation failed for creating user. Errors: {Errors}", string.Join(", ", validationErrors));
                return BadRequest(ApiResponse<ErrorDetails>.Failure(
                    MessageConstants.ValidationFailed,
                    HttpStatusCode.InternalServerError,
                    validationErrors));
            }

            try
            {
                var command = _mapper.Map<CreateUserCommand>(createUserDto);
                var userId = await _mediator.Send(command);

                _logger.LogInformation($"Successfully created user with ID: {userId}");
                return CreatedAtAction(nameof(GetUserById), new { id = userId },
                    ApiResponse<int>.Success(userId, MessageConstants.UserCreated));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating user: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    ApiResponse<ErrorDetails>.Failure(MessageConstants.InternalServerError, HttpStatusCode.InternalServerError, new List<string> { ex.Message }));
            }
        }
    }
}
