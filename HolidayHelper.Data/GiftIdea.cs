using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Data
{
    public class GiftIdea
    {
        [Key]
        public int GiftIdeaId { get; set; }
        public int RecipientId { get; set; }
        public virtual Recipient Recipient { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public string WebsiteLink { get; set; }
    }
}
