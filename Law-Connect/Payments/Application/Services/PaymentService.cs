using Law_Connect.Payments.Domain.Entities;
using Law_Connect.Common.Repositories;
using Law_Connect.Payments.Application.DTOs;
using Law_Connect.Common.Utilities;
using System.Threading.Tasks;

namespace Law_Connect.Payments.Application.Services
{
    public class PaymentService
    {
        private readonly IBaseRepository<Payment> _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IBaseRepository<Payment> paymentRepository, IUnitOfWork unitOfWork)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> ProcessPaymentAsync(PaymentDTO paymentDto)
        {
            var payment = new Payment
            {
                Amount = paymentDto.Amount,
                Method = paymentDto.Method
            };

            await _paymentRepository.AddAsync(payment);
            await _unitOfWork.CommitAsync();

            return Result.Success();
        }
    }
}
