using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetapi.Data.Models
{
    public class tblComments
    {
        public int id { get; set; }
        public int tblTipsId { get; set; }

        public string Comments { get; set; }
        public string createdby { get; set; }
        public DateTime created { get; set; }


    }

}

