using System;
using System.Collections.Generic;
using System.Text;

namespace ModsenTask.Services.Services
{
    public interface IEventService
    {
        IList<object> ShowAllEvents();

        bool TryShowEvent(int eventId, out object eventData);

        int CreateEvent(object eventData);

        bool DeleteEvent(int eventId);

        bool UpdateEvent(int eventId, object eventData);
    }
}
