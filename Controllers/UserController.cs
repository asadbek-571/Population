

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Population.Dto;
using Population.Entity;
using Population.Repository;
namespace Population.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _userRepo.Get(id);

            if (user is null)
                return NoContent();

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepo.GetAll();
            return Ok(users);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddUser(UserDto userDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Birthday = userDto.Birthday,
                Gender = userDto.Gender,
                HomeNumber = userDto.HomeNumber,
                Street = userDto.Street,
                District = userDto.District,
            };
            await _userRepo.Add(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id,UserDto userDto)
        {
            User user = new()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Birthday = userDto.Birthday,
                Gender = userDto.Gender,
                HomeNumber = userDto.HomeNumber,
                Street = userDto.Street,
                District = userDto.District
            };
            await _userRepo.Update(user,id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _userRepo.Delete(id);
            return Ok();
        }
        
    }
}