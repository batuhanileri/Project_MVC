using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public void CategoryAdd(Writer writer)
        {
            _writerDal.Add(writer);

        }

        public void CategoryDelete(Writer writer)
        {
            _writerDal.Delete(writer);

        }

        public void CategoryUpdate(Writer writer)
        {
            _writerDal.Update(writer);

        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);

        }

        public List<Writer> GetList()
        {
            return _writerDal.GetAll();
       
        }
    }
}
