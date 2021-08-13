using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IAdminRoleService
    {
        List<AdminRole> GetList();
    }
}
