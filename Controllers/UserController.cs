using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuthIdentity.Controllers;

public static class UserController
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {

        var group = routes.MapGroup("/api/Users");
        //.RequireAuthorization();


        group.MapPost("/Register", async (string username, string email, string password, UserManager<IdentityUser> userManager) =>
        {
            var newUser = new IdentityUser { UserName = username, Email = email };
            var results = await userManager.CreateAsync(newUser, password);
            return results;

        }).WithName("RegisterUsers");


       

        group.MapPost("/Authenticate", async (string email, string password, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) =>
        {

            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Results.NotFound("Username does not exist");
            }


            var signInResult = await userManager.CheckPasswordAsync(user, password);

            if (signInResult)
            {
                return Results.Ok(new
                {
                    email = user.Email,
                    username = user.UserName,
                });
            }
            else
            {
                return Results.NotFound("Invalid password");
            }

        }).WithName("Authenticate");

        group.MapPost("/ChangePassword", async (string email,string password,string newPassword,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) =>
        {
            var user = await userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return Results.NotFound("Username does not exist");
            }
            else
            {
                var passwordChange = await userManager.ChangePasswordAsync(user,password, newPassword);

                if (passwordChange.Succeeded)
                {
                    
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Results.Ok($"Password changed successfully for user {user.UserName}");
                }
                else
                {
                    return Results.BadRequest();
                }
            }

        }).WithName("ChangeUserPassword");


        group.MapGet("/GetAll", (HttpContext context, UserManager<IdentityUser> userManager) =>
        {
            var users = userManager.Users.ToList();

            if (!users.Any())
            {

                return Results.Ok("Database currently has zero users");
            }
            else
            {
                return Results.Ok(users);
            }

        }).WithName("GetAllUsers");


        group.MapGet("/GetUserByEmail", async (string email, UserManager<IdentityUser> userManager) =>
        {

            var user = await userManager.FindByEmailAsync(email);

            if (user != null)
            {
                return Results.Ok(user);
            }
            else
            {
                return Results.NotFound("User does not exist");
            }
        }).WithName("GetUserByEmail");
    }


}

