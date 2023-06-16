using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliedHealth.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository City { get; }
        IDistrictRepository District { get; }
        IProvinceRepository Province { get; }

        int Save();
    }
}
