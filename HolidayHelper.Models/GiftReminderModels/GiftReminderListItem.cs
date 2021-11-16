using HolidayHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Models.GiftReminderModels
{
    public class GiftReminderListItem
    {
        public int GiftReminderId { get; set; }
        public int RecipientId { get; set; }
        public virtual Recipient Recipient { get; set; }
        public virtual ICollection<GiftIdea> GiftIdeas { get; set; } //= new List<GiftIdea>();
        public DateTime GiftNeededBy { get; set; }
    }
}

