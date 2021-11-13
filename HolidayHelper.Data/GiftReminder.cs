using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Data
{
    public class GiftReminder
    {
        [Key]
        public int GiftReminderId { get; set; }
        [ForeignKey(nameof(Recipient))]
        public int RecipientId { get; set; }
        public virtual Recipient Recipient { get; set; }
        public virtual ICollection<GiftIdea> GiftIdea { get; set; } = new List<GiftIdea>();
        public string Occasion { get; set; }
        public DateTime CreatedDate  { get; set; }
        public DateTime GiftNeededBy { get; set; }

    }
}
