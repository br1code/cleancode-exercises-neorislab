namespace SimplificationExercise.Exercise3
{
    public class Manager : Employee
    {
        public override double GetPaymentAmount()
        {
            return MonthlySalary + Bonus;
        }
    }
}
