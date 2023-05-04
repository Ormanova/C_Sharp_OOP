
using Telephony.Models.Interfaces;

namespace Telephony.Models;

public class Smartphone : ICallable, IBrowsable
{
    //The Smartphone can call other phones and browse the WWW. Затова този клас имплеметира тези 2 интерфейса.


    //In the class validation can be done, while implementing the Interface
    public string Call(string phoneNumber)
    {
        // use method for validation - If there is a character different from a digit in a number, print: "Invalid number!" and continue with the next number.
        if (!ValidatePhoneNumber(phoneNumber)) // ако номера е невалиден хвърля грешка
        {
            throw new ArgumentException("Invalid number!");
        }
        // иначе 
        return $"Calling... {phoneNumber}"; 
    }

    // Implementation the second Interface - IBrowsable and validation
    public string Browse(string url)
    {
        if (!ValidateUrl(url))
        {
            throw new ArgumentException("Invalid URL!");
        }
        return $"Browsing: {url}!";
    }

    private bool ValidateUrl(string url) //If there is a number in the input of the URLs, print: "Invalid URL!" and continue with the next URLs.
    {
        return url.All(c => !Char.IsDigit(c));
    }

    private bool ValidatePhoneNumber(string phoneNumber) // method for validation - If there is a character different from a digit in a number, print: "Invalid number!" and continue with the next number.
    {
        return phoneNumber.All(c => Char.IsDigit(c));
    }
}

