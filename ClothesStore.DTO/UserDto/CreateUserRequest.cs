using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DTO.UserDto
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; } 
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Role { get; set; }
        public bool IsActive { get; set; }
    }
}
