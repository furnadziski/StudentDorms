using System;

namespace StudentDorms.Data.Interfaces
{
    /// <summary>
    /// Unit of Work шаблон
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Зачувување на промените
        /// </summary>
        void SaveChanges();
    }
}
