using JulioRivero.Tesis.Contracts;
using JulioRivero.Tesis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulioRivero.Tesis.Biz
{
    public class IntoPreventionManager
    {
        private IIntoPreventionDao _intoPreventionDao;
        public IntoPreventionManager(IIntoPreventionDao intoPreventionDao)
        {
            _intoPreventionDao = intoPreventionDao;
        }

        public IntoPrevention StoreIntoPrevention(IntoPrevention intoPrevention)
        {
            if (intoPrevention != null)
            {
                if (intoPrevention.Id == 0)
                {
                    _intoPreventionDao.Create(intoPrevention);
                }
                else
                {
                    _intoPreventionDao.Update(intoPrevention);
                }
            }
            return intoPrevention;
        }
        public IntoPrevention GetById(int id)
        {
            return _intoPreventionDao.GetForId(id);
        }
        public bool DeleteIntoPrevention(int id)
        {
            var intoPrevention = _intoPreventionDao.GetForId(id);
            // _deficiencyDao.Update(deficiency);
            _intoPreventionDao.Delete(intoPrevention);
            return true;
        }

        public List<IntoPrevention> GetAllIntoPreventions()
        {
            var intoPreventions = _intoPreventionDao.GetAll().ToList();

            //controlar estados 
            return intoPreventions;
        }
    }
}
