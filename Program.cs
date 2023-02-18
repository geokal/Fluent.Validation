using System;

using FluentValidation;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello Fluent Validation");
        var person = new Person { Name = "John", Email = "john@example.com", Age = 125 };
        var validator = new PersonValidator();
        var result = validator.Validate(person);
        if (result.IsValid)
        {
            // The person is valid
            Console.WriteLine("Valid!");
        }
        else
        {
            // The person is invalid, you can access errors via result.Errors
            Console.WriteLine(result.Errors);
        }
    }
}

public class Person
{
    public string? Name { get; set; }

    public string? Email { get; set; }

    public int Age { get; set; }
}

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p => p.Name).NotEmpty().Length(2, 50);
        RuleFor(p => p.Email).NotEmpty().EmailAddress();
        RuleFor(p => p.Age).InclusiveBetween(18, 120);
    }
}
