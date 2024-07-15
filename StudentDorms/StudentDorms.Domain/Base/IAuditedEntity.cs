using System;

namespace StudentDorms.Domain.Base
{
    /// <summary>
    /// Интерфејс во кој се чува кој креирал, кој направил промена и датум и време на креирање и на промена
    /// </summary>
    public interface IAuditedEntity
    {
        /// <summary>
        /// Кориснчко име на корисникот кој креирал 
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Датум и време на креирање
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Корисничко име на корисникот кој направил промена
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Датум и време на промена
        /// </summary>
        public DateTime DateModified { get; set; }
    }
}
