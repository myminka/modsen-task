using System;
using System.Collections.Generic;
using System.Text;

namespace ModsenTask.Services.Services
{
    /// <summary>
    /// Represent a managment service for employees.
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Show a list of events.
        /// </summary>
        /// <returns></returns>
        IList<object> ShowAllEvents();

        /// <summary>
        /// Try to show a employee with specified identifier.
        /// </summary>
        /// <param name="eventId">Event identifier.</param>
        /// <param name="eventData">An event to return.</param>
        /// <returns>Returns event, otherwise returns null.</returns>
        object TryShowEvent(int eventId, out object eventData);

        /// <summary>
        /// Creates a new event.
        /// </summary>
        /// <param name="eventData">An event to create.</param>
        /// <returns>An identifier of a created employee.</returns>
        int CreateEvent(object eventData);

        /// <summary>
        /// Destroy an existed event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        bool DeleteEvent(int eventId);

        /// <summary>
        /// Updates a event.
        /// </summary>
        /// <param name="eventId">An event identifier.</param>
        /// <param name="eventData">True if employee is updated; otherwise false.</param>
        /// <returns></returns>
        bool UpdateEvent(int eventId, object eventData);
    }
}
