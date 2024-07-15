using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDorms.Data.Extensions
{
    /// <summary>
    /// Генеричко репозитори
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Метод кој пребарува според id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Враќа еден елемент со тоа id</returns>
        T GetById(object Id);

        /// <summary>
        /// Метод за листање на сите елементи 
        /// </summary>
        /// <returns>Листа од елементи</returns>
        List<T> GetAll();

        /// <summary>
        /// Метод за креирање нов елемент
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Create(T entity);

        /// <summary>
        /// Метод за едитирање на елемент
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(T entity);

        /// <summary>
        /// Метод за бришење на елемент
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Delete(T entity);

        /// <summary>
        /// Метод за бришење на елемент според дадено id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteById(object id);

    }
}
