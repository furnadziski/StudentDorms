using StudentDorms.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.SearchModels
{
         /// <summary>
         /// класа во која се чуваат информации за Myprofile
         /// </summary>
    public class MyProfileSearchModel
    {
        /// <summary>
        /// Ид на корисник
        /// </summary>
        public int UserId { get; set; }
    }
}
