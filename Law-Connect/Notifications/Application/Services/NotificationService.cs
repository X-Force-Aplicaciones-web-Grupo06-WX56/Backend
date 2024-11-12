using Law_Connect.Notifications.Domain.Entities;
using Law_Connect.Common.Repositories;
using Law_Connect.Notifications.Application.DTOs;
using Law_Connect.Common.Utilities;
using System.Threading.Tasks;

namespace Law_Connect.Notifications.Application.Services
{
    public class NotificationService
    {
        private readonly IBaseRepository<Notification> _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(IBaseRepository<Notification> notificationRepository, IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> SendNotificationAsync(NotificationDTO notificationDto)
        {
            var notification = new Notification
            {
                Message = notificationDto.Message
            };

            await _notificationRepository.AddAsync(notification);
            await _unitOfWork.CommitAsync();

            return Result.Success();
        }
    }
}

