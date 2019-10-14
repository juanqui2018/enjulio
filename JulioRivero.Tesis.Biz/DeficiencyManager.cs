using JulioRivero.Tesis.Contracts;
using JulioRivero.Tesis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulioRivero.Tesis.Biz
{
    public class DeficiencyManager
    {
        private IDeficiencyDao _deficiencyDao;
        public DeficiencyManager(IDeficiencyDao deficiencyDao)
        {
            _deficiencyDao = deficiencyDao;
        }

        public Deficiency StoreDeficiency(Deficiency deficiency)
        {
            if (deficiency != null)
            {
                if (deficiency.Id == 0)
                {
                    _deficiencyDao.Create(deficiency);
                }
                else
                {
                    _deficiencyDao.Update(deficiency);
                }
            }
            return deficiency;
        }
        public Deficiency GetById(int id)
        {
            return _deficiencyDao.GetForId(id);
        }
        public bool DeleteDeficiency(int id)
        {
            var deficiency = _deficiencyDao.GetForId(id);
            // _deficiencyDao.Update(deficiency);
            _deficiencyDao.Delete(deficiency);
            return true;
        }

        public List<Deficiency> GetAllDeficiencys()
        {                         
            var deficiencys = _deficiencyDao.GetAll().ToList();

            //controlar estados 
            return deficiencys;
        }
    }
}
