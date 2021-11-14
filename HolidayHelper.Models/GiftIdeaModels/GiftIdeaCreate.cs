using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Models.GiftIdeaModels
{
    public class GiftIdeaCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least one character")]
        [MaxLength(50, ErrorMessage = "Product contains too many characters")]
        public string Product { get; set; }
        public double Price { get; set; }
        [MaxLength(50, ErrorMessage = "There are too many characters in this field")]
        public string Location { get; set; }
        public string WebsiteLink { get; set; }
    }
}
