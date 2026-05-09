using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DTO.UserDto
{
    public class UpdateUserRequest
    {
        public Guid UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Role { get; set; }
    }
}
