using DTEPortal.Data;
using DTEPortal.Entities.Modals;
using DTEPortal.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTEPortal.Services.Repository
{
    public class StatesRepository : IStatesRepository
    {
        private readonly ApplicationDbContext _context;
        public StatesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MstState>> GetAllStateAsync()
        {
            return await _context.MstState.ToListAsync();
        }
        public async Task<MstState> GetStateByIdAsync(Int16 id)
        {
            return await _context.MstState.FindAsync(id);
        }
        public async Task InsertStateAsync(MstState mstState)
        {

            await _context.MstState.AddAsync(mstState);

        }
        public async Task UpdateState(MstState mstState)
        {

        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
