using JulioRivero.Tesis.Contracts;
using JulioRivero.Tesis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulioRivero.Tesis.EFContext
{
    public class DeficiencyDao : IDeficiencyDao
    {
        public void Create(Deficiency deficiency)
        {
            using (var context = new TesisContext())
            {
                context.Deficiencis.Add(deficiency);
                context.SaveChanges();
                //context.Deficiencis.Add(deficiency);
                //context.SaveChanges();
            }
        }

        public void Delete(Deficiency deficiency)
        {
            using (var context = new TesisContext())
            {
                var deficiencyDelete = context.Deficiencis.SingleOrDefault(r => r.Id == deficiency.Id);
                context.Deficiencis.Remove(deficiencyDelete);
                context.SaveChanges();
            }
        }

        public ICollection<Deficiency> GetAll()
        {
            List<Deficiency> deficiencis;
            using (var context = new TesisContext())
            {
                deficiencis = context.Deficiencis.ToList();
            }
            return deficiencis;
        }

        public Deficiency GetForId(int id)
        {
            Deficiency deficiency;
            using (var context = new TesisContext())
            {
                deficiency = context.Deficiencis.SingleOrDefault(r => r.Id == id);
            }
            return deficiency;
        }

        public void Update(Deficiency deficiency)
        {
            using (var context = new TesisContext())
            {
                var deficiencyUpdate = context.Deficiencis.SingleOrDefault(r => r.Id == deficiency.Id);
                if (deficiencyUpdate != null)
                {
                    deficiencyUpdate.ImpairmentId = deficiency.ImpairmentId;
                    deficiencyUpdate.Kind = deficiency.Kind;
                    deficiencyUpdate.Name = deficiency.Name;
                    deficiencyUpdate.Introduction = deficiency.Introduction;
                    deficiencyUpdate.Symptom = deficiency.Symptom;
                    deficiencyUpdate.Prevention = deficiency.Prevention;
                    deficiencyUpdate.FileImage = deficiency.FileImage;
                }
                context.SaveChanges();
            }
        }
    }
}
