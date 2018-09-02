namespace SimplificationExercise.Exercise3
{
    public class Salesman : Employee
    {
        public override double GetPaymentAmount()
        {
            return MonthlySalary + Commission;
        }
    }
}
