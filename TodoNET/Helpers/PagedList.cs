
using System.Collections.Generic;

namespace TodoNET.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int TotalCount { get; set; }

        public PagedList(IEnumerable<T> source, int totalCount)
        {
            this.TotalCount = totalCount;
            this.AddRange(source);
        }

        
    }

}