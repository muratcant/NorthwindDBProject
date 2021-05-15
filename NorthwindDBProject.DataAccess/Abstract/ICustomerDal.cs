using NorthwindDBProject.Core.DataAccess;
using NorthwindDBProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindDBProject.DataAccess.Abstract
{
    public interface ICustomerDal:IRepository<Customer>
    {
    }
}
