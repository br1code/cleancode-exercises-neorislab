using System;

namespace SimplificationExercise.Exercise3
{
    public abstract class Employee
    {
        public double MonthlySalary { get; set; }
        public double Commission { get; set; }
        public double Bonus { get; set; }

        public virtual double GetPaymentAmount()
        {
            throw new NotImplementedException();
        }
    }
}
