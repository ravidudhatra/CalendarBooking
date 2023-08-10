using CalendarBooking.Data.Model;

namespace CalendarBooking.Data.Repository
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GettAllBooking();
        Task<Booking> SaveBooking(Booking booking);
        Task<bool> RemoveBooking(int bookingId);

    }
}
