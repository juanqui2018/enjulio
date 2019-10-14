using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JulioRivero.Tesis.Contracts;
using JulioRivero.Tesis.Entities;

namespace JulioRivero.Tesis.Biz
{
    public class ImpairmentManager
    {
        private IImpairmentDao  _impairmentDao;
        public ImpairmentManager(IImpairmentDao impairmentDao)
        {
            _impairmentDao = impairmentDao;
        }

        public Impairment StoreImpairment(Impairment impairment)
        {
            if (impairment != null)
            {
                if (impairment.Id == 0)
                {
                    _impairmentDao.Create(impairment);
                }
                else
                {
                    _impairmentDao.Update(impairment);
                }
            }
            return impairment;
        }
        public Impairment GetById(int id)
        {
            return _impairmentDao.GetForId(id);
        }
        public bool DeleteImpairment(int id)
        {
            var impairment = _impairmentDao.GetForId(id);
            // _impairmentDao.Update(imparirment);
            _impairmentDao.Delete(impairment);
            return true;
        }

        public List<Impairment> GetAllImpairments()
        {
            var impairments = _impairmentDao.GetAll().ToList();
            string describ;
            int start = 0, sizeString = 100;
            foreach (var item in impairments)
            {
                if (item.Description.Length > sizeString)
                {
                    describ = item.Description.Substring(start, sizeString);
                    item.Description = string.Format(describ + "...");
                }
            }
            //controlar estados 
            return impairments;
        }
    }
}
