using AutoMapper;
using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        // functionality not implemented yet
        // create a quiz together with a question
        public NotificationController(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("[action]/{userid}")]
        public async Task<ActionResult<NotificationViewModel>> CreateNotification(int userid,[FromBody] NotificationViewModel model)
        {
            try
            {
                var notification = _mapper.Map<Notification>(model);
                //course.CourseId = 7;
                _notificationRepository.Add(notification);

                if (await _notificationRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Created Notification " + ' ' + notification.NotificationMessageDescription;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;

                    return Ok("Successfully created notification");
                }
            }
            catch (Exception)
            {

                BadRequest();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("[action]/{id}")]

        public async Task<IActionResult> getNotificationsByCourseId(int id)
        {
            try
            {
                var notifications = await _notificationRepository.GetNotificationByCourseIdAsync(id);

                if (notifications == null) return NotFound();

                return Ok(notifications);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not find notificationa for the course");
            }



            //return BadRequest();
        }
        [HttpDelete("{id}")]
        [Route("[action]/{id}/{userid}")]

        public async Task<IActionResult> DeleteNotification(int id, int userid)
        {
            try
            {
                var notification = await _notificationRepository.GetNotificationByIdAsync(id);

                if (notification == null) return NotFound();

                _notificationRepository.Delete(notification);

                if (await _notificationRepository.SaveChangesAsync())
                {
                    AuditLog auditLog = new AuditLog();
                    auditLog.AuditLogDescription = "Created Notification " + ' ' + notification.NotificationMessageDescription;
                    auditLog.AuditLogDatestamp = DateTime.Now;
                    auditLog.UserId = userid;
                    return Ok();
                }
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"We could not delete the course");
            }

            return BadRequest();
        }
    }
}
