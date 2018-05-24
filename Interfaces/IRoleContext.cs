using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FTHWebapp.Models;
using FTHWebapp.SqlContext;
using FTHWebapp.Controllers;
using FTHWebapp.Repository;
using FTHWebapp.Models.DomainClasses;

namespace FTHWebapp.Interfaces
{
    public interface IRoleContext
    {
        List<Role> GetAllRoles();

    }
}
