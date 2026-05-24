using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StuMap.DAL.Models;
using StuMap.ViewModels.Account;

namespace StuMap.Controllers.Account
{
    [Authorize]
    public class AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signinManager) : Controller
    {
        [Route("account/edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(string form = "profile")
        {
            var u = await userManager.GetUserAsync(User);

            ViewBag.form = form;

            EditViewModel vm = new()
            {
                FName = u?.FirstName,
                LName = u?.LastName,
                Country = u?.Country,
                DateOfBirth = u?.DateOfBirth ?? DateTime.MinValue,
                Email = u?.Email,
                Phone = u?.PhoneNumber,
            };
            return View("Edit", vm);
        }

        [HttpPost]
        [Route("account/edit/submit-profile")]
        public async Task<IActionResult> EditProfile(ProfileEditViewModel data)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine($"Reporting Errors:");
                // Extract every error message from the ModelState dictionary
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage);

                TempData["SaveError"] = "Error Saving Changes..";
                foreach (var error in errors)
                {
                    Console.WriteLine($"[MODELSTATE ERROR] {error}");
                    TempData["SaveError"] += $"\n{error}";
                }
                return RedirectToAction("Edit", new { form = "profile" });
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["SaveError"] = "Error Saving Changes..";
                return RedirectToAction("Edit", new { form = "profile" });
            }

            user.PhoneNumber = data.Phone;
            user.Country = data.Country;
            user.FirstName = data.FName;
            user.LastName = data.LName;

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await signinManager.RefreshSignInAsync(user);
                TempData["SaveSuccess"] = "Changes Saved!";
                return RedirectToAction("Edit", new { form = "profile" });
            }
            else
            {
                TempData["SaveError"] = "Error Saving Changes..";
                foreach (var error in result.Errors)
                {
                    TempData["SaveError"] += $"\n{error}";
                }
                return RedirectToAction("Edit", new { form = "profile" });
            }
        }

        [HttpPost]
        [Route("account/edit/submit-account")]
        public async Task<IActionResult> EditAccount(AccountEditViewModel data)
        {
            if (data.NewPassword == data.CurrentPassword)
            {
                ModelState.AddModelError("", "New password must be diffrent from current password.");
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine($"Reporting Errors:");
                // Extract every error message from the ModelState dictionary
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage);

                TempData["SaveError"] = "Error Changing Password..";
                foreach (var error in errors)
                {
                    Console.WriteLine($"[MODELSTATE ERROR] {error}");
                    TempData["SaveError"] += $"\n{error}";
                }
                return RedirectToAction("Edit", new { form = "account" });
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["SaveError"] = $"Error Changing Password..\n" +
                    $"User not found.";
                return RedirectToAction("Edit", new { form = "account" });
            }
            var result = await userManager.ChangePasswordAsync(user, data.CurrentPassword!, data.NewPassword!);
            if (result.Succeeded)
            {
                await signinManager.RefreshSignInAsync(user);

                TempData["SaveSuccess"] = "Password Changed Successfully!";
                return RedirectToAction("Edit", new { form = "account" });
            }
            else
            {
                TempData["SaveError"] = "Error Changing Password..";
                foreach (var error in result.Errors)
                {
                    TempData["SaveError"] += $"\n{error.Description}";
                }
                return RedirectToAction("Edit", new { form = "account" });
            }

        }
    }
}
