using BusinessLayer.Abstract;
using BusinessLayer.Hashing;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.EDto;
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
        public void WriterAdd(WriterForRegisterDto writer,string password)
        {
            byte[] passwordHash, passwordSalt, mailHash, mailSalt;
            HashingHelper.CreateMailHash(writer.Mail, out mailHash, out mailSalt);
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var newwriter = new Writer
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                WriterImage = writer.WriterImage,
                WriterName = writer.WriterName,
                WriterSurname = writer.WriterSurname,
                WriterMail = writer.Mail,
                WriterStatus = true,
                WriterAbout = writer.WriterAbout,
                WriterTitle = writer.WriterTitle,

            };
            _writerDal.Add(newwriter);

            _writerDal.Add(newwriter);

        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);

        }

        public void WriterUpdate(Writer writer)
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

        public bool Login(Writer w,WriterForLoginDto writer)
        {
            var userToCheck = _writerDal.Get(x => x.WriterMail == writer.Email);
            if (userToCheck == null)
            {
                return false;
            }
            if (!HashingHelper.VerifyPasswordHash(writer.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return false;
            }
            return true;
        }
        public bool Register(WriterForRegisterDto writer, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var newwriter = new Writer
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                WriterImage = writer.WriterImage,
                WriterName = writer.WriterName,
                WriterSurname = writer.WriterSurname,
                WriterMail = writer.Mail,
                WriterStatus = true,
                WriterAbout = writer.WriterAbout,
                WriterTitle = writer.WriterTitle,

            };
            _writerDal.Add(newwriter);
            return true;

        }

        public Writer GetByMail(string mail)
        {
            return _writerDal.Get(x => x.WriterMail == mail);
        }
    }
}
