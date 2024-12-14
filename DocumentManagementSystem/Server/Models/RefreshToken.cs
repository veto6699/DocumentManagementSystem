using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentManagementSystem.Server.Models
{
    [BsonIgnoreExtraElements]
    public class RefreshToken(Guid userId, string token)
    {
        /// <summary>
        /// Ид
        /// </summary>
        [BsonId, BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Ид пользователя
        /// </summary>
        public Guid UserId { get; set; } = userId;
        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; } = token;
        /// <summary>
        /// Дата, до которой токен действителен
        /// </summary>
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(3);
        /// <summary>
        /// Флаг, использован ли этот токен
        /// </summary>
        public bool IsUsed { get; set; } = false;
    }
}
