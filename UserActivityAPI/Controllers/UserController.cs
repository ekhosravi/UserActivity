using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserActivityAPI.Models;
using UserActivityAPI.Models.Dtos;
using UserActivityAPI.Services.IServices;

namespace UserActivityAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class UserController : ControllerBase

    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userSrvice , IMapper mapper)
        {
            _userService = userSrvice;  
            _mapper = mapper;   
        }

        /// <summary>
        /// Get list of users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(List<User>))]
        [ProducesResponseType(400)]
        [ProducesDefaultResponseType]
        public IActionResult GetUserAll()
        {
            var objList = _userService.GetAllUser();   

            return Ok(objList);  
        }

        /// <summary>
        /// Get individual user
        /// </summary>
        /// <param name="userid"> The is of user </param>
        /// <returns></returns>
        [HttpGet("{userid:int}", Name = "GetUser")]
        public IActionResult GetUser(int userid)
        {
            var obj  =_userService.GetUserById(userid);
            if (obj == null)
            {
                return NotFound();  
            }
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest(ModelState);
            }

            if(_userService.UserExists(userDto.UserName))
            {
                ModelState.AddModelError("", "User Exists!");
                return StatusCode(404, ModelState); 
            }

            var user = _mapper.Map<User>(userDto);
            user.RegistrationDate = DateTime.UtcNow;

            if (!_userService.AddUserAsync(user))
            {
                ModelState.AddModelError("", $"Somthing went wrong when saving the record {user.UserName}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetUser" , new { userid = user.UserID} , user);
        }

        [HttpPatch("{userid:int}", Name = "Updateuser")]
        public IActionResult Updateuser(int userid, [FromBody] UserUpdateDto userDto)
        {
            if (userDto == null || userid!=userDto.UserID)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(userDto);
            if (!_userService.UpdateUserAsync(user ))
            {
                ModelState.AddModelError("", $"Somthing went wrong when Updating the record {user.UserName}");
                return StatusCode(500, ModelState);
            }

            return NoContent(); 
        }

        [HttpDelete("{userid:int}", Name = "DeleteUser")]
        public IActionResult DeleteUser(int userid)
        {
            if (_userService.UserExists(userid))
            {
                return NotFound();
            }

            var userobj = _userService.GetUserById(userid); 
            if (!_userService.DeleteUserAsync(userobj))
            {
                ModelState.AddModelError("", $"Somthing went wrong when deleting the record {userobj.UserName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
