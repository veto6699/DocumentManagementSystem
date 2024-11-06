using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.Requests
{
    public class LogInRequest
    {
        /// <summary>
        /// Почта
        /// </summary>
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public required string Password { get; set; }
    }
}
