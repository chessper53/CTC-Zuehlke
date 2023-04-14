using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTC
{
    internal abstract class Controller
    {
        protected CTCModel Model { get; set; } = new CTCModel();
    }
}
