using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using HotelBookingApplication.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;
        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
            IRoom room = null;
            if (model is DoubleBed)
            {
                room = new DoubleBed();
            }
            if (model is Studio)
            {
                room = new Studio();
            }
            if (model is Apartment)
            {
                room = new Apartment();
            }
            rooms.Add(room);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return rooms.ToList().AsReadOnly();
        }

        public IRoom Select(string criteria)
        {
            return rooms.FirstOrDefault(r => r.GetType().Name == criteria);
        }
    }
}
