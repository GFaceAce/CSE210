using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>();
        Address address1 = new Address("696 Seashell Cir", "Pearl City", "Atlantis", "Underwater Kingdom");
        events.Add(new Lecture(
            "Abovewater Engineering",
            "Learn how landwalkers get around gravity in the construction of their cities.",
            "May 18, 0902",
            "7:30 AM",
            address1,
            "Prof. Ariel",
            50
        ));
        Address address2 = new Address("221B Baker St", "London", "NW1 6XE", "UK");
        events.Add(new Reception(
            "Publication Celebration",
            "Celebrate the 200th publication of Dr. Watson's memoirs of Detective Holmes.",
            "March 8, 1991",
            "9:00 PM",
            address2,
            "drwatson@publisher.co"
        ));
        Address address3 = new Address("26A Candlemaker Row", "Edinburgh", "EH1 2QE", "UK");
        events.Add(new OutdoorGathering(
            "Monster Mash",
            "Dance party for monsters of all kinds and ages.",
            "October 13, 2055",
            "12:00 AM",
            address3,
            "Full Moon, 40°F"
        ));
        foreach (Event currentEvent in events)
        {
            Console.WriteLine("Standard Details");
            Console.WriteLine(currentEvent.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine("Full Details");
            Console.WriteLine(currentEvent.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine("Short Description");
            Console.WriteLine(currentEvent.GetShortDescription());
            Console.WriteLine();
        }
    }
}