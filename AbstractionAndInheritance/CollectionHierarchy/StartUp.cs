

using CollectionHierarchy.Models;
using CollectionHierarchy.Models.Interfaces;

Dictionary<string, List<int>> addedIndexes = new()
{
    { "AddCollection", new List<int>() },
    { "AddRemoveCollection", new List<int>() },
    { "MyList", new List<int>() }
};

Dictionary<string, List<string>> removedItems = new()
{
    { "AddCollection", new List<string>() },
    { "AddRemoveCollection", new List<string>() },
    { "MyList", new List<string>() }
};

IAddable addCollection = new AddCollection();
IRemovable addRemoveCollection = new AddRemoveCollection();
IMylist myList = new MyList();

string[] items = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
foreach (string item in items)
{
    addedIndexes["AddCollection"].Add(addCollection.Add(item));
    addedIndexes["AddRemoveCollection"].Add(addRemoveCollection.Add(item));
    addedIndexes["MyList"].Add(myList.Add(item));
}
int removeCount = int.Parse(Console.ReadLine());
for (int i = 0; i < removeCount; i++)
{
    removedItems["AddRemoveCollection"].Add(addRemoveCollection.Remove());
    removedItems["MyList"].Add(myList.Remove());
}
Console.WriteLine(String.Join(" ",addedIndexes["AddCollection"]));
Console.WriteLine(String.Join(" ",addedIndexes["AddRemoveCollection"]));
Console.WriteLine(String.Join(" ",addedIndexes["MyList"]));

Console.WriteLine(String.Join(" ",removedItems["AddRemoveCollection"]));
Console.WriteLine(String.Join(" ",removedItems["MyList"]));