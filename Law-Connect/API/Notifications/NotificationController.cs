using Microsoft.AspNetCore.Mvc;
using Law_Connect.Notifications.Application.Services;
using Law_Connect.Notifications.Application.DTOs;
using System.Threading.Tasks;

namespace Law_Connect.API.Notifications
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification(NotificationDTO notificationDto)
        {
            var result = await _notificationService.SendNotificationAsync(notificationDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result.Errors);
        }
    }
}
