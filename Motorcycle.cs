using System.Text;

namespace VehicleRentalSystem
{
    public class Motorcycle : Vehicle
    {
        private int riderAge;

        public Motorcycle(string brand, string model, decimal vehicleValue, int riderAge)
            : base(brand, model, vehicleValue)
        {
            RiderAge = riderAge;
        }

        public int RiderAge
        {
            get => riderAge;
            private set { riderAge = value; }
        }

        public override decimal CalculateDailyRentalCost(int rentalDays)
            => rentalDays > 7 ? 10 : 15;

        public override decimal CalculateDailyInsuranceCost()
        {
            decimal insuranceCost = VehicleValue * 0.0002m;

            if (RiderAge < 25)
            {
                insuranceCost *= 1.2m;
            }

            return insuranceCost;
        }

        public override string GetInsuranceDetails(int rentalDays)
        {
            StringBuilder sb = new();

            sb.AppendLine($"Rental cost per day: ${CalculateDailyRentalCost(rentalDays):f2}");

            decimal insuranceCost = VehicleValue * 0.0002m;
            decimal insuranceAddition = 0;
            if (RiderAge < 25)
            {
                insuranceAddition = insuranceCost * 0.2m;
                sb.AppendLine($"Initial insurance per day: {insuranceCost:f2}$");
                sb.AppendLine($"Insurance addition per day: {insuranceAddition:f2}$");
            }

            sb.AppendLine($"Insurance per day: ${(insuranceCost + insuranceAddition):f2}");

            return sb.ToString();
        }
    }
}
