using StudentDorms.Data.Extensions;
using StudentDorms.Domain.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDorms.Data.Interfaces
{ /// <summary>
  /// Репозитори за студентски домови
  /// </summary>
   public interface IStudentDormRepository : IGenericRepository<StudentDorm>
    {

        /// <summary>
        /// Метод кој враќа дали студентскиот дом е поврзан со некој блок(returns true if there is block associated)
        /// </summary>
        /// <param name="studentDormId"></param>
        /// <returns></returns>
        public bool HasAssociatedBlocks(int studentDormId);
    }
}
