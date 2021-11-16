using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Models.GiftReminderModels
{
    public class GiftReminderEdit
    {
        public int GiftReminderId  { get; set; }
        public DateTime GiftNeededBy { get; set; }
        public string Occasion { get; set; }
    }
}
