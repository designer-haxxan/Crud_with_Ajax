using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud_with_Ajax.Models
{
    public class StudentViewModel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Nullable<bool> isdeleted { get; set; }
        public Nullable<long> dpt { get; set; }

        public string dpname { get; set; }

      
    }
}