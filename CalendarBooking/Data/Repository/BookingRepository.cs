﻿using CalendarBooking.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CalendarBooking.Data.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private CalendarBookingContext _db;
        public BookingRepository(CalendarBookingContext db)
        {
            _db = db;
        }
        public async Task<List<Booking>> GettAllBooking()
        {
            return await _db.Bookings.ToListAsync();
        }

        public async Task<Booking> SaveBooking(Booking booking)
        {
            if (booking.BookingId > 0)
            {
                //Update the booking
                var v = _db.Bookings.Where(a => a.BookingId == booking.BookingId).FirstOrDefault();
                if (v != null)
                {
                    v.Subject = booking.Subject;
                    v.Start = booking.Start;
                    v.End = booking.End;
                    v.Description = booking.Description;
                    v.IsFullDay = booking.IsFullDay;
                    v.ThemeColor = booking.ThemeColor;
                }
            }
            else
                _db.Bookings.Add(booking);

            await _db.SaveChangesAsync();

            return booking;
        }

        public async Task<bool> RemoveBooking(int bookingId)
        {
            var booking = _db.Bookings.Where(a => a.BookingId == bookingId).FirstOrDefault();
            if (booking != null)
            {
                _db.Bookings.Remove(booking);
                await _db.SaveChangesAsync();
            }

            return true;
        }
    }
}
