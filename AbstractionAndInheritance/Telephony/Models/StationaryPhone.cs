
using Telephony.Models.Interfaces;

namespace Telephony.Models;

public class StationaryPhone : ICallable
{

    // The StationaryPhone can only call other phones. - Затова имплементира само ICallable интерфейс
    public string Call(string phoneNumber) //Validation
    {

        if (!ValidatePhoneNumber(phoneNumber))
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Dialing... {phoneNumber}";
    }
    private bool ValidatePhoneNumber(string phoneNumber)
       => phoneNumber.All(c => Char.IsDigit(c));
}

