using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLCoreWebAPI.Models
{
    public class ConnectionStrings
    {
        public string dbConnectionString { get; set; }
        public string dbName { get; set; }
    }

    public class GitRepositories
    {
        public string nodeRedRepo { get; set; }
    }
}
