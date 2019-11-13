using System;
using System.Collections.Generic;
using System.Text;

namespace Estapar.Core.Pagination
{
    public class Paging<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public Paging(IEnumerable<T> list, int page, int pageSize, int totalRecords)
        {
            Items = list;
            Page = page;
            PageSize = pageSize;
            TotalRecords = totalRecords;
        }
    }
}
