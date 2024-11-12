using Law_Connect.Cases.Domain.Entities;
using Law_Connect.Common.Repositories;
using Law_Connect.Cases.Application.DTOs;
using Law_Connect.Common.Utilities;
using System.Threading.Tasks;

namespace Law_Connect.Cases.Application.Services
{
    public class CaseService
    {
        private readonly IBaseRepository<Case> _caseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CaseService(IBaseRepository<Case> caseRepository, IUnitOfWork unitOfWork)
        {
            _caseRepository = caseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> CreateCaseAsync(CaseDTO caseDto)
        {
            var newCase = new Case(caseDto.Title, caseDto.Description);

            await _caseRepository.AddAsync(newCase);
            await _unitOfWork.CommitAsync();

            return Result.Success();
        }

        public async Task<CaseDTO?> GetCaseByIdAsync(int id)
        {
            var caseEntity = await _caseRepository.FindByIdAsync(id);
            if (caseEntity == null)
                return null;

            return new CaseDTO
            {
                Id = caseEntity.Id,
                Title = caseEntity.Title,
                Description = caseEntity.Description
            };
        }
    }
}
