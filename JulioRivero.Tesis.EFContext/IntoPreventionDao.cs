using JulioRivero.Tesis.Contracts;
using JulioRivero.Tesis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulioRivero.Tesis.EFContext
{
    public class IntoPreventionDao: IIntoPreventionDao
    {
        public void Create(IntoPrevention intoPrevention)
        {
            using (var context = new TesisContext())
            {
                context.IntoPreventions.Add(intoPrevention);
                context.SaveChanges();
            }
        }

        public void Delete(IntoPrevention intoPrevention)
        {
            using (var context = new TesisContext())
            {
                var intoPreventionDelete = context.IntoPreventions.SingleOrDefault(r => r.Id == intoPrevention.Id);
                context.IntoPreventions.Remove(intoPreventionDelete);
                context.SaveChanges();
            }
        }

        public ICollection<IntoPrevention> GetAll()
        {
            List<IntoPrevention> intoPreventions;
            using (var context = new TesisContext())
            {
                intoPreventions = context.IntoPreventions.ToList();
            }
            return intoPreventions;
        }

        public IntoPrevention GetForId(int id)
        {
            IntoPrevention intoPrevention;
            using (var context = new TesisContext())
            {
                intoPrevention = context.IntoPreventions.SingleOrDefault(r => r.Id == id);
            }
            return intoPrevention;
        }

        public void Update(IntoPrevention intoPrevention)
        {
            using (var context = new TesisContext())
            {
                var intoPreventionUpdate = context.IntoPreventions.SingleOrDefault(r => r.Id == intoPrevention.Id);
                if (intoPreventionUpdate != null)
                {
                    intoPreventionUpdate.PreventionId = intoPrevention.PreventionId;
                    intoPreventionUpdate.Kind = intoPrevention.Kind;
                    intoPreventionUpdate.Title = intoPrevention.Title;
                    intoPreventionUpdate.Description = intoPrevention.Description;
                    intoPreventionUpdate.Prevention = intoPrevention.Prevention;
                    intoPreventionUpdate.FileImage = intoPrevention.FileImage;
                }
                context.SaveChanges();
            }
        }
    }
}
