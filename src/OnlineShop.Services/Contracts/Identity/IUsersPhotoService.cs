﻿using OnlineShop.Entities.Identity;

namespace OnlineShop.Services.Contracts.Admin
{
    public interface IUsersPhotoService
    {
        string GetUsersAvatarsFolderPath();
        void SetUserDefaultPhoto(User user);
        string GetUserDefaultPhoto(string photoFileName);
        string GetUserPhotoUrl(string photoFileName);
        string GetCurrentUserPhotoUrl();
    }
}