using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal abstract class Controller
    {
        protected CTCModel Model { get; set; }
        protected MySqlConnection DbConnection { get; set; }
    }
}
