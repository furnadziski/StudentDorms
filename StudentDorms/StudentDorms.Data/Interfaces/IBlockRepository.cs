using StudentDorms.Data.Extensions;
using StudentDorms.Domain.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Interfaces
{     /// <summary>
      /// Репозитори за блокови
      /// </summary>
    public interface IBlockRepository : IGenericRepository<Block>
    {
        /// <summary>
        /// Метод кој враќа дали блокот е поврзан со некоја соба (returns true if there is room associated)
        /// </summary>
        /// <param name="blockid"></param>
        /// <returns></returns>
        public bool HasAssociatedRooms(int blockId);

        /// <summary>
        /// Метод кој враќа блок за ажурирање
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Block GetBlockForUpdateById(int id);
        public IEnumerable<Block> GetBlockByStudentDormId(int id);
    }

}
