using HolidayHelper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Models.RecipientModels
{
    public class RecipientCreate
    {
        [Required]
        [MinLength(1, ErrorMessage ="Please enter at least one character")]
        [MaxLength(50, ErrorMessage ="Name contains too many characters")]
        public string Name { get; set; }
        [MaxLength(20, ErrorMessage ="There are too many characters in this field")]
        public string Relation { get; set; }
        [MaxLength(500, ErrorMessage ="There are too many characters in this field")]
        public string Interests { get; set; }
        [MaxLength(500, ErrorMessage = "There are too many characters in this field")]
        public string Avoid { get; set; }
        public DateTime BirthDay { get; set; }

       // public IEnumerable<int> GiftIdeaIds { get; set; } = new List<int>();
    }
}

