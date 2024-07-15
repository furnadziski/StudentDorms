namespace StudentDorms.Models.ViewModels
{
    /// <summary>
    /// Модел во кој се чуваат податоци потребни за dropdown менито
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DropdownViewModel<T>
    {
        /// <summary>
        /// Ид на елементот во dropdown менито
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// Наслов на елементот во dropdown менито
        /// </summary>
        public string Title { get; set; }
    }
}
