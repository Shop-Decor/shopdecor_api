﻿using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace shopdecor_api.Models.DTO.AccountDTO
{
    public class User
    {
        public static ClaimsIdentity Identity { get; internal set; }
        public string Id { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string FullName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
    }
}
