using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Entities.Concrete;
using TetraPolimerSistem.Entities.Dtos.LoginDtos;

namespace TetraPolimerSistem.Business.Abstarct
{
    public interface IAuthService
    {
        Task<AppUser> GetUserAsync(string userName);
        Task<IdentityResult> PasswordResetAsync(string userName, string newPassword);
        Task<IdentityResult> UpdatePasswordAsync(string userName, string currentPassword, string newPassword);
        Task<SignInResult> Login(LoginDto loginDto);

        //Task<IdentityResult> SellerRegister(SellerAddDto sellerDto);
        //Task<IdentityResult> CustomerRegister(CustomerAddDto customerDto);

        Task SignOut();

        Task<IdentityResult> AddToRoleAsync(AppUser appUser, string role);
    }
}
