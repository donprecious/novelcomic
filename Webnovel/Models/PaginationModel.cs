﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class PaginationModel
    {
        public int Count { get; set;  }
        public int PageCount { get; set;  }
        public int PageNumber { get; set;  }
        public int PageSize { get; set;  }
        public int FirstItemOnPage { get; set;  }
        public int LastItemOnPage { get; set;  }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        
    }
}
