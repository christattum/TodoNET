
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace TodoNET.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int TotalCount { get; private set; }
        public int PageSize { get; private set; }
        public int Page { get; private set; }

        public static PagedList<T> CreatePagedList(ICriteria criteria, int pageSize, int page, string sort=null, string sortdir=null)
        {
            var result = new PagedList<T>(pageSize, page);

            // clone criteria so we can count the total rows
            ICriteria countCriteria = CriteriaTransformer.Clone(criteria);
            result.TotalCount = countCriteria
                            .SetProjection(Projections.RowCount())
                            .UniqueResult<int>();


            // clone criteria so we can filter to a page of T
            ICriteria itemCriteria = CriteriaTransformer.Clone(criteria);

            // apply sorting for items (can't do this to criteria passed in (count won't work with an OrderBy), so that's why we do it internally here)
            if (sort != null)
            {
                itemCriteria.AddOrder(sortdir == "DESC" ? Order.Desc(sort) : Order.Asc(sort));
            }


            int firstResult = pageSize * (page - 1);
            IList<T> items = itemCriteria
                                .SetFirstResult(firstResult)
                                .SetMaxResults(pageSize)
                                .List<T>();

            // add the page of items
            result.AddRange(items);

            return result;
        }

        private PagedList(int pageSize, int page)
        {
            PageSize = pageSize;
            Page = page;
        }


        
    }

}