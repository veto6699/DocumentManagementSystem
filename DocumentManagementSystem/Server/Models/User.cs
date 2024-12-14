using DocumentManagementSystem.Shared.Requests;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentManagementSystem.Server.Models
{
    [BsonIgnoreExtraElements]
    public class User(RegistrationRequest args)
    {
        /// <summary>
        /// Ид
        /// </summary>
        [BsonId, BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; } = args.Email.Trim().ToLower();
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = args.Name.Trim();
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; } = args.Surname.Trim();
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = args.Password.Trim();
    }
}
