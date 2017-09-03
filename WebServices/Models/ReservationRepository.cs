using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class ReservationRepository
    {
        public static ReservationRepository Current { get; } = new ReservationRepository();

        private readonly List<Reservation> _data = new List<Reservation>
        {
            new Reservation{ReservationId = 2, ClientName = "Kowalski", Location = "Sala posiedzeń"},
            new Reservation{ReservationId = 2, ClientName = "Nowak", Location = "Aula"},
            new Reservation{ReservationId = 3, ClientName = "Bobrowska", Location = "Sala konferencyjna"},
        };

        public IEnumerable<Reservation> GetAll()
        {
            return _data;
        }

        public Reservation Get(int id)
        {
            return _data.FirstOrDefault(r => r.ReservationId == id);
        }

        public Reservation Add(Reservation item)
        {
            item.ReservationId = _data.Count + 1;
            _data.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            Reservation item = Get(id);
            if (item != null)
            {
                _data.Remove(item);
            }
        }

        public bool Update(Reservation item)
        {
            Reservation storedItem = Get(item.ReservationId);
            if (storedItem != null)
            {
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}