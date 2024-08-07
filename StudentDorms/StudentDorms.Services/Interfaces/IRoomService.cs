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
    /// Сервисен интерфејс за менаџирање на соби
    /// </summary>
    public interface IRoomService
    {
        /// <summary>
        /// Метода за прикажување и филтрирање на податоци на Грид
        /// </summary>
        /// <param name="roomSearchModel"></param>
        /// <returns>Листа од Грид модел за собата</returns>
        public SearchResult<RoomGridModel> GetRoomsForGrid(RoomSearchModel roomSearchModel);

        /// <summary>
        /// Метода за креирање на соби
        /// </summary>
        /// <param name="roomCreateUpdateModel"></param>
        /// <returns>креирање на соба</returns>
        public void CreateRoom(RoomCreateUpdateModel roomCreateUpdateModel);

        /// <summary>
        /// Метода за едитирање на соба
        /// </summary>
        /// <param name="roomCreateUpdateModel"></param>
        /// <returns>едитирање на соба</returns>
        public void UpdateRoom(RoomCreateUpdateModel roomCreateUpdateModel);

        /// <summary>
        /// Метода за бришење на соби
        /// </summary>
        /// <param name="id"></param>
        /// <returns>бришење на соба</returns>
        public void DeleteRoomById(int id);
    }
}
