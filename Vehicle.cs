namespace VehicleRentalSystem
{
    public abstract class Vehicle
    {
        private string brand;
        private string model;
        private decimal vehicleValue;

        protected Vehicle(
            string brand,
            string model,
            decimal vehicleValue)
        {
            Brand = brand;
            Model = model;
            VehicleValue = vehicleValue;
        }

        public string Brand
        {
            get => brand;
            private set { brand = value; }
        }
        public string Model
        {
            get => model;
            private set { model = value; }
        }
        public decimal VehicleValue
        {
            get => vehicleValue;
            private set { vehicleValue = value; }
        }

        public abstract decimal CalculateDailyRentalCost(int rentalDays);
        public abstract decimal CalculateDailyInsuranceCost();
        public abstract string GetInsuranceDetails(int rentalDays);

    }
}
