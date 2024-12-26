using DTEPortal.Entities.Modals;
using DTEPortal.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTEPortal.BusinessLayer.Masters
{
    public class StateMasterBL
    {
        readonly IUnitOfWork _unitOfWork;
        public StateMasterBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MstState>> GetAllStateAsync()
        {
            return await _unitOfWork.statesRepository.GetAllStateAsync();
        }

        public async Task InsertStateAsync(MstState mstState)
        {
            await _unitOfWork.statesRepository.InsertStateAsync(mstState);
            await _unitOfWork.CommitTransactionAsync();
        }

        public async Task<MstState> GetStateByIdAsync(Int16 id)
        {
            return await _unitOfWork.statesRepository.GetStateByIdAsync(id);
        }

        public async Task UpdateState(MstState mstState)
        {
            await _unitOfWork.statesRepository.UpdateState(mstState);
            await _unitOfWork.CommitTransactionAsync();
        }
    }
}
