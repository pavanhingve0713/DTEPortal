using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTEPortal.Services.Contract
{
    public interface IUnitOfWork
    {
        IStatesRepository statesRepository { get; }
        IDivisionRepository divisionRepository { get; }
        Task CommitTransactionAsync();
    }
}
