using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class ContentHistoryVm
    {
        public int ContentId {get;set;}
     
            public string Progress { get; set; }
            public string Title { get; set; }
            public string LastOpened { get; set; }
            public DateTime LastDateOpened { get; set; }

            public int OpenTimes { get; set; }
            public string ContentType { get; set; }
            public int TotalSubContent { get; set; }

    }
}
