using HotelListing.Api.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.Api.Contracts_IRepository_
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}
