using System.Text;

namespace VehicleRentalSystem
{
    public class CargoVan : Vehicle
    {
        private int driverExperience;

        public CargoVan(string brand, string model, decimal vehicleValue, int driverExperience)
            : base(brand, model, vehicleValue)
        {
            DriverExperience = driverExperience;
        }

        public int DriverExperience
        {
            get => driverExperience;
            private set { driverExperience = value; }
        }

        public override decimal CalculateDailyRentalCost(int rentalDays)
            => rentalDays > 7 ? 40 : 50;

        public override decimal CalculateDailyInsuranceCost()
        {
            decimal insuranceCost = VehicleValue * 0.0003m;

            if (DriverExperience > 5)
            {
                insuranceCost *= 0.85m;
            }

            return insuranceCost;
        }

        public override string GetInsuranceDetails(int rentalDays)
        {
            StringBuilder sb = new();

            sb.AppendLine($"Rental cost per day: ${CalculateDailyRentalCost(rentalDays):f2}");

            decimal insuranceCost = VehicleValue * 0.0003m;
            decimal insuranceDiscount = 0;
            if (DriverExperience > 5)
            {
                insuranceDiscount = insuranceCost * 0.15m;
                sb.AppendLine($"Initial insurance per day: {insuranceCost:f2}$");
                sb.AppendLine($"Insurance discount per day: {insuranceDiscount:f2}$");
            }

            sb.AppendLine($"Insurance per day: ${(insuranceCost - insuranceDiscount):f2}");

            return sb.ToString();
        }
    }
}
