using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetraPolimerSistem.Business.Abstarct;
using TetraPolimerSistem.Entities.Concrete;

namespace TetraPolimerSistem.Business.Concrete
{
    //public class AuthManager : IAuthService
    //{

    //    private readonly UserManager<AppUser> _userManager;
    //    private readonly RoleManager<AppRole> _roleManager;
    //    private readonly SignInManager<AppUser> _signInManager;
    //    private readonly ICustomerDal _customerDal;
    //    private readonly ISellerDal _sellerDal;

    //    public AuthManager(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, ICustomerDal customerDal, ISellerDal sellerDal)
    //    {
    //        _userManager = userManager;
    //        _roleManager = roleManager;
    //        _signInManager = signInManager;
    //        _customerDal = customerDal;
    //        _sellerDal = sellerDal;
    //    }


    //    public async Task<IdentityResult> AddToRoleAsync(AppUser appUser, string role)
    //    {
    //        AppRole appRole = _roleManager.Roles.FirstOrDefault(x => x.Name == role);
    //        if (appRole == null)
    //        {
    //            await _roleManager.CreateAsync(new AppRole()
    //            {
    //                Name = role,
    //                NormalizedName = role.ToUpper()
    //            });
    //        }

    //        return await _userManager.AddToRoleAsync(appUser, role);
    //    }

    //    public async Task<IdentityResult> CustomerRegister(CustomerAddDto customerDto)
    //    {
    //        Customer customer = new Customer()
    //        {
    //            Address = customerDto.Address,
    //            FirstName = customerDto.FirstName,
    //            LastName = customerDto.LastName,
    //        };

    //        AppUser appUser = new AppUser()
    //        {
    //            Email = customerDto.Email,
    //            PhoneNumber = customerDto.PhoneNumber,
    //            UserName = customerDto.UserName,
    //        };
    //        await _customerDal.AddAsync(customer);
    //        IdentityResult result = await _userManager.CreateAsync(appUser, customerDto.Password);
    //        if (result.Succeeded)
    //        {
    //            AddToRoleAsync(appUser, "customer");
    //            await _customerDal.SaveAsync();
    //        }
    //        return result;
    //    }

    //    public async Task<IdentityResult> SellerRegister(SellerAddDto sellerDto)
    //    {
    //        Seller seller = new Seller()
    //        {
    //            Address = sellerDto.Address,
    //            FirstName = sellerDto.FirstName,
    //            LastName = sellerDto.LastName,
    //            CompanyName = sellerDto.CompanyName,
    //        };

    //        AppUser appUser = new AppUser()
    //        {
    //            Email = sellerDto.Email,
    //            PhoneNumber = sellerDto.PhoneNumber,
    //            UserName = sellerDto.UserName,
    //        };
    //        await _sellerDal.AddAsync(seller);
    //        IdentityResult result = await _userManager.CreateAsync(appUser, sellerDto.Password);
    //        if (result.Succeeded)
    //        {
    //            AddToRoleAsync(appUser, "seller");
    //            await _sellerDal.SaveAsync();
    //        }
    //        return result;
    //    }

    //    public async Task<SignInResult> Login(LoginDto loginDto)
    //    {
    //        AppUser user;
    //        if (loginDto.UserName.Contains("@"))
    //        {
    //            user = _userManager.Users.FirstOrDefault(x => x.Email == loginDto.UserName);
    //        }
    //        else
    //        {
    //            user = _userManager.Users.FirstOrDefault(x => x.UserName == loginDto.UserName);
    //        }
    //        return user is not null ? await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, false) : null;
    //    }

    //    public async Task SignOut()
    //    {
    //        await _signInManager.SignOutAsync();
    //    }

    //    public async Task<IdentityResult> PasswordResetAsync(string userName, string newPassword)
    //    {
    //        string token = null;
    //        AppUser user = await GetUserAsync(userName);
    //        IdentityResult result = await _userManager.RemovePasswordAsync(user);
    //        if (result.Succeeded)
    //        {
    //            token = await _userManager.GeneratePasswordResetTokenAsync(user);
    //        }
    //        return await _userManager.ResetPasswordAsync(user, token, newPassword);
    //    }

    //    public async Task<IdentityResult> UpdatePasswordAsync(string userName, string currentPassword, string newPassword)
    //    {
    //        AppUser user = await GetUserAsync(userName);
    //        return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    //    }

    //    public async Task<AppUser> GetUserAsync(string userName)
    //    {
    //        return await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);
    //    }
    //}
}
