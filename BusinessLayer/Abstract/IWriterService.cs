using EntityLayer.Concrete;
using EntityLayer.EDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAdd(Writer writer);
        Writer GetById(int id);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        bool Login(WriterForLoginDto writer);
        void Register(WriterForRegisterDto writer, string password);
    }
}
