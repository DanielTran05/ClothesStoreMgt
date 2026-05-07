using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DTO.UserDto
{
    public class ResetPasswordRequest
    {
        public Guid UserID { get; set; }
        public string NewPassword { get; set; } 
    }
}
