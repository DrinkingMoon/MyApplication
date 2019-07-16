using MyWpfMVVMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyWpfMVVMApp.Service
{
    public class SqlDataService : IDataService<Restaurant>
    {
        public Restaurant GetItem()
        {
            return GetList().First();
        }

        public ICollection<Restaurant> GetList()
        {
            using (DataContext ctx = new DataContext())
            {
                var varData = from a in ctx.Set<Restaurant>().Include(k => k.Dishes)
                              select a;

                return varData.ToList();
            }
        }

        public void SaveInfo(Restaurant model)
        {
            using (DataContext ctx = new DataContext())
            {
                if (model.PKID == null)
                {
                    model.PKID = Guid.NewGuid();
                    ctx.Restaurants.Add(model);
                }
                else
                {
                    Restaurant tempRes = (from a in ctx.Restaurants
                                          where a.PKID == model.PKID
                                          select a).First();

                    tempRes.Name = model.Name;
                    tempRes.PhoneNumber = model.PhoneNumber;
                    tempRes.Address = model.Address;
                }

                foreach (Dish item in model.Dishes)
                {
                    if (item.PKID == null)
                    {
                        item.PKID = Guid.NewGuid();
                        ctx.Dishes.Add(item);
                    }
                    else
                    {
                        Dish tempDish = (from a in ctx.Dishes
                                         where a.PKID == item.PKID
                                         select a).First();

                        tempDish.Category = item.Category;
                        tempDish.Comment = item.Comment;
                        tempDish.Name = item.Name;
                        tempDish.Score = item.Score;
                        tempDish.FKID_Restaurant = (Guid)model.PKID;
                    }
                }

                ctx.SaveChanges();
            }
        }
    }
}
