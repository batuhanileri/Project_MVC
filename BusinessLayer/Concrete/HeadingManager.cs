using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal=headingDal;
        }
        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.GetAll();
        }

        public List<Heading> GetListByWriter()
        {
            return _headingDal.GetAll(x => x.WriterId == 4);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Add(heading);

        }

        public void HeadingDelete(Heading heading)
        {
            
            _headingDal.Update(heading);
        }

        public void HeadingDeleteStatus(Heading heading)
        {
            _headingDal.Delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
