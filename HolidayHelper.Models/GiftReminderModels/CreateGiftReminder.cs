using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Models.GiftReminderModels
{
   public class CreateGiftReminder
    {
        [Required]
        public int RecipientId { get; set; }
        public IEnumerable<int> GiftIdeaIds { get; set; } = new List<int>();
        public string Occasion { get; set; }
        public DateTime GiftNeededBy { get; set; }
    }
}
