using HolidayHelper.Data;
using HolidayHelper.Models.GiftReminderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Services.GiftReminderServices
{
    public class GiftReminderService
    {
        private readonly Guid _userId;

        public GiftReminderService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<GiftReminderListItem> GetGiftReminders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .GiftReminders
                        .Where(g => g.OwnerId == _userId)
                        .Select(
                        g =>
                            new GiftReminderListItem
                            {
                                GiftReminderId = g.GiftReminderId,
                                RecipientId = g.RecipientId,
                                GiftIdeas = g.GiftIdeas,
                                GiftNeededBy = g.GiftNeededBy
                            }
                        );
                return query.ToArray();
            }
        }
        public GiftReminderDetail GetGiftReminderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GiftReminders
                        .SingleOrDefault(g => g.GiftReminderId == id && g.OwnerId == _userId);
                return
                    new GiftReminderDetail
                    {
                        GiftReminderId = entity.GiftReminderId,
                        RecipientId = entity.RecipientId,
                        GiftIdeas = entity.GiftIdeas,
                        Occasion = entity.Occasion,
                        GiftNeededBy = entity.GiftNeededBy,
                    };
            }
        }

        public bool UpdateGiftReminder(GiftReminderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.
                    GiftReminders
                    .SingleOrDefault(g => g.GiftReminderId == model.GiftReminderId && g.OwnerId == _userId);
                entity.Occasion = model.Occasion;
                entity.GiftNeededBy = model.GiftNeededBy;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGiftReminder(int giftReminderId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GiftReminders
                        .SingleOrDefault(g => g.GiftReminderId == giftReminderId && g.OwnerId == _userId);
                ctx.GiftReminders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
       
    }
}
