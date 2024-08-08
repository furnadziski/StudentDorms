using StudentDorms.Models.Base;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Services.Interfaces
{   /// <summary>
    /// Сервисен интерфејс за менаџирање на годишни сместувања
    /// </summary>
   public interface IAccommodationService
    {
        /// <summary>
        /// Метода за прикажување и филтрирање на податоци на Грид
        /// </summary>
        /// <param name="accommodationSearchModel"></param>
        /// <returns>Листа од Грид модел за годишно сместување</returns>
        public SearchResult<AccommodationGridModel> GetAccommodationsForGrid(AccommodationSearchModel accommodationSearchModel);
    }
}
