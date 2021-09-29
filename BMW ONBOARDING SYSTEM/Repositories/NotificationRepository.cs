using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public NotificationRepository(INF370DBContext inf370ContextDB)
        {
            _inf370ContextDB = inf370ContextDB;
        }
        public void Add<T>(T entity) where T : class
        {
            _inf370ContextDB.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _inf370ContextDB.Remove(entity);
        }


        public async Task<Notification[]> GetAllNotificationAsync()
        {
            IQueryable<Notification> notifications = _inf370ContextDB.Notification;

            return await notifications.ToArrayAsync();
        }
        public Task<Notification> GetNotificationByIdAsync(int notificationID)
        {
            IQueryable<Notification> existingNotification = _inf370ContextDB.Notification.
                Where(x => x.NotificationId == notificationID);

            return existingNotification.FirstOrDefaultAsync();

        }
        // this returns a course together with its notification

        public Task<Notification[]> GetNotificationByCourseIdAsync(int courseID)
        {
            IQueryable<Notification> existingNotification = _inf370ContextDB.Notification.Where(x => x.CourseId == courseID);

            return existingNotification.ToArrayAsync();

        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }
    }
}
