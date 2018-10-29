using System.Linq;

namespace TestNinja.Mocking
{
    public static class BookingHelper
    {
        public static string OverlappingBookingsExist(Booking booking, IBookRepository bookRepository)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;
            IQueryable<Booking> bookings = bookRepository.GetActiveBooking(booking.Id);

            Booking overlappingBooking = bookings.FirstOrDefault(
                                    b =>
                                    booking.ArrivalDate < b.DepartureDate &&
                                    b.ArrivalDate < booking.DepartureDate);

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }

        


    }

   
}