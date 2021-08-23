using BusinessLayer.Abstract;
using BusinessLayer.Hashing;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.EDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(AdminForRegisterDto adminregister, string password)
        {
            byte[] passwordHash, passwordSalt, mailHash, mailSalt;
            HashingHelper.CreateMailHash(adminregister.Mail, out mailHash, out mailSalt);
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var admin = new Manager
            {
                Role = adminregister.AdminRole,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                AdminUserNameHash = mailHash,
                AdminUserNameSalt = mailSalt,
                UserName = adminregister.UserName,
                Status = true,
                Mail = adminregister.Mail
                
                

            };
            _adminDal.Add(admin);
        }

        public void AdminDelete(Manager admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Manager admin)
        {
            //byte[] passwordHash, passwordSalt, mailHash, mailSalt;
            //HashingHelper.CreateMailHash(adminregister.Mail, out mailHash, out mailSalt);
            //HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            //var admin = new Admin
            //{
            //    Role = adminregister.AdminRole,
            //    PasswordHash = passwordHash,
            //    PasswordSalt = passwordSalt,
            //    AdminUserNameHash = mailHash,
            //    AdminUserNameSalt = mailSalt,
            //    UserName = adminregister.UserName,
            //    Status = true

            //};

            _adminDal.Update(admin);
        }

        public Manager GetById(int id)
        {
            return _adminDal.Get(x => x.Id == id);
        }
        public bool Login(Manager manager,AdminForLoginDto admin)
        {
            var userToCheck = GetByMail(admin.Email);
            
                if (userToCheck == null)
                {
                    return false;
                }
                if (!HashingHelper.VerifyPasswordHash(admin.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt) &&
                    !HashingHelper.VerifyMailHash(admin.Email, userToCheck.AdminUserNameHash, userToCheck.AdminUserNameSalt))
                {
                    return false;
                }

            return true;
            //return userToCheck.Status;
        }
        public bool Register(AdminForRegisterDto adminregister, string password)
        {
            byte[] passwordHash, passwordSalt, mailHash, mailSalt;
            HashingHelper.CreateMailHash(adminregister.Mail, out mailHash, out mailSalt);
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var admin = new Manager
            {
                Role = adminregister.AdminRole,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                AdminUserNameHash = mailHash,
                AdminUserNameSalt = mailSalt,
                UserName = adminregister.UserName,
                Status = true,
                Mail = adminregister.Mail

            };
            _adminDal.Add(admin);
            return true;
        }
        public List<Manager> GetList()
        {
            return _adminDal.GetAll();
        }

        public Manager GetByName(String name)
        {
            return _adminDal.Get(x => x.UserName == name);
        }
        public Manager GetByMail(String mail)
        {
            return _adminDal.Get(x => x.Mail == mail);
        }
        public void ChangeRole(int id, string role)
        {
            var value = _adminDal.Get(x => x.Id == id);
            value.Role = role;
            _adminDal.Update(value);
        }

        public void AdminDeleteStatus(Manager manager)
        {
            manager.Status = false;
            _adminDal.Update(manager);

        }
    }
}
