using NorthwindDBProject.Core.DataAccess.EntityFramework;
using NorthwindDBProject.DataAccess.Abstract;
using NorthwindDBProject.Entities.Entities;

namespace NorthwindDBProject.DataAccess.Concrete.EntityFramework
{
    public class EFCustomerDemographicDal : EFRepository<CustomerDemographic, NorthwindDBContext>, ICustomerDemographicDal
    {
    }
}
