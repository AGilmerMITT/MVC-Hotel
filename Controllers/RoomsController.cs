using Microsoft.AspNetCore.Mvc;
using MVC_Hotel.Models;
using System.Collections.Immutable;

namespace MVC_Hotel.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            // Index page should display all rooms, and their status
            List<Room> rooms = Program.Hotel.Rooms;

            return View(rooms);
        }

        public IActionResult FindRoomWithCapacity(int capacity)
        {
            // this function is going to find all of the unoccupied
            // rooms that have at LEAST capacity capacity in them

            var result = Program.Hotel.Rooms.Where(x => x.Capacity >= capacity && !x.Occupied);

            return View(result);
        }

        // LINQ functions to review:
        // Select
        // All
        // Any
        // First, FirstOrDefault
        // Single, SingleOrDefault
        // ToList, ToHashSet, To....
        // Count
        // Max
        // OrderBy, OrderByDescending
        // Take
        // Skip

        // all LINQ queries behave kind of like mini foreach loops
        // where... this just filters our collection for each item 
        //   that passes our function test

        public IActionResult Test()
        {
            string name = "Alex";

            List<Client> allUsersWithName = Program.Hotel.Clients.Where(
                client => client.Name.Contains(name)
                )
                .ToList();

            Program.Hotel.Rooms.All(room => room.Capacity > 2); // returns false
            Program.Hotel.Rooms.Any(room => room.Capacity > 2); // returns true

            Program.Hotel.Rooms.First(room => room.Number == "i-01"); // returns a room
            Program.Hotel.Rooms.FirstOrDefault(room => room.Number == "something");

            Program.Hotel.Rooms.Single(room => room.Number == "i-01");
            Program.Hotel.Rooms.SingleOrDefault(room => room.Number == "something");

            Program.Hotel.Rooms.Count(room => room.Occupied);
            Program.Hotel.Rooms.Where(room => room.Occupied).Count();

            Program.Hotel.Rooms.Max(room => room.Capacity);
            Program.Hotel.Rooms.MaxBy(room => room.Capacity);

            Program.Hotel.Rooms.OrderBy(room => room.Capacity);
            Program.Hotel.Rooms.OrderByDescending(room => room.Capacity);

            Program.Hotel.Rooms.Skip(3);
            Program.Hotel.Rooms.Take(6);

            Program.Hotel.Rooms.Where(room => !room.Occupied)
                .OrderBy(room => room.Number)
                .Take(3)
                .ToList();

            // write a linq query that finds the largest (by capacity)
            // occupied room with a "3" in its room number

            Program.Hotel.Rooms
                .FirstOrDefault(room => room.Occupied && room.Number.Contains("3"));

            Program.Hotel.Rooms.Where(room => room.Occupied)
                .Where(room => room.Number.Contains('3'))
                .First();

            Program.Hotel.Rooms.Where(room => room.Occupied)
                .FirstOrDefault(room => room.Number.Contains('3'));

            Program.Hotel.Rooms.Where(room => room.Occupied)
                .Where(room => room.Number.Contains('3'))
                .Take(1);

            Program.Hotel.Rooms.Where(room => room.Occupied && room.Number.Contains('3'))
                .OrderByDescending(room => room.Capacity)
                .First();

            // find me a list of all the room numbers that end with 0
            Program.Hotel.Rooms.Where(room => room.Number.Last() == '0')
                .Select(room => room.Number)
                .ToList();

            return View();
        }
    }
}
