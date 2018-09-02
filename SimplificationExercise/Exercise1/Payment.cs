using System;

namespace SimplificationExercise.Exercise1
{
    public class Payment
    {
        public double GetPaymentAmount(Person person)
        {
            switch (person.Status)
            {
                case Person.PersonStatus.Dead:
                    return GetDeadAmount();

                case Person.PersonStatus.Retired:
                    return GetRetiredAmount();

                case Person.PersonStatus.Separated:
                    return GetSeparatedAmount();

                default:
                    return GetNormalPayAmount();
            }
        }

        private double GetDeadAmount()
        {
            throw new NotImplementedException();
        }

        private double GetSeparatedAmount()
        {
            throw new NotImplementedException();
        }

        private double GetRetiredAmount()
        {
            throw new NotImplementedException();
        }

        private double GetNormalPayAmount()
        {
            throw new NotImplementedException();
        }
    }
}
