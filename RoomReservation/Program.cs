using Principal.Entities;
using Principal.Entities.Exceptions;

namespace Principal {
    class Program {
        static void Main(string[] args) {
        try{
            Console.Write("Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine());
            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine());
            Console.Write("Check-out date (dd/MM/yyyy): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());

            Reservation reservation = new Reservation(roomNumber, checkIn, checkOut);
            Console.WriteLine(reservation);

            Console.WriteLine();    

            Console.WriteLine("Enter the data to update the reservation:");
            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime updatedCheckIn = DateTime.Parse(Console.ReadLine());
            Console.Write("Check-out date (dd/MM/yyyy): ");
            DateTime updatedCheckOut = DateTime.Parse(Console.ReadLine());

            reservation.UpdateChecks(updatedCheckIn, updatedCheckOut);
            Console.WriteLine(reservation);
            }
            catch(DomainException e) {
                Console.WriteLine($"Error in reservation: {e.Message}");
            }
            catch(FormatException e) {
                Console.WriteLine($"Format error: {e.Message}");
            }
            catch(Exception e) {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
        }
    }
} 
