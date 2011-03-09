
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace TodoNET.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }

        public PagedList(ICriteria criteria, int pageSize, int page)
        {
            PageSize = pageSize;
            Page = page;

            // clone criteria so we can count the total rows
            ICriteria countCriteria = CriteriaTransformer.Clone(criteria);
            TotalCount = countCriteria
                            .SetProjection(Projections.RowCount())
                            .UniqueResult<int>();


            // clone criteria so we can filter to a page of T
            ICriteria itemCriteria = CriteriaTransformer.Clone(criteria);

            int firstResult = pageSize * (page - 1);
            IList<T> items = itemCriteria
                                .SetFirstResult(firstResult)
                                .SetMaxResults(pageSize)
                                .List<T>();

            // add the page of items
            AddRange(items);
        }


        
    }

}