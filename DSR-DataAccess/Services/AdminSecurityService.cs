using DSR_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSR_DataAccess.Services
{
    public class AdminSecurityService : IAdminSecurityService
    {
        public Dsradmin GetDsradmin(Dsradmin dsradmin)
        {
            using (var db = new DsrContext())
            {
                Dsradmin dsrresult = db.Dsradmins.Where(x => x.Username == dsradmin.Username && x.Password == dsradmin.Password).SingleOrDefault();
                return dsrresult;
            }
        }

    }
}
