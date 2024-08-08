using StudentDorms.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.SearchModels
{    /// <summary>
     /// класа во која се чуваат информации за годишно сместување
     /// </summary>
    public class AccommodationSearchModel :BaseSearchModel
    {

        /// <summary>
        /// Година на годишно сместување
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Ид на блок
        /// </summary>
        public int? BlockId { get; set; }

        /// <summary>
        /// Ид на студентски дом
        /// </summary>
        public int StudentDormId { get; set; }

        /// <summary>
        /// Дали има слободно место
        /// </summary>
        public int? HasFreeSpaceOnly { get; set; }

        /// <summary>
        /// Пребарување по капацитет
        /// </summary>
        public int? CapacitySearch { get; set; }

        /// <summary>
        /// Ид на корисник
        /// </summary>
        public int? Userid { get; set; }

        /// <summary>
        /// Пребарување по соба
        /// </summary>
        public string? RoomSearchText { get; set; }




    }
}
