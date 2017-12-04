using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace Hotel_Management_System
{
    class Connection
    {
        public OracleConnection thisConnection = new OracleConnection("Data Source=XE; User ID =HMS;Password=HMS;");
    }
}
