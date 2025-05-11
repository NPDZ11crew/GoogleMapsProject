using GoogleMaps_FinalProjectAspApi.Abstract;
using GoogleMaps_FinalProjectAspApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoogleMaps_FinalProjectAspApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("AddPlaceAsync")]
        public async Task AddUserAsync(UserDto user)
        {
            await _userService.AddAsync(user);
        }

        [HttpGet("GetPlaceByIdAsync")]
        public async Task<UserDto> GetUserByIdAsync(Guid Id)
        {
            var users = _userService.GetAllAsync().Result;
            foreach (var user in users)
            {
                if (user.UserId == Id)
                {
                    return user;
                }
            }
            return new UserDto();
        }

        [HttpGet("GetAllAsync")]
        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return _userService.GetAllAsync().Result;
        }

        [HttpDelete("DeleteByIdAsync")]
        public async Task<UserDto> DeleteByIdAsync(Guid Id)
        {
            var result = GetUserByIdAsync(Id).Result;
            if (result == null)
            {
                return new UserDto();
            }
            _userService.DefaultDeleteAsync(result.UserId);

            return result;
        }

        [HttpDelete("DeleteAllAsync")]
        public async Task<string> DeleteAllAsync()
        {
            var users = _userService.GetAllAsync().Result;
            foreach (var user in users)
            {
                await _userService.DefaultDeleteAsync(user.UserId);
            }
            return "Deleted Successfully!";
        }

    }
}
