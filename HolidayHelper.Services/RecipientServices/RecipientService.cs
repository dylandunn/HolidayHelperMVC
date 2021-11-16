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
        public RecipientDetail GetRecipientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipients
                        .SingleOrDefault(p => p.RecipientId == id && p.OwnerId == _userId);
                return
                    new RecipientDetail
                    {
                        RecipientId = entity.RecipientId,
                        Relation = entity.Relation,
                        Name = entity.Name,
                        Interests = entity.Interests,
                        Avoid = entity.Avoid,
                        BirthDay = entity.BirthDay
                    };
            }
        }
        public bool UpdateRecipient( RecipientEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipients
                        .SingleOrDefault(p => p.RecipientId == model.RecipientId && p.OwnerId == _userId);
                entity.Name = model.Name;
                entity.Interests = model.Interests;
                entity.Avoid = model.Avoid;
                entity.Relation = entity.Relation;
                entity.BirthDay = entity.BirthDay;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipient(int recipientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipients
                        .SingleOrDefault(p => p.RecipientId == recipientId && p.OwnerId == _userId);
                ctx.Recipients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
