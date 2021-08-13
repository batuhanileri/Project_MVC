using EntityLayer.Concrete;
using EntityLayer.EDto;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Manager> GetList();
        bool Login(AdminForLoginDto admin);
        void AdminAdd(AdminForRegisterDto adminregister, string password);
        Manager GetById(int id);
        Manager GetByName(String name);
        Manager GetByMail(String mail);
        void ChangeRole(int id, String role);
        void AdminDelete(Manager admin);
        void AdminUpdate(Manager admin);
    }
}
