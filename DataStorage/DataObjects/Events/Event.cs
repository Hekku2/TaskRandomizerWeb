using System;

namespace DataStorage.DataObjects.Events
{
    public class Event
    {
        public Guid SessionId { get; private set; }
        public EventType EventType { get; private set; }

        public Event(Guid sessionId, EventType type)
        {
            SessionId = sessionId;
            EventType = type;
        }
    }
}
