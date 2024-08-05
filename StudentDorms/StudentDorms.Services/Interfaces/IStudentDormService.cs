using StudentDorms.Models.Base;
using StudentDorms.Models.CreateUpdateModels;
using StudentDorms.Models.GridModels;
using StudentDorms.Models.SearchModels;
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

    }
}
