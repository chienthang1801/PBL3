using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net4.DTO
{
    public delegate void MoneyAcception(Naptien nt);
    public class Naptien : EventArgs
    {
        public string money { get; set; }
    }
}
