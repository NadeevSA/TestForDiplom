using Microsoft.AspNetCore.Mvc;
using OOP.Contracts;
using OOP.Interfaces;

namespace OOP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            ;
            var x = new List<User>();
            var y = x.FirstOrDefault();
            return BadRequest("123");
            var users = _userService.GetAll();

            return Ok(users);
        }

        [HttpGet("Dapper/GetAll")]
        public ActionResult GetAllInDapper()
        {
            var users = _userService.GetAllInDapper();

            return Ok(users);
        }

        [HttpGet("GetById")]
        public ActionResult GetById([FromQuery] Guid userId)
        {
            var user = _userService.GetById(userId);
            if (user == null)
            {
                return BadRequest($"{nameof(User)} with id = {userId} is not found through EF.");
            }

            return Ok(user);
        }

        [HttpPost("AddUser")]
        public ActionResult Add([FromBody] IEnumerable<User> users)
        {
            var countAddedUsers = _userService.Add(users);
            if (countAddedUsers != users.Count())
            {
                return BadRequest($"Added {countAddedUsers} of {users.Count()} {nameof(User)} through EF.");
            }

            return Ok(countAddedUsers);
        }

        [HttpPost("Dapper/AddUser")]
        public ActionResult AddInDapper([FromBody] User user)
        {
            var countAddedUsers = _userService.AddInDapper(user);
            if (countAddedUsers == 0)
            {
                return BadRequest($"Didn't added {nameof(User)} by id {user.id} through dapper.");
            }

            return Ok(countAddedUsers);
        }

        [HttpPut("UpdateUser")]
        public ActionResult Update([FromBody] User user)
        {
            var countUpdatedUsers = _userService.Update(user);
            if (countUpdatedUsers == 0)
            {
                return BadRequest($"Didn't updated {nameof(User)} by id {user.id} through EF.");
            }

            return Ok(countUpdatedUsers);
        }

        [HttpPut("Dapper/UpdateUser")]
        public ActionResult UpdateDapper([FromBody] User user)
        {
            var countUpdatedUsers = _userService.UpdateInDapper(user);
            if (countUpdatedUsers == 0)
            {
                return BadRequest($"Didn't updated {nameof(User)} by id {user.id} through dapper.");
            }

            return Ok(countUpdatedUsers);
        }

        [HttpDelete("DeleteUser")]
        public ActionResult Delete([FromQuery] Guid userId)
        {
            var countDeletedUsers = _userService.Remove(userId);
            if (countDeletedUsers == 0)
            {
                return BadRequest($"Didn't deleted {nameof(User)} by id {userId} through EF.");
            }

            return Ok(countDeletedUsers);
        }

        [HttpDelete("Dapper/DeleteUser")]
        public ActionResult DeleteDapper([FromQuery] Guid userId)
        {
            var countDeletedUsers = _userService.RemoveInDapper(userId);
            if (countDeletedUsers == 0)
            {
                return BadRequest($"Didn't deleted {nameof(User)} by id {userId} through dapper.");
            }

            return Ok(countDeletedUsers);
        }
    }
}
