using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tectoro.Models.DB;

namespace Tectoro.ViewModel
{
    public class ClientVM
    {
        public int ClientId { get; set; }
        public Users user { get; set; }
        public int Level { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }

    }
}
