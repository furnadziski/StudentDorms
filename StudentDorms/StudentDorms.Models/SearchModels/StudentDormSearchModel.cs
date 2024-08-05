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
    public class StudentDormSearchModel : BaseSearchModel
{
    /// <summary>
    /// Текст по кој се пребарува еден студентски дом
    /// </summary>
    public string SearchText { get; set; }
}
}
