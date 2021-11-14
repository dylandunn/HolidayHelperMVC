using HolidayHelper.Data;
using HolidayHelper.Models.GiftIdeaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayHelper.Services.GiftIdeaServices
{
    public class GiftIdeaService
    {
        private readonly Guid _userId;

        public GiftIdeaService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGiftIdea(GiftIdeaCreate model)
        {
            var entity =
                new GiftIdea()
                {
                    OwnerId = _userId,
                    Product = model.Product,
                    Price = model.Price,
                    Location = model.Location,
                    WebsiteLink = model.WebsiteLink
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.GiftIdeas.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GiftIdeaListItem> GetGiftIdeas()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .GiftIdeas
                        .Where(g => g.OwnerId == _userId)
                        .Select(
                        g =>
                            new GiftIdeaListItem
                            {
                                GiftIdeaId = g.GiftIdeaId,
                                Product = g.Product,
                                Price = g.Price
                            }
                        );
                return query.ToArray();
            }
        }
        
        public GiftIdeaDetail GetGiftIdeaById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GiftIdeas
                        .SingleOrDefault(g => g.GiftIdeaId == id && g.OwnerId == _userId);
                return
                    new GiftIdeaDetail
                    {
                        GiftIdeaId = entity.GiftIdeaId,
                        Product = entity.Product,
                        Price = entity.Price,
                        Location = entity.Location,
                        WebsiteLink = entity.WebsiteLink
                    };
            }
        }
        public bool UpdateGiftIdea(GiftIdeaEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .GiftIdeas
                            .SingleOrDefault(g => g.GiftIdeaId == model.GiftIdeaId && g.OwnerId == _userId);
                entity.Product = model.Product;
                entity.Price = model.Price;
                entity.Location = model.Location;
                entity.WebsiteLink = model.WebsiteLink;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGiftIdea(int giftIdeaId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GiftIdeas
                        .SingleOrDefault(g => g.GiftIdeaId == giftIdeaId && g.OwnerId == _userId);
                ctx.GiftIdeas.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
