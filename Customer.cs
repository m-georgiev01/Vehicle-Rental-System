namespace VehicleRentalSystem
{
    public class Customer
    {
        private string name;
        private int age;
        private int drivingExperience;

        public Customer(
            string name,
            int age,
            int drivingExperience)
        {
            Name = name;
            Age = age;
            DrivingExperience = drivingExperience;
        }

        public string Name
        {
            get => name;
            private set { name = value; }
        }
        public int Age
        {
            get => age;
            private set { age = value; }
        }
        public int DrivingExperience
        {
            get => drivingExperience;
            private set { drivingExperience = value; }
        }

    }
}
