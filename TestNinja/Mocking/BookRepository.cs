using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class BookRepository : IBookRepository
    {
        public IQueryable<Booking> GetActiveBooking(int? ExcludingId = null)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(b =>  b.Status != "Cancelled");
            if(ExcludingId.HasValue)
            {
                bookings = bookings.Where(i => i.Id == ExcludingId.Value);
            }
            return bookings;
        }
        
    }
}
