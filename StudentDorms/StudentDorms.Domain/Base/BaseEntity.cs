
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDorms.Domain.Base
{
    /// <summary>
    /// Класа во која се чува примарен клуч, од која ќе наследуваат останатите класи
    /// </summary>
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// Примарен клуч на класата
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
    }

    public abstract class BaseEntityWithTimestamp<T>
    {
        /// <summary>
        /// Примарен клуч на класата
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        /// <summary>
        /// Корисничко име на корисникот кој го креирал барањето за одмор
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>       
        /// Датум и време кога е креиранo барањето за одмор
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Корисничко име на корисникот кој го модифицирал барањето за одмор
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Датум на модификација на барањето за одмор
        /// </summary>
        public DateTime DateModified { get; set; }
    }
}
