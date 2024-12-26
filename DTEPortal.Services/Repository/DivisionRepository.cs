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
    public class DivisionRepository : IDivisionRepository
    {
        readonly ApplicationDbContext _context;
        public DivisionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MstDivision>> GetAllDivisionAsync()
        {
            return await _context.MstDivision.Include(x => x.MstState).ToListAsync();
        }
        public async Task<MstDivision> GetDivisionByIdAsync(int id)
        {
            return await _context.MstDivision.FindAsync(id);
        }
        public async Task InsertDivisionAsync(MstDivision mstDivision)
        {
            await _context.MstDivision.AddAsync(mstDivision);
        }

        public async Task UpdateDivision(MstDivision mstDivision)
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
