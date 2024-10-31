using StudentDorms.Models.Base;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
using StudentDorms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Services.Interfaces
{
    /// <summary>
    /// Сервисен интерфејс за менаџирање на студентски домови
    /// </summary>
    public interface IStudentDormService
    {
        /// <summary>
        /// Метода за прикажување и филтрирање на податоци на Грид
        /// </summary>
        /// <param name="studentDormSearchModel"></param>
        /// <returns>Листа од Грид модел за студентскиот дом</returns>
        public SearchResult<StudentDormGridModel> GetStudentDormsForGrid(StudentDormSearchModel studentDormSearchModel);

        /// <summary>
        /// Метода за креирање на студентски дом
        /// </summary>
        /// <param name="studentDormCreateUpdateModel"></param>
        /// <returns>креирање на модел за студентски дом</returns>
        public void CreateStudentDorm(StudentDormCreateUpdateModel studentDormCreateUpdateModel);

        /// <summary>
        /// Метода за едитирање на студентски дом
        /// </summary>
        /// <param name="studentDormCreateUpdateModel"></param>
        /// <returns>едитирање на модел за студентски дом</returns>
        public void UpdateStudentDorm(StudentDormCreateUpdateModel studentDormCreateUpdateModel);

        /// <summary>
        /// Метода за бришење на студентски дом
        /// </summary>
        /// <param name="DeleteStudentDormById"></param>
        /// <returns>бришење на модел за студентски дом</returns>
        public void DeleteStudentDormById(int id);

        /// <summary>
        /// Метода за наоѓање на студентски дом
        /// </summary>
        /// <param name="GetStudentDormById"></param>
        /// <returns>најди по ид  за студентски дом</returns>
        public StudentDormCreateUpdateModel GetStudentDormById(int studentDormId);

        /// <summary>
        /// Метода за наоѓање на сите студентски домови за дроп даун
        /// </summary>
        /// <param name=""></param>
        /// <returns>студентски домови</returns>
        public List<DropdownViewModel<int>> GetStudentDormsForDropdown();
    }
}
