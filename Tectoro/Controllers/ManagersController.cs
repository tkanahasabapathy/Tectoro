using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tectoro.Models.DB;
using Tectoro.ViewModel;

namespace Tectoro.Controllers
{
    [Route("api")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly TectoroContext _context;

        public ManagersController(TectoroContext context)
        {
            _context = context;
        }

        [Route("GetManagers")]
        [HttpGet]
        public IEnumerable<ManagerVM> GetManagers()
        {
            DbSet<Managers> dbManagers = _context.Managers;
            DbSet<Clients> dbClients = _context.Clients;
            DbSet<Users> dbUsers = _context.Users;

            IEnumerable<ManagerVM> result = (from m in dbManagers join u in dbUsers
                                      on m.UserId equals u.UserId 
                                      select (new ManagerVM {
                                                ManagerId = m.ManagerId,
                                                Position = m.Position,
                                                user = new Users { 
                                                        UserId = u.UserId,
                                                        UserName = u.UserName,
                                                        Alias = u.Alias,
                                                        FirstName = u.FirstName,
                                                        LastName = u.LastName,
                                                        Email = u.Email
                                                    },
                                                clients = dbClients.Where(c => c.ManagerId == m.ManagerId).ToList()
                                            })).ToList();
            return result;
        }

    }
}