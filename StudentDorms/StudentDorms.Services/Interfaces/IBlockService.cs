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
{   /// <summary>
    /// Сервисен интерфејс за менаџирање на блокови
    /// </summary>
    public interface IBlockService 
    {
        /// <summary>
        /// Метода за прикажување и филтрирање на податоци на Грид
        /// </summary>
        /// <param name="blockSearchModel"></param>
        /// <returns>Листа од Грид модел за блокот</returns>
        public SearchResult<BlockGridModel> GetBlocksForGrid(BlockSearchModel blockSearchModel);

        /// <summary>
        /// Метод за креирање на блок
        /// </summary>
        /// <param name="blockCreateUpdateModel"></param>
        /// <returns>креирање на модел за блок</returns>
        void CreateBlock(BlockCreateUpdateModel blockCreateUpdateModel);

        /// <summary>
        /// Метод за едитирање на блок
        /// </summary>
        /// <param name="blockCreateUpdateModel"></param>
        /// <returns>Едитирање на модел за блок</returns>
        public void UpdateBlock(BlockCreateUpdateModel blockCreateUpdateModel);

        /// <summary>
        /// Метод за бришање на блок
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Бришање на модел за блок</returns>
        public void DeleteBlockById(int id);

        /// <summary>
        /// Метод за наоѓање на блок
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns>наоѓање на модел за блок</returns>
        public BlockViewModel GetBlockById(int blockId);

        public List<DropdownViewModel<int>> GetBlocksForDropdown();
        public List<DropdownViewModel<int>> GetBlocksForDropdownByStudentDormId(int StudentDormid);
    }
}
