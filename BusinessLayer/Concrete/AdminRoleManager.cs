using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminRoleManager : IAdminRoleService
    {
        IAdminRoleDal _adminRoleDal;
        public AdminRoleManager(IAdminRoleDal adminRoleDal)
        {
            _adminRoleDal = adminRoleDal;
        }
        

        public List<AdminRole> GetList()
        {
           return _adminRoleDal.GetAll();

        }
    }
}
