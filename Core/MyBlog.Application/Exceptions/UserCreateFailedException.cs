﻿using System.Runtime.Serialization;

namespace MyBlog.Application.Exceptions
{
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException() : base("Kullanıcı oluşturulurken bir hata oluştu")
        {
        }

        public UserCreateFailedException(string? message) : base(message)
        {
        }

        public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
