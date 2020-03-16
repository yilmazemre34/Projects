using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbisSystem.Model.Model;

namespace MBisASystem.BLL.Abstract
{
    public interface IPersonelService
    {
        Personel GetByPersonelLogin(string username, string password);
    }
}
