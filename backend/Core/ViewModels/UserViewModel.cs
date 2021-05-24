using System;
using Data.Enums;

namespace Core.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public UserType UserType { get; set; }
    }
}