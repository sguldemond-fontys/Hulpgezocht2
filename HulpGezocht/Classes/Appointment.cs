using System;

namespace HulpGezocht
{
    public class Appointment
    {
        public int Id { get; private set; }
        public string Header { get; private set; }
        public DateTime DateHelpNeeded1 { get; private set; }
        public bool Active { get; private set; }
        public string Location { get; private set; }
        public string Sender { get; private set; }
        public string Receiver { get; private set; }
        public int TravelTime { get; private set; }
        public string Transport { get; private set; }

        public Appointment(int id, string sender, string transportname, string header, DateTime dateHelpNeeded1, string location, int travelTime, string receiver)
        {
            Id = id;
            Active = true;
            Receiver = receiver;
            Sender = sender;
            Location = location;
            DateHelpNeeded1 = dateHelpNeeded1;
            Header = header;
            TravelTime = travelTime;
            Transport = transportname;
        }

        public bool Edit(string header, bool active)
        {
            //To-do: check functie met bool toevoegen
            Header = header;
            Active = active;
            return true;
        }

        public override string ToString()
        {
            return Header + " om " + DateHelpNeeded1.ToString("HH:mm");
        }
    }
}
