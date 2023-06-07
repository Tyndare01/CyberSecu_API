using System.Drawing.Text;
using Chessie.ErrorHandling;
using CyberSecu_API.DTOs;
using CyberSecu_API_Domain.Commands;
using CyberSecu_API_Domain.Queries;
using CyberSecu_API_Domain.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace CyberSecu_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public UserController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        public IActionResult Register(AddUserDto dto)
        {
            try
            {
                _authRepository.Handle(new RegisterCommand(dto.Email,  dto.FirstName, dto.LastName, dto.Passwd));
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return BadRequest();
                
            }
        }

        [HttpPost("Connection")]
        public IActionResult Connection(ConnectionUserDto dto)
        {
            try
            {
                _authRepository.Handle(new ConnectionQuery(dto.Email, dto.Passwrd));
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
                return BadRequest();
            }
           
        }
    }
}
