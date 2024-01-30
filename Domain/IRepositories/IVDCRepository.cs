using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IVDCRepository
    {
        Task<List<Vdc>> GetAll();
        Task<Vdc> GetById(int VDCId);
        Task<List<Vdc>> GetByDistrictId(int DistrictId);
    }
}
