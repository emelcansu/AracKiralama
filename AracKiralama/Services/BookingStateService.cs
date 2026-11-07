
using System.Text.Json;
using AracKiralama.Models;
using Microsoft.JSInterop;

namespace AracKiralama.Services
{
    public class BookingStateService
    {
        private readonly IJSRuntime _jsRuntime;

        private const string StorageKey = "aracKiralamaBookings";

        private List<CarBooking> _bookings = new();

        private bool _isLoaded;

        public BookingStateService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public string? SelectedCarId { get; private set; }

        public DateTime? PickupDate { get; private set; }

        public DateTime? ReturnDate { get; private set; }

        public List<string> SelectedExtraIds { get; private set; } = new();

        public void SetRentalSelection(
            string carId,
            DateTime? pickupDate,
            DateTime? returnDate,
            List<string> extraIds)
        {
            SelectedCarId = carId;
            PickupDate = pickupDate;
            ReturnDate = returnDate;
            SelectedExtraIds = extraIds.ToList();
        }

        public async Task<List<CarBooking>> GetBookingsAsync()
        {
            await LoadBookingsAsync();

            return _bookings.ToList();
        }

        public async Task AddBookingAsync(CarBooking booking)
        {
            await LoadBookingsAsync();

            _bookings.Add(booking);

            await SaveBookingsAsync();
        }

        public async Task CancelBookingAsync(string bookingId)
        {
            await LoadBookingsAsync();

            var booking = _bookings.FirstOrDefault(
                b => b.Id == bookingId
            );

            if (booking != null)
            {
                booking.IsCancelled = true;

                await SaveBookingsAsync();
            }
        }

        private async Task LoadBookingsAsync()
        {
            if (_isLoaded)
            {
                return;
            }

            var json = await _jsRuntime.InvokeAsync<string?>(
                "localStorage.getItem",
                StorageKey
            );

            if (!string.IsNullOrWhiteSpace(json))
            {
                _bookings =
                    JsonSerializer.Deserialize<List<CarBooking>>(json)
                    ?? new List<CarBooking>();
            }

            _isLoaded = true;
        }

        private async Task SaveBookingsAsync()
        {
            var json = JsonSerializer.Serialize(_bookings);

            await _jsRuntime.InvokeVoidAsync(
                "localStorage.setItem",
                StorageKey,
                json
            );
        }
    }
}
