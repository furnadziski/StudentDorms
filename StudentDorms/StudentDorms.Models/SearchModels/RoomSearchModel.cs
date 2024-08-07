using StudentDorms.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Models.SearchModels
{ /// <summary>
  /// Модел во кој се чуваат инфромации за собите
  /// </summary>
    public class RoomSearchModel : BaseSearchModel
 {
     /// <summary>
     /// Текст по кој се пребарува едена соба
     /// </summary>
    public string SearchText { get; set; }

    /// <summary>
    /// Ид на студентки дом по кој се пребарува еден корисник
    /// </summary>
    public int? StudentDormId { get; set; }

    /// <summary>
    /// Ид блок по кој се пребарува еден корисник
    /// </summary>
    public int? BlockId { get; set; }
    }
}
