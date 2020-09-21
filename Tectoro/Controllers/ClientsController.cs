using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using Tectoro.Models.DB;
using Tectoro.ViewModel;

namespace Tectoro.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly TectoroContext _context;
        IEnumerable<ClientVM> _clients;

        public ClientsController(TectoroContext context)
        {
            _context = context;
        }

        [Route("GetClients")]
        [HttpGet]
        public IEnumerable<ClientVM> GetClients()
        {
            DbSet<Managers> dbManagers = _context.Managers;
            DbSet<Clients> dbClients = _context.Clients;
            DbSet<Users> dbUsers = _context.Users;

            IEnumerable<ClientVM> _clients = (from c in dbClients
                                              join u in dbUsers
                                                 on c.UserId equals u.UserId
                                              join m in dbManagers
                                                 on c.ManagerId equals m.ManagerId
                                              select (new ClientVM
                                              {
                                                  ClientId = c.ClientId,
                                                  Level = c.Level,
                                                  user = new Users
                                                  {
                                                      UserId = u.UserId,
                                                      UserName = u.UserName,
                                                      Alias = u.Alias,
                                                      FirstName = u.FirstName,
                                                      LastName = u.LastName,
                                                      Email = u.Email
                                                  },
                                                  ManagerId = m.ManagerId,
                                                  ManagerName = dbUsers.Where(u => u.UserId == m.UserId).Select(o => o.UserName).FirstOrDefault()
                                              })).ToList();
            return _clients;
        }

        [Route("GetClientsByManagerName")]
        [HttpGet]
        public IEnumerable<ClientVM> GetClientsByManagerName(string strManagerName)
        {

            if (_clients == null)
            {
                _clients = GetClients();
            }
            return _clients.Where(c => c.ManagerName == strManagerName).ToList();
        }
    }

}