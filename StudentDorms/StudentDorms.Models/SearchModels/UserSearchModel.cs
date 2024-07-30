using StudentDorms.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.SearchModels
{
    /// <summary>
    /// Модел во кој се чуваат инфромации за категоријата
    /// </summary>
    public class UserSearchModel : BaseSearchModel
    {
        /// <summary>
        /// Текст по кој се пребарува еден корисник
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// Ид на улогата по кој се пребарува еден корисник
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// Ид на пол по кој се пребарува еден корисник
        /// </summary>
        public int? GenderId  { get; set; }

        /// <summary>
        /// Дали корисникот е активен 
        /// </summary>
        public int? IsActive  { get; set; }

    }
}
