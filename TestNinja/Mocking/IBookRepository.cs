using System.Linq;

namespace TestNinja.Mocking
{
    public interface IBookRepository
    {
        IQueryable<Booking> GetActiveBooking(int? id);
        
    }
}