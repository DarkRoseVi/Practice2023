using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorMarketPlaceWpf.Models
{
    partial class Useer
    {
        public string Fullname
        {
            get
            {
                return LastName + " " + Name + " " + SurName;
            }
        }
    }
}
