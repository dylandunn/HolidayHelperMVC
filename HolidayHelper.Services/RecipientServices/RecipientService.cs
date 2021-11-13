using HolidayHelper.Data;
using HolidayHelper.Models.RecipientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Services.RecipientServices
{

    public class RecipientService
    {
        private readonly Guid _userId;

        public RecipientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipient(RecipientCreate model)
        {
            var entity =
                new Recipient()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Relation = model.Relation,
                    Interests = model.Interests,
                    Avoid = model.Avoid,
                    BirthDay = model.BirthDay
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RecipientListItem> GetRecipients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipients
                        .Where(p => p.OwnerId == _userId)
                        .Select(
                           p =>
                                new RecipientListItem
                                {
                                    RecipientId = p.RecipientId,
                                    Name = p.Name,
                                    Relation = p.Relation,
                                    BirthDay = p.BirthDay
                                }
                        );
                return query.ToArray();
            }
        }

    }
}
