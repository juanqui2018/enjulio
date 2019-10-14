using JulioRivero.Tesis.Contracts;
using JulioRivero.Tesis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulioRivero.Tesis.Biz
{
    public class PreventionManager
    {
        private IPreventionDao _preventionDao;
        public PreventionManager(IPreventionDao preventionDao)
        {
            _preventionDao = preventionDao;
        }

        public Prevention StorePrevention(Prevention prevention)
        {
            if (prevention != null)
            {
                if (prevention.Id == 0)
                {
                    _preventionDao.Create(prevention);
                }
                else
                {
                    _preventionDao.Update(prevention);
                }
            }
            return prevention;
        }
        public Prevention GetById(int id)
        {
            return _preventionDao.GetForId(id);
        }
        public bool DeletePrevention(int id)
        {
            var prevention = _preventionDao.GetForId(id);
            // _deficiencyDao.Update(deficiency);
            _preventionDao.Delete(prevention);
            return true;
        }

        public List<Prevention> GetAllPreventions()
        {
            var preventions = _preventionDao.GetAll().ToList();
            string describ;
            int start = 0, sizeString = 100;
            foreach (var item in preventions)
            {
                if (item.Description.Length > sizeString)
                {
                    describ = item.Description.Substring(start, sizeString);
                    item.Description = string.Format(describ + "...");
                }
            }
            //controlar estados 
            return preventions;
        }
    }
}
