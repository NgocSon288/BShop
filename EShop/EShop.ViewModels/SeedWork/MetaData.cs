using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ViewModels.SeedWork
{
    public class MetaData
    {
        public int CurrentPage { get; set; }   
     
        public int TotalPages { get; set; }   
        
        public int PageSize { get; set; }       
        
        public int TotalCount { get; set; }     
        
        public bool HasPrevious => CurrentPage > 1;
        
        public bool HasNext => CurrentPage < TotalPages;
         
        public void DescreaseCount()
        {
            if (TotalCount <= 0)
                return;

            TotalCount--;
            if (TotalCount % PageSize == 0 )
            {
                if(CurrentPage == TotalPages)
                {
                    CurrentPage--;
                }
                TotalPages--;
            } 
        }
    }
}
