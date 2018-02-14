using System.Collections.Generic;
using TicketSystem.DatabaseRepository.Model;

namespace TicketSystem.DatabaseRepository.Interface
{
    public interface IEventDateRepository
    {
        Event AddEvent(string name, string htmlDescription);
        List<Event> GetEvents(int offset = 0, int maxLimit = 20);
        Event GetEventById(int id);
        Event UpdateEvent(int id, string name, string htmlDescription);
        void DeleteEvent(int id);
        List<Event> FindEvents(string searchStr);

    }
}
