using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Models.RecipientModels
{
    public class RecipientDetail
    {
        public int RecipientId { get; set; }
        public string Name { get; set; }
        public string Relation { get; set; }
        public string Interests { get; set; }
        public string Avoid { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
