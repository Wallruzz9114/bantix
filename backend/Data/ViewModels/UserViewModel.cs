using System;
using Data.Enums;

namespace Data.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public UserType UserType { get; set; }
    }
}