using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Service.Model
{
    public class SearchModel
    {
        public string SearchText { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
