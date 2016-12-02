using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WmRestClients
{
    public class NewsResult
    {
        public string RowId { get; set; }
        public string CategoryCode { get; set; }
        public string Title { get; set; }
        public string MediumImage { get; set; }
        public string ModifiedAt { get; set; }
        public string Category { get; set; }
    }
}
