using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.DatabaseRepository.Interface;

namespace TicketSystem.DatabaseRepository
{
    class EventRepository : IEventRepository
    {


        public TicketEvent EventAdd(string name, string description)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into TicketEvents(EventName, EventHtmlDescription) values(@Name, @Description)", new { Name = name, Description = description });
                var addedEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID=@Id", new { Id = addedEventQuery }).First();
            }
        }

        public TicketEvent EventUpdate(int id, string name, string description) {
            var query = new SqlBuilder()
                .UPDATE("TicketEvents")
                .SET("EventName = @name, EventHtmlDescription = @description")
                .WHERE("TicketEventID = @id");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString)) {
                connection.Open();
                connection.Execute(query.ToString(), new { name, description });
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID = @id", new { id }).First();
            }
        }

    }
}
