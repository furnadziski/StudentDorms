using System.Collections.Generic;

namespace StudentDorms.Data.Interfaces
{
    public interface IProcedureRepository
    {
        /// <summary>
        /// Генеричко репозитори за процедури
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        public interface IProcedureRepository<TEntity> where TEntity : class
        {
            /// <summary>
            /// Извршување на процедура којa враќа листа
            /// </summary>
            /// <param name="queryName"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            List<TEntity> ExecListResultQuery(string queryName, object[] parameters);

            /// <summary>
            /// Извршување на процедура којa враќа еден резултат
            /// </summary>
            /// <param name="queryName"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            TEntity ExecSingleResultQuery(string queryName, object[] parameters);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="queryName"></param>
            /// <param name="parameters"></param>
            void ExecuteSqlCommand(string queryName, object[] parameters);

        }
    }
}
