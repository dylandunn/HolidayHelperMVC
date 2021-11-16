using HolidayHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Models.GiftReminderModels
{
    public class GiftReminderDetail
    {
        public int GiftReminderId { get; set; }
        [Required]
        public int RecipientId { get; set; }
        [Required]
        public virtual ICollection<GiftIdea> GiftIdeas { get; set; }// = new List<GiftIdea>();
        public string Occasion { get; set; }
        public DateTime GiftNeededBy { get; set; }
        public DateTime DaysLeftToBuyGift { get; set; }
    }
}
