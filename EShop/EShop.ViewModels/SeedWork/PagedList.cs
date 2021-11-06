using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace EShop.ViewModels.SeedWork
{
    public class PagedList<T>
    {
        public MetaData MetaData { get; set; }
        
        public List<T> Items { set; get; }

        public PagedList() { }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            Items = items;
        }

        public PagedList(List<T> All, PagingParameters param)
        {
            var count = All.Count();
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = param.PageSize,
                CurrentPage = param.PageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)param.PageSize)
            };

            Items = All 
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize)
                .ToList(); 
        }
    }
}
