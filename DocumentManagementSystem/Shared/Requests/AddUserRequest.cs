using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Shared.Requests
{
    public class AddUserRequest
    {
        /// <summary>
        /// Почта
        /// </summary>
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public required string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public required string Surname { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public required string Password { get; set; }
    }
}
