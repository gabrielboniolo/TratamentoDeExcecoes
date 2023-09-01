using Principal.Entities.Exceptions;

namespace Principal.Entities {
    class Reservation {
        public int RoomNumber { get; private set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut) 
        {
            if(checkOut <= checkIn) {
                throw new DomainException("Check-out must be after check-in date");
            }
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration() {
            TimeSpan duration = CheckOut - CheckIn;
            return duration.Days;
        }

        public void UpdateChecks(DateTime checkIn, DateTime checkOut) {
            DateTime now = DateTime.Now;
            if(checkIn < now || checkOut < now) {
                throw new DomainException("Reservation dates for update must be future dates");
            }
            else if(checkOut <= checkIn) {
                throw new DomainException("Check-out must be after check-in date");
            }
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString() {
            return $"Reservation: Room {RoomNumber}, check-in: {CheckIn.ToString("dd/MM/yyyy")}, check-out {CheckOut.ToString("dd/MM/yyyy")}, {Duration()} nights.";
        }
    }
}