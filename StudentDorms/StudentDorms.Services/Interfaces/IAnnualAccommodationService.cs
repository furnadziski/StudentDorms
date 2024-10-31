using StudentDorms.Models.Base;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Models.ViewModels;


namespace StudentDorms.Services.Interfaces
{   /// <summary>
    /// Сервисен интерфејс за менаџирање на годишни сместувања
    /// </summary>
   public interface IAnnualAccommodationService
    {
        /// <summary>
        /// Метода за прикажување и филтрирање на податоци на Грид
        /// </summary>
        /// <param name="accommodationSearchModel"></param>
        /// <returns>Листа од Грид модел за годишно сместување</returns>
        public SearchResult<AccommodationGridModel> GetAnnualAccommodationsForGrid(AnnualAccommodationSearchModel accommodationSearchModel);

        /// <summary>
        /// Метода за едитирање на податоци
        /// </summary>
        /// <param name="accommodationCreateUpdateModel"></param>
        /// <returns>Едитирање  на годишно сместување</returns>
        public void UpdateAnnualAccommodation(AccommodationCreateUpdateModel accommodationCreateUpdateModel);
        public AccommodationViewModel GetAccommodationById(int accId);
    }
}
