using System.Text;

namespace VehicleRentalSystem
{
    public class Car : Vehicle
    {
        private int carSafetyRating;

        public Car(string brand, string model, decimal vehicleValue, int carSafetyRating)
            : base(brand, model, vehicleValue)
        {
            CarSafetyRating = carSafetyRating;
        }

        public int CarSafetyRating
        {
            get => carSafetyRating;
            private set { carSafetyRating = value; }
        }

        public override decimal CalculateDailyRentalCost(int rentalDays)
            => rentalDays > 7 ? 15 : 20;

        public override decimal CalculateDailyInsuranceCost()
        {
            decimal insuranceCost = VehicleValue * 0.0001m;

            if (CarSafetyRating > 3)
            {
                insuranceCost *= 0.9m;
            }

            return insuranceCost;
        }

        public override string GetInsuranceDetails(int rentalDays)
        {
            StringBuilder sb = new();

            sb.AppendLine($"Rental cost per day: ${CalculateDailyRentalCost(rentalDays):f2}");

            decimal insuranceCost = VehicleValue * 0.0001m;
            decimal insuranceDiscount = 0;
            if (CarSafetyRating > 3)
            {
                insuranceDiscount = insuranceCost * 0.1m;
                sb.AppendLine($"Initial insurance per day: {insuranceCost:f2}$");
                sb.AppendLine($"Insurance discount per day: {insuranceDiscount:f2}$");
            }

            sb.AppendLine($"Insurance per day: ${(insuranceCost - insuranceDiscount):f2}");

            return sb.ToString();
        }
    }
}
