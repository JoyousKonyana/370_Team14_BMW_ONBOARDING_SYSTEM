using BMW_ONBOARDING_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Interfaces
{
    public interface INotificationRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Notification[]> GetAllNotificationAsync();

        Task<Notification> GetNotificationByIdAsync(int notificationID);

        Task<Notification[]> GetNotificationByCourseIdAsync(int courseID);

    }
}
