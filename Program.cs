namespace VehicleRentalSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Customer[] customers =
            [
                new Customer("John Doe", 20 ,2),
                new Customer("Mary Johnson", 20 ,2),
                new Customer("John Markson", 26 ,8)
            ];

            Vehicle[] vehicles =
            [
                new Car("Mitsubishi", "Mirage", 15000, 3),
                new Motorcycle("Triumph", "Tiger Sport 660", 10000, customers[1].Age),
                new CargoVan("Citroen", "Jumper", 20000, customers[2].DrivingExperience),
            ];

            Invoice[] invoices =
            [
                new Invoice(new DateTime(2024, 6, 3), new DateTime(2024, 6, 13), new DateTime(2024, 6, 13), vehicles[0], customers[0]),
                new Invoice(new DateTime(2024, 6, 3), new DateTime(2024, 6, 13), new DateTime(2024, 6, 13), vehicles[1], customers[1]),
                new Invoice(new DateTime(2024, 6, 3), new DateTime(2024, 6, 18), new DateTime(2024, 6, 13), vehicles[2], customers[2]),
            ];

            for (int i = 0; i < invoices.Length; i++)
            {
                invoices[i].PrintInvoice();
            }
        }
    }

}
