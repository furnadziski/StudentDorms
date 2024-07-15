using System.Collections.Generic;

namespace StudentDorms.Models.Base
{
    public class SearchResult<T> where T : class
    {
        /// <summary>
        /// Лист од податоци кои ќе се прикажат
        /// </summary>
        public IList<T> Data { get; set; } 

        /// <summary>
        /// Вкупен број податоци во база
        /// </summary>
        public int Count { get; set; }
    }
}
