using DTEPortal.Entities.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTEPortal.Services.Contract
{
    public interface IStatesRepository : IDisposable
    {
        Task<IEnumerable<MstState>> GetAllStateAsync();
        Task<MstState> GetStateByIdAsync(Int16 id);
        Task InsertStateAsync(MstState mstState);
        Task UpdateState(MstState mstState);
    }
}
