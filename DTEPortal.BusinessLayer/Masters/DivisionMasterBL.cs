using DTEPortal.Entities.Modals;
using DTEPortal.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTEPortal.BusinessLayer.Masters
{
    public class DivisionMasterBL
    {
        private readonly IUnitOfWork _unitOfWork;

        public DivisionMasterBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MstDivision>> GetAllDivisionAsync()
        {
            return await _unitOfWork.divisionRepository.GetAllDivisionAsync().ConfigureAwait(false);
        }
        public async Task<MstDivision> GetDivisionByIdAsync(int id)
        {
            return await _unitOfWork.divisionRepository.GetDivisionByIdAsync(id);
        }
        public async Task InsertDivisionAsync(MstDivision mstDivision)
        {
            await _unitOfWork.divisionRepository.InsertDivisionAsync(mstDivision);
            await _unitOfWork.CommitTransactionAsync();
        }
        public async Task UpdateDivision(MstDivision mstDivision)
        {
            await _unitOfWork.divisionRepository.UpdateDivision(mstDivision);
            await _unitOfWork.CommitTransactionAsync();
        }
    }
}
