namespace StudentDorms.Models.Base
{
    /// <summary>
    /// Модел во кој се чуваат податоци за сортирање и страничење
    /// </summary>
    public class BaseSearchModel
    {
        /// <summary>
        /// Колона по  која ќе се прави сортирање
        /// </summary>
        public string OrderColumn { get; set; }

        /// <summary>
        /// Насока по која ќе се прави сортирање
        /// </summary>
        public string OrderDirection { get; set; }

        /// <summary>
        /// Број на страна која е одбрана
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Број на редици на една страна
        /// </summary>
        public int RowsPerPage { get; set; }

    }
}
