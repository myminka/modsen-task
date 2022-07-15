using Microsoft.EntityFrameworkCore;
using ModsenTask.Services.EntityFrameworkCore.Events.Context;
using ModsenTask.Services.EntityFrameworkCore.Events.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ModsenTask.Services.Services
{
    public class EventService : IEventService
    {
        private readonly EventDataContext _context;

        public EventService(EventDataContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<int> CreateEvent(EventData eventData)
        {
            if (eventData is null)
            {
                throw new ArgumentNullException(nameof(eventData));
            }

            await _context.EventDatas.AddAsync(eventData);
            await _context.SaveChangesAsync();
            return eventData.Id;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteEvent(int eventId)
        {
            var eventData = await _context.EventDatas.SingleOrDefaultAsync(e => e.Id == eventId);

            var res = eventData is null;
            if (!res)
            {
                _context.EventDatas.Remove(eventData);
                await _context.SaveChangesAsync();
            }

            return res;
        }

        /// <inheritdoc/>
        public IQueryable<EventData> ShowAllEvents() =>
            this._context.EventDatas;

        /// <inheritdoc/>
        public async Task<EventData> ShowEventById(int eventId) =>
            await (this._context.EventDatas
            .Where(e => e.Id == eventId)
            .FirstOrDefaultAsync<EventData>());

        /// <inheritdoc/>
        public async Task<bool> UpdateEvent(int eventId, EventData eventData)
        {
            if (eventData is null)
            {
                throw new ArgumentNullException(nameof(eventData));
            }

            var dataToChange = await _context.EventDatas
                .SingleOrDefaultAsync(e => e.Id == eventId);

            var res = dataToChange is null;
            if (!res)
            {
                _context.Entry(dataToChange).CurrentValues.SetValues(eventData);
            }

            return res;
        }
    }
}