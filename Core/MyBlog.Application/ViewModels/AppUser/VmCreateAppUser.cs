﻿namespace MyBlog.Application.ViewModels.AppUser
{
    public sealed class VmCreateAppUser
    {
        public  string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
