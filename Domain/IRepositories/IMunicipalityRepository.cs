using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IMunicipalityRepository
    {
        Task<Municipality> GetById(int municipalityId);
        Task<List<Municipality>> GetAll();
        Task<List<Municipality>> GetByDistrictId(int districtId);
    }
}
