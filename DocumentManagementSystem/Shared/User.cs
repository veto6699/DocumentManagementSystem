using DocumentManagementSystem.Shared.Requests;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentManagementSystem.Shared
{
    [BsonIgnoreExtraElements]
    public class User(AddUserRequest args)
    {
        /// <summary>
        /// Ид
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; } = args.Email;
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = args.Name;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; } = args.Surname;
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = args.Password;
    }
}
