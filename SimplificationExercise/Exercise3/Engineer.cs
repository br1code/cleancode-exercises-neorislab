namespace SimplificationExercise.Exercise3
{
    public class Engineer : Employee
    {
        public override double GetPaymentAmount()
        {
            return MonthlySalary;
        }
    }
}
