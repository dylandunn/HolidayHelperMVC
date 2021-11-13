using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Data
{
   public class Recipient
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Key]
        public int RecipientId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Relation { get; set; }
        public string Interests  { get; set; }
        public string Avoid { get; set; }
        public DateTime BirthDay { get; set; }
       // public ICollection<GiftIdea> GiftIdeas { get; set; } = new List<GiftIdea>();
    }
}
