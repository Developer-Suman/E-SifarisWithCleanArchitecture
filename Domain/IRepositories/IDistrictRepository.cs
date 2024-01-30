using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IDistrictRepository
    {
        Task<District> GetById(int districtId);
        Task<List<District>> GetAll();
        Task<List<District>> GetProvianceId(int ProvianceId);
    }
}
