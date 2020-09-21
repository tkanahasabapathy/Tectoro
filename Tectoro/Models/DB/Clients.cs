using System;
using System.Collections.Generic;

namespace Tectoro.Models.DB
{
    public partial class Clients
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public int Level { get; set; }
        public int ManagerId { get; set; }
    }
}
