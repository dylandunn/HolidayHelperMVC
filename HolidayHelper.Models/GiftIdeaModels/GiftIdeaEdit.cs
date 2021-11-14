using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Models.GiftIdeaModels
{
    public class GiftIdeaEdit
    {
        public int GiftIdeaId { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public string WebsiteLink { get; set; }
    }
}
