namespace SportApp.Domain.Services
{
    public class BMIConverter : IBMIConverter
    {
        public double Convert(double weight, int heightInMeters)
        {
            return (weight / (heightInMeters * heightInMeters));
        }
    }
}
