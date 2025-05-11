using GoogleMaps_FinalProjectAspApi.Abstract;
using GoogleMaps_FinalProjectAspApi.DAL.Abstract;
using GoogleMaps_FinalProjectAspApi.DAL.Entities;
using GoogleMaps_FinalProjectAspApi.Models;
using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;

namespace GoogleMaps_FinalProjectAspApi.Core
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(UserDto user)
        {
            user.UserId = Guid.NewGuid();

            var result = new User
            {
                 UserId = user.UserId,
                 LastCity = user.LastCity,
                 ActualLatitude = user.ActualLatLng.latitude,
                 ActualLongitude = user.ActualLatLng.longitude,
            };
            await _repository.AddAsync(result);
        }

        public async Task DefaultDeleteAsync(Guid id)
        {
            await _repository.DefaultDeleteAsync(id);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var usersDto = new List<UserDto>();

            var result = await _repository.GetAllAsync();

            foreach (var user in result)
            {
                usersDto.Add(new UserDto
                {
                   UserId = user.UserId,
                   LastCity = user.LastCity,
                   TelegramId = user.TelegramId,
                   ActualLatLng = new Center
                   {
                       latitude = user.ActualLatitude,
                       longitude = user.ActualLongitude
                   }
                });
            }

            return usersDto;
        }

        public async Task UpdateAsync(UserDto user)
        {
            user.UserId = Guid.NewGuid();

            var result = new User
            {
                UserId = user.UserId,
                LastCity = user.LastCity,
                ActualLatitude = user.ActualLatLng.latitude,
                ActualLongitude = user.ActualLatLng.longitude,
            };
            await _repository.AddAsync(result);
        }
    }
}

