using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

struct StudentGame
{
    public string Name;
    public HashSet<string> Games;
}

class a
{


    public static void l1(uint len = 40)
    {
        Random rand = new Random();
        List<int> L = new List<int>();
        List<int> L1 = new List<int>();
        List<int> L2 = new List<int>();
        for (int i = 0; i < len; i++)
        {
            L.Add(rand.Next(0, 5));
        }
        Console.WriteLine(string.Join(", ", L));

        for (int i = 0; i < 2; i++)
        {
            L1.Add(rand.Next(0, 5));
        }
        Console.WriteLine("\nReplaced");
        Console.WriteLine(string.Join(", ", L1));

        for (int i = 0; i < 5; i++)
        {
            L2.Add(rand.Next(-100, 0));
        }
        Console.WriteLine("To");
        Console.WriteLine(string.Join(", ", L2));

        int c = 0;
        int index = -1;

        for (int i = 0; i < L.Count - L1.Count + 1; i++)
        {
            c = 0;
            for (int i1 = 0; i1 < L1.Count; i1++)
            {
                if (L[i + i1] == L1[i1]) c++;
                if (c == L1.Count)
                {
                    index = i;
                    break;
                }
            }
        }

        if (index != -1)
        {
            L.RemoveRange(index, L1.Count);
            L.InsertRange(index, L2);
        }
        Console.WriteLine("\nIn positon");
        Console.WriteLine(index);
        Console.WriteLine("\nResult");
        Console.WriteLine(string.Join(", ", L));
    }

    public static void l2(int len = 20)
    {
        Random a = new Random();
        LinkedList<int> list = new LinkedList<int>();
        for (int i = 0; i < len; i++)
        {
            list.AddLast(a.Next(-100, 100));
        }

        Console.WriteLine("\nSorted from");
        Console.WriteLine(string.Join(", ", list));
        Console.WriteLine("\nTo");

        LinkedList<int> s = new LinkedList<int>(list.OrderBy(x => x));
        Console.WriteLine(string.Join(", ", s));
    }

    public static void l3()
    {


        var students = new HashSet<StudentGame>
        {
            new StudentGame { Name = "Иван", Games = new HashSet<string> { "game1", "game2" } },
            new StudentGame { Name = "Мария", Games = new HashSet<string> { "game1", "game3" } },
            new StudentGame { Name = "Пётр", Games = new HashSet<string> { "game1", "game4" } },
            new StudentGame { Name = "Анна", Games = new HashSet<string> { "game2", "game1" } },
        };

        var allGames = new HashSet<string>();
        allGames.Add("game5");
        var all = new HashSet<string>();
        var noone = new HashSet<string>();

        foreach (var student in students)
        {
            allGames.UnionWith(student.Games);
        }


        foreach (string i in allGames)
        {
            if (students.All(a => a.Games.Contains(i)))
            {
                all.Add(i);
            }
            if (students.All(a => !a.Games.Contains(i)))
            {
                noone.Add(i);
            }
        }
        var any = allGames.Except(noone);
        Console.WriteLine("\nFrom all games");
        Console.WriteLine(string.Join(", ", allGames));
        Console.WriteLine("\nEveryone plays");
        Console.WriteLine(string.Join(", ", all));
        Console.WriteLine("\nSomeone plays");
        Console.WriteLine(string.Join(", ", any));
        Console.WriteLine("\nNoone plays");
        Console.WriteLine(string.Join(", ", noone));

    }

    public static void l4(int len = 2)
    {
        Random rand = new Random();
        string chars = "йцукенгшщзхъфывапролджэячсмитьбюё";
        string chars1 = "бпткмнхцчшщ";
        using (StreamWriter writer = new StreamWriter("rnd.txt", false))
        {
            for (int i = 0; i < len; i += 0)
            {
                writer.Write($"{chars[rand.Next(chars.Length)]}");
                if (rand.Next(40) == 3)
                {
                    i++;
                    writer.Write(" ");
                }
            }

        }

        var missing = new HashSet<char>();
        foreach (char ch in chars1)
        {
            missing.Add(ch);
        }
        var missing_count = missing;



        string content = File.ReadAllText("rnd.txt");
        Console.WriteLine(content);
        int i1 = 0;
        string a;
        for (int i = 0; i < len; i++)
        {




            a = "";
            var missing_count1 = new HashSet<char>();
            while (content[i1] != ' ')
            {
                a += content[i1];
                i1++;
            }
            i1++;



            foreach (char ch in a)
            {
                if (missing.Contains(ch))
                {
                    missing_count1.Add(ch);
                }
            }

            missing_count = missing_count.Intersect(missing_count1).ToHashSet();


        }

        missing = missing.Except(missing_count).ToHashSet();

        Console.WriteLine(string.Join(", ", missing));
    }

    public static void l5(int len = 2)
    {
        Console.WriteLine("пятого нет мне лень его делать");
    }
}

class Program
{
    static void Main()
    {
        try {
            Console.WriteLine("---------------1--------------");
            a.l1();
            Console.WriteLine("---------------2--------------");
            a.l2();
            Console.WriteLine("---------------3--------------");
            a.l3();
            Console.WriteLine("---------------4--------------");
            a.l4();
            Console.WriteLine("---------------5--------------");
            a.l5();

        }
        catch (Exception e)
        {
            Console.WriteLine("неверное название файла");
        }
        }
    
}