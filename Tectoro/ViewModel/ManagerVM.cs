using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tectoro.Models.DB;

namespace Tectoro.ViewModel
{
    public class ManagerVM
    {
        public int ManagerId { get; set; }
        public string Position { get; set; }
        public Users user { get; set; }
        public List<Clients> clients { get; set; }
    }
}
