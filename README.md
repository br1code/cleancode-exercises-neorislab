# cleancode-exercises-neorislab

> This was my way of improving this code. I'm sure it's not the best way

## [Exercise 1](https://github.com/br1code/cleancode-exercises-neorislab/tree/master/SimplificationExercise/Exercise1)
### How would you make the following method more readable?

```C#
double GetPaymentAmount()
{
    double result;
    if (_isDead) result = GetDeadAmount();
    else
    {
        if (_isSeparated) result = GetSeparatedAmount();
        else
        {
            if (_isRetired) result = GetRetiredAmount();
            else result = GetNormalPayAmount();
        };
    }
    return result;
}
```

First, we create a [Person](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise1/Person.cs) class with a **Status** property that represents the status of the person using an enum

```C#
public class Person
{
    public PersonStatus Status { get; set; }

    public enum PersonStatus { Separated, Retired, Dead }
}
```

Then, create a [Payment](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise1/Payment.cs) class with a method called **GetPaymentAmount** that receives a [Person](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise1/Person.cs) and determine the type of payment using a switch statement based in the **Status** of that [Person](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise1/Person.cs)

```C#
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
}
```

Don't forget to implement those methods 
> In this example the implementation really does not matter

```C#
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
```

---

## [Exercise 2](https://github.com/br1code/cleancode-exercises-neorislab/tree/master/SimplificationExercise/Exercise2)
### Is the following code easily maintainable? How would you improve it?

```C#
class Product
{
    public decimal Price()
    {
        if (UOM.Equals("grams"))
            return Quantity * 6m / 1000;
        if (UOM.Equals("bottle"))
            return Quantity * 3m;
        if (UOM.Equals("bag"))
        {
            var total += Quantity * .2m;
            var setsOfFour = Quantity / 4;
            total -= setsOfFour * .15m; //discount on groups of 4 items
            return total;
        }
        return 0m;
    }
}
```

> In this example, i decided to use an enum for the name of the products. But in real word examples, you'll have thousands of different products and this is not a good idea

First, in the [Product](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise2/Product.cs) class, create an enum that contains the names of the products

```C#
public class Product
{
    public enum ProductName { Grams, Bottle, Bag }
}
```

Then, create a method called **Price** that receives a **ProductName** and the quantity of that product and returns the calculated price using a switch statement

```C#
public decimal Price(ProductName name, int quantity)
{
    switch (name)
    {
        case ProductName.Grams:
            return quantity * 6m / 100;

        case ProductName.Bottle:
            return quantity * 3m;

        case ProductName.Bag:
            return quantity * .2m - (quantity / 4 * .15m);

        default:
            return 0m;
    }
}
```

Mmm, I think this line is still causing confusion

```C#
    case ProductName.Bag:
        return quantity * .2m - (quantity / 4 * .15m);
```

For some reason, this **Product** has a discount. Why not write a method that calculates the discount of a product based in the quantity needed?

```C#
private decimal GetDiscount(int quantity)
{
    return quantity / 4 * .15m;
}
```

And we use it to apply a discount to a product

```C#
    case ProductName.Bag:
        return quantity * .2m - GetDiscount(quantity);

```


Now, our [Product](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise2/Product.cs) class looks like this

```C#
public class Product
{
    public enum ProductName { Grams, Bottle, Bag }

    public decimal Price(ProductName name, int quantity)
    {
        switch (name)
        {
            case ProductName.Grams:
                return quantity * 6m / 100;

            case ProductName.Bottle:
                return quantity * 3m;

            case ProductName.Bag:
                return quantity * .2m - GetDiscount(quantity);

            default:
                return 0m;
        }
    }

    private decimal GetDiscount(int quantity)
    {
        return quantity / 4 * .15m;
    }
}
```
---

## [Exercise 3](https://github.com/br1code/cleancode-exercises-neorislab/tree/master/SimplificationExercise/Exercise3)
### How would you improve the maintainability of the following code?
```C#
class Employee
{
    private int _type;
    static final int ENGINEER = 0;
    static final int SALESMAN = 1;
    static final int MANAGER = 2;
    public double MonthlySalary { get; set; }
    public double Commission { get; set; }
    public double Bonus { get; set; }
    public Employee(int type)
    {
        _type = type;
    }
    public int GetPaymentAmount()
    {
        switch (_type)
        {
            case 0:
                return MonthlySalary;
            case 1:
                return MonthlySalary + Commission;
            case 2:
                return MonthlySalary + Bonus;
            default:
                throw new RuntimeException("Incorrect Employee");
        }
    }
}
```

> In this example, I could have used an enumeration for each type of employee. But I decided to use some advantages of object-oriented programming

As we see, an Employee has a type and a different payment amount

Type | Payment 
--- | --- 
Enginner | MonthlySalary
Salesman | MonthlySalary + Commission
Manager | MonthlySalary + Bonus

Ok, let's write. First, create a [Employee](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise3/Employee.cs) class that has some properties

```C#
public class Employee
{
    public double MonthlySalary { get; set; }
    public double Commission { get; set; }
    public double Bonus { get; set; }
}
```

Then, create a method called **GetPaymentAmount**

```C#
public double GetPaymentAmount()
{
    // ???
}
```

But, how do we know what the payment is for each type of **Employee**? We don't want to use a switch statement again

Let's make our class abstract and set the **GetPaymentAmount** method as *virtual* to let each type of employee define his own **GetPaymentAmount**

```C#
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
```
Now we can create a type of employee as a class and that can inherit from the [Employee](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise3/Employee.cs) class

Each class must define its own **GetPaymentAmount** (using *override*)

[Engineer](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise3/Engineer.cs)
```C#
public class Engineer : Employee
{
    public override double GetPaymentAmount()
    {
        return MonthlySalary;
    }
}
```
[Salesman](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise3/Salesman.cs)
```C#
public class Salesman : Employee
{
    public override double GetPaymentAmount()
    {
        return MonthlySalary + Commission;
    }
}
```
[Manager](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise3/Manager.cs)
```C#
public class Manager : Employee
{
**Hello**
    public override double GetPaymentAmount()
    {
        return MonthlySalary + Bonus;
    }
}
```

Now, we can add a new type of [Employee](https://github.com/br1code/cleancode-exercises-neorislab/blob/master/SimplificationExercise/Exercise3/Employee.cs) without modifying anything

