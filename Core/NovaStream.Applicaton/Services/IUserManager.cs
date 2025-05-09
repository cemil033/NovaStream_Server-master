﻿namespace NovaStream.Application.Services;

public interface IUserManager
{
    bool CreateUser(User user, string password);
    Task<bool> CreateUserAsync(User user, string password);

    bool UpdateUser(User user);
    Task<bool> UpdateUserAsync(User user);

    bool DeleteUser(User user);
    Task<bool> DeleteUserAsync(User user);

    bool AssignRole(User user, UserRoles role);
    Task<bool> AssignRoleAsync(User user, UserRoles role);

    User? FindUserByEmail(string email);
    Task<User?> FindUserByEmailAsync(string email);

    User? ReturnUserFromContext(HttpContext httpContext);
    Task<User?> ReturnUserFromContextAsync(HttpContext httpContext);

    bool CheckPassword(User user, string password);
    Task<bool> CheckPasswordAsync(User user, string password);

    bool CheckOldPassword(User user, string password);
    Task<bool> CheckOldPasswordAsync(User user, string password);

    bool ChangePassword(User user, string newPassword);
    Task<bool> ChangePasswordAsync(User user, string newPassword);

    bool Exists(string email);
    Task<bool> ExistsAsync(string email);
}
