using System;
using static System.Console;
namespace To_Do_Project;
using static System.Threading.Thread;
using To_Do_ApiCli.Api;
using To_Do_ApiCli.Client;
using To_Do_ApiCli.Model;

public class To_Do_Program
{
    public static void Main()
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
        ToDoApi apiInstance = new ToDoApi(config);

        WriteLine("\n\n\n\n\n\n\nHello  :)");
        Sleep(1000);

        WriteLine("\n\nWelcome to your app.");
        Sleep(1000);

        WriteLine("\n\nTo Do App.");
        Sleep(1000);

        WriteLine("\n\nIf you want to see your to-do list, write down:                        list ");
        Sleep(1000);

        WriteLine("\nIf you want to add activity to your to-do list, write down:            add");
        Sleep(1000);

        WriteLine("\nIf you want to delete an activity from your to-do list, write down:    delete");
        Sleep(1000);

        WriteLine("\nif you want to delete all activities   , write down:                   deleteall");
        Sleep(1000);

        WriteLine("\nand finally if you want to exit  :(   , write down:                    exit");
        Sleep(1000);

        WriteLine("\n\n\n                  small or capital letter doesn't matter  :)\n");
        Sleep(1000);


        while (true)
        {
            string input = ReadLine().Trim() ;
            if ( input.ToLower().Trim() == "list" )
            {
                WriteLine("\n");
                Get_To_Do_in_Program();
            }
            else if (input.ToLower().Trim() == "add")
            {
                Add_To_Do_in_Program();
            }
            else if (input.ToLower().Trim() == "delete")
            {
                Delete_To_Do_in_Program();
            }
            else if (input.ToLower().Trim() == "deleteall")
            {
                Delete_All_Activities();
            }
            else if (input.ToLower().Trim() == "exit")
            {
                break;
            }
            else
            {
                WriteLine("\n\nlist / add / delete / deleteall / exit\n\n");
            }
        }
        
    }

    public static void Add_To_Do_in_Program()
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
        ToDoApi apiInstance = new ToDoApi(config);
        Console.WriteLine("What do you want to do? ");
        string title = ReadLine().Trim();

        Console.WriteLine("What is your plan? ");
        string plan = ReadLine().Trim();
        
        Console.WriteLine("How many days later you want to do that? (a number more than 0) ");
        DateTime today = DateTime.Now;

        double add_day = 0;
        while (true)
        {
            double.TryParse(ReadLine().Trim() , out double rl);
            if (rl > 0)
            {
                add_day = rl;
                break;
            }
            else
            {
                WriteLine("try again");
            }
        }
        
        DateTime dt = today.AddDays(add_day);

        To_Do_ApiCli.Model.ToDo td = new To_Do_ApiCli.Model.ToDo(dt, plan, title);
        apiInstance.ToDoPost(td);
        WriteLine("\nsuccessful\nwrite:  add or delete or list or exit\n");

    } 
    public static void Get_To_Do_in_Program()
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
        ToDoApi apiInstance = new ToDoApi(config);
        var result = apiInstance.ToDoGet();

        WriteLine("                                    Your To-Do List\n");
        Write("Number.  Titles                          Plans                            Dates\n");
        WriteLine("-------------------------------------------------------------------------------------");
        Sleep(400);
        int count = 1;
        foreach(var info in result.OrderBy(m=>m.Date.DayOfYear))
        {
            Sleep(150);
            Write($"     {count}.  ");
            Write(info.TitleId.ToString());
            for (int i = 12; i >= info.TitleId.Length; i--)
                {
                    Write(" ");
                }

            Write("     ------>       ");

            Write(info.Plan.ToString());
            for (int i = 12; i >= info.Plan.Length; i--)
                {
                    Write(" ");
                }

            Write("    ------>       ");

            Write($"{info.Date.Year}/{info.Date.Month}/{info.Date.Day}\n\n");
            count++;
        }
        Sleep(200);
        WriteLine("------------------------------------------------------------------------------------\n");
    }
    public static void Delete_To_Do_in_Program()
    {
        Write("Which activity you want to delete? ");
        while(true)
        {
            try
            {
                var input = ReadLine().Trim();
                if ( input.ToLower().Trim() == "list" )
                {
                    WriteLine("\n");
                    Get_To_Do_in_Program();
                }
                else if (input.ToLower().Trim() == "exit")
                {
                    break;
                }
                Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
                ToDoApi apiInstance = new ToDoApi(config);
                apiInstance.ToDoIdDelete(input);
                WriteLine("\nSuccessfully deleted.\n");
                WriteLine("now again write list/add/delete/deleteall/exit");
                break;
            }
            catch (System.Exception)
            {
                WriteLine("\ntry again.   (you can see list or exit)\n");
            }
        }
    }

    public static void Delete_All_Activities()
    {
        Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
        ToDoApi apiInstance = new ToDoApi(config);
        var result = apiInstance.ToDoGet();
        foreach (var item in result)
        {
            apiInstance.ToDoIdDelete(item.TitleId);   
        }
        WriteLine("All activities, successfully deleted.\n");
    }
}