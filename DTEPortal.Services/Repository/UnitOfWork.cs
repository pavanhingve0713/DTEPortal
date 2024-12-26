using DTEPortal.Data;
using DTEPortal.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTEPortal.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext Context)
        {
            _context = Context;
        }
        public IStatesRepository statesRepository => new StatesRepository(_context);
        public IDivisionRepository divisionRepository => new DivisionRepository(_context);
        public async Task CommitTransactionAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
