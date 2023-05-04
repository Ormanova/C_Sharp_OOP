using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Core.Interfaces;
using Telephony.IO.Interfaces;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony.Core;
// Тук изписваме бизнес логиката, която по принцип пишем в мейн метода.
public class Engine : IEngine
{

    // ако искаме да направим универсални четци и писци създаваме папка IO където съхраняваме класове и интерфейси за Input Output.Например:

    //private fields
    private IReader reader;
    private IWriter writer;

    // в конструктура на класа за стартиране задаваме IReader reader IWriter writer
    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader; // това поле приема това което задаваме.
        this.writer = writer;
    }
    public void Run() // Логиката от мейн метода
    {
        string[] phoneNumbers = reader.ReadLine() //Използва интерфейса 
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string[] urls = reader.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        ICallable callable; // задаваме празна променлива от типа интерфейс

        //обхождаме всички номера от phoneNumbers

        foreach (var phoneNumber in phoneNumbers)
        {
            if (phoneNumber.Length == 10) //If the number is 10 digits long, you are making a call from your smartphone and print: "Calling... {number}"
            {
                callable = new Smartphone();
            }
            else //If the number is 7 digits long, you are making a call from your stationary phone and print: " Dialing... {number}"
            {
                callable = new StationaryPhone();
            }
            try
            {
                writer.WriteLine(callable.Call(phoneNumber)); //в зависимост от какъв телефон се извършва обаждането се влиза в съответния клас и метода идващ от  интерфейса и чрез интерфейса за output се изписва на конзолата в случая.
            }
            catch (ArgumentException ex)// ако не хвърля грешка
            {
                writer.WriteLine(ex.Message);
            }
        }

        IBrowsable browsable = new Smartphone(); // защото само смартфоните могат да браузвът

        foreach (var url in urls)
        {
            try
            {
                writer.WriteLine(browsable.Browse(url));
            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
        }

    }
}

