using System.Text;

namespace VehicleRentalSystem
{
    public class Invoice
    {
        private DateTime reservationStartDate;
        private DateTime reservationEndDate;
        private DateTime actualReturnDate;
        private Vehicle vehicle;
        private Customer customer;

        public Invoice(
            DateTime reservationStartDate,
            DateTime reservationEndDate,
            DateTime actualReturnDate,
            Vehicle vehicle,
            Customer customer)
        {
            ReservationStartDate = reservationStartDate;
            ReservationEndDate = reservationEndDate;
            ActualReturnDate = actualReturnDate;
            Vehicle = vehicle;
            Customer = customer;
        }

        public DateTime ReservationStartDate
        {
            get => reservationStartDate;
            private set { reservationStartDate = value; }
        }

        public DateTime ReservationEndDate
        {
            get => reservationEndDate;
            private set { reservationEndDate = value; }
        }

        public int ReservedRentalDays
            => (ReservationEndDate - ReservationStartDate).Days;

        public DateTime ActualReturnDate
        {
            get => actualReturnDate;
            private set { actualReturnDate = value; }
        }

        public int ActualRentalDays
            => (ActualReturnDate - ReservationStartDate).Days;

        public Vehicle Vehicle
        {
            get => vehicle;
            private set { vehicle = value; }
        }

        public Customer Customer
        {
            get => customer;
            private set { customer = value; }
        }

        public void PrintInvoice()
        {
            StringBuilder sb = new();

            switch (nameof(vehicle))
            {
                case nameof(Car):
                    break;
                default:
                    break;
            }

            sb.AppendLine("XXXXXXXXXX");
            sb.AppendLine($"Date: {DateTime.Now.Date.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Customer Name: {customer.Name}");
            sb.AppendLine($"Rented Vehicle: {vehicle.Brand} {vehicle.Model}");
            sb.AppendLine();
            sb.AppendLine($"Reservation start date: {ReservationStartDate.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Reservation end date: {ReservationEndDate.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Reserved rental days: {ReservedRentalDays} days");
            sb.AppendLine();
            sb.AppendLine($"Actual return date: {ActualReturnDate.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Actual rental days: {ActualRentalDays} days");
            sb.AppendLine();
            sb.AppendLine(vehicle.GetInsuranceDetails(ReservedRentalDays));
            sb.AppendLine(GetRentDetials());

            Console.WriteLine(sb.ToString());
        }

        private string GetRentDetials()
        {
            StringBuilder sb = new();

            decimal earlyRentDiscount = 0;
            decimal earlyInsuranceDiscount = 0;

            if (ActualRentalDays < ReservedRentalDays)
            {
                int diffInDays = ReservedRentalDays - ActualRentalDays;
                earlyRentDiscount = (diffInDays * vehicle.CalculateDailyRentalCost(ReservedRentalDays)) / 2;
                earlyInsuranceDiscount = diffInDays * vehicle.CalculateDailyInsuranceCost();

                sb.AppendLine($"Early return discount for rent: ${earlyRentDiscount:f2}");
                sb.AppendLine($"Early return discount for insurance: ${earlyInsuranceDiscount:f2}");
                sb.AppendLine();
            }

            decimal totalRent = ReservedRentalDays * vehicle.CalculateDailyRentalCost(ReservedRentalDays) - earlyRentDiscount;
            decimal totalInsurance = ReservedRentalDays * vehicle.CalculateDailyInsuranceCost() - earlyInsuranceDiscount;
            decimal total = totalRent + totalInsurance;

            sb.AppendLine($"Total rent: ${totalRent:f2}");
            sb.AppendLine($"Total Insurance: ${totalInsurance:f2}");
            sb.AppendLine($"Total: ${total:f2}");
            sb.AppendLine("XXXXXXXXXX");

            return sb.ToString();
        }
    }
}
