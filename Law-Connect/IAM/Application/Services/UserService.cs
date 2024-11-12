using Law_Connect.IAM.Domain.Aggregates;
using Law_Connect.Common.Repositories;
using Law_Connect.IAM.Application.DTOs;
using Law_Connect.Common.Utilities;
using System.Threading.Tasks;

namespace Law_Connect.IAM.Application.Services
{
    public class UserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IBaseRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> RegisterUserAsync(UserDTO userDto)
        {
            var user = new User(
                userDto.FirstName,
                userDto.LastName,
                userDto.Password,
                userDto.Email,
                userDto.Street,
                userDto.Number,
                userDto.City,
                userDto.Country
            );

            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return Result.Success();
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null)
                return null;

            return new UserDTO(
                user.Id,
                user.Name.FirstName,
                user.Name.LastName,
                user.Email.Address,
                string.Empty,
                user.Street.Street,
                user.Street.Number,
                user.Street.City,
                user.Street.Country
            );
        }
    }
}
