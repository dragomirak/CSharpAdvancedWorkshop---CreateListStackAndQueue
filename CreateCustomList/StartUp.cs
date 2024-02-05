using System;

namespace CreateCustomList;

public class StartUp
{
    static void Main()
    {
        CustomList list = new CustomList();
        list.Add(111);
        list.Add(240);
        list.Add(15);
        list.Add(340);

        Console.WriteLine(list.Contains(88));
        Console.WriteLine(list.Contains(111));

        Console.WriteLine(list);
        Console.WriteLine(list.RemoveAt(0));
        Console.WriteLine(list);

        Console.WriteLine(list[0]);

        Console.WriteLine(list);
        list.Swap(0, 1);
        Console.WriteLine(list);


    }
}