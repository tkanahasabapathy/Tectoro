using System;
using System.Collections.Generic;

namespace Tectoro.Models.DB
{
    public partial class Managers
    {
        public int ManagerId { get; set; }
        public int UserId { get; set; }
        public string Position { get; set; }
    }
}
