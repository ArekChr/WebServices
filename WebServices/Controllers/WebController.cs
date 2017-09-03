using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class WebController : ApiController
    {
        private readonly ReservationRepository _repo = ReservationRepository.Current;

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _repo.GetAll();
        }

        public Reservation GetReservation(int id)
        {
            return _repo.Get(id);
        }

        [HttpPost]
        public Reservation CreateReservation(Reservation item)
        {
            return _repo.Add(item);
        }

        [HttpPut]
        public bool UpdateReservation(Reservation item)
        {
            return _repo.Update(item);
        }

        public void DeleteReservation(int id)
        {
            _repo.Remove(id);
        }
    }
}