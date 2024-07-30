using ECommerceApp.Application.DTOs;
using ECommerceApp.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace  ECommerceApp.Application.Interfaces
{
    public interface IAuthService
    {      
        Task RegisterAsync(UserRegisterDTO userDTO);
        Task<SignInResult> LoginAsync(UserLoginDTO userloginDto);
        Task LogoutAsync(); 
        
    }
}