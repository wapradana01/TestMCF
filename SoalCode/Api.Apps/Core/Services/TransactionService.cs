using Core.RequestInputs;
using DataAccess;
using DataAccess.Models;
using DataAccess.SharedObjects;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class TransactionService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly CurrentUserAccessor _currentUserAccessor;
        public TransactionService(ApplicationDbContext dbContext, CurrentUserAccessor currentUserAccessor)
        {
            _dbContext = dbContext;
            _currentUserAccessor = currentUserAccessor;
        }

        public async Task<List<Location>> GetLocation()
        {
            return await _dbContext.Locations.ToListAsync();
        }

        public async Task<List<BpkbTransaction>> GetAllBpkb()
        {
            return await _dbContext.BpkbTransactions.Where(x => x.CreatedBy.Equals(_currentUserAccessor.Id.ToString())).ToListAsync();
        }

        public async Task<BpkbTransaction> CreateBpkb(BpkbInput input)
        {
            var dataBpkbNew = new BpkbTransaction
            {
                AgreementNumber = input.AgreementNumber,
                BpkbNo = input.BpkbNo,
                BranchId = input.BranchId,
                BpkbDate = input.BpkbDate,
                FakturNo = input.FakturNo,
                FakturDate = input.FakturDate,
                LocationId = input.LocationId,
                PoliceNo = input.PoliceNo,
                BpkbDateIn = input.BpkbDateIn
            };

            await _dbContext.BpkbTransactions.AddAsync(dataBpkbNew);
            await _dbContext.SaveChangesAsync();

            return dataBpkbNew;
        }
    }
}
