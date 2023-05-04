using System;
using System.Collections.Generic;

namespace ObjectsClassesStructureAndTips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    // Класовете се създават извън интърнал клас като се наименоват по описателен начин(какво съдържат) и са с главна буква.
    class ClassName
    {
        //Класа може да съдържа: 
        //- полета(Field) -които могат да бъдат достъпени само в рамките на класа
        //- Properties{get(accessor) set(mutator)} - Свойства които могат да се вземат (get)  отвън и да се променят (set)
        //- Methods - Метод, който се извиква в мейн метода.
        //- Constructors(ctor + tabtab) - Метод, който се извиква в мейн метода.Наименова се по същия начин като класа. Прави копие на пропъртитата и изисква да пу бъдат подадени отвън в скоби след името(като методите)

        //Properties public типа на променливата име на променливата с главна буква {get set}:
        public int Name { get; set; }
        public string Name1 { get; set; }
        public double Name2 { get; set; }
        // Ако едното пропърти е лист е хубаво той да се инициализира в конструктора
        public List<int> Name3 { get; set; }

        //Constructor
        public ClassName(int name, string name1,double name2)
        {
            this.Name = name;
            this.Name1 = name1;
            this.Name2 = name2;
            List<int> name3 = new List<int>();
        }

        // Methods
        static bool IsExist(List<ClassName> name, string name1, int name2)
        {
            foreach (ClassName c in name)//за всеки обект с от типа ClassName в колекцията name
            {
                if (c.Name1 == name1 && c.Name2 == name2)// ако пропъртито на обект с съвпада с подаденото
                {
                    return true;
                }
            }
            return false;
        }
    }

}
