using DTEPortal.Entities.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTEPortal.Services.Contract
{
    public interface IDivisionRepository
    {
        Task<IEnumerable<MstDivision>> GetAllDivisionAsync();
        Task<MstDivision> GetDivisionByIdAsync(int id);
        Task InsertDivisionAsync(MstDivision mstDivision);
        Task UpdateDivision(MstDivision mstDivision);
    }
}
