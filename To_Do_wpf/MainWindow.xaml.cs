using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using To_Do_ApiCli.Api;
using To_Do_ApiCli.Client;
using To_Do_ApiCli.Model;
using To_Do_ApiCli.Test;

namespace To_Do_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
            ToDoApi apiInstance = new ToDoApi(config);
        }

        public void Add_activity(object? sender, RoutedEventArgs args)
        {
            if (CheckEmptyTextBoxes(TitleId_xml.Text) && CheckEmptyTextBoxes(Plan_xml.Text) && CheckEmptyTextBoxes(Date_xml.Text))
            {
                Reset_To_Do_List(sender, args);
                Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
                ToDoApi apiInstance = new ToDoApi(config);

                string title = TitleId_xml.Text;
                string plan = Plan_xml.Text;

                To_Do_ApiCli.Model.ToDo td = new To_Do_ApiCli.Model.ToDo(Date_xml.SelectedDate.Value, plan, title);
                apiInstance.ToDoPost(td);
                    MessageBox.Show($"{td.TitleId} has successfully added.");
                Get_all( sender,  args);
            }

            else
            {
                MessageBox.Show("Please fill the blanks.");
            }
            EmptyTextBoxes();
        }


        public void Delete_activity(object? sender, RoutedEventArgs args)
        {
            try
            {
                if (CheckEmptyTextBoxes(TitleId_xml.Text))
                {   
                    Reset_To_Do_List(sender, args);
                    Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
                    ToDoApi apiInstance = new ToDoApi(config);
                    apiInstance.ToDoIdDelete(TitleId_xml.Text.Trim());
                    MessageBox.Show($"{TitleId_xml.Text.Trim()} has successfully deleted.");
                    Get_all(sender, args);
                }
                else
                {
                    Reset_To_Do_List(sender, args);
                    Get_all(sender, args);
                    MessageBox.Show("Please write title that you want to delete.");     
                }
            }
            catch (System.Exception)
            {
                Reset_To_Do_List(sender, args);
                Get_all(sender, args);
                MessageBox.Show("invalid title.");
            }
            EmptyTextBoxes();
        }


        public void Get_all(object? sender, RoutedEventArgs args)
        {
            To_Do_List_xml.Text = string.Empty;
            Configuration config = new Configuration() {BasePath = "http://localhost:5072"};
            ToDoApi apiInstance = new ToDoApi(config);
            var result = apiInstance.ToDoGet();

            int count = 1;
            foreach(var info in result.OrderBy(m=>m.Date.DayOfYear))
            {
                string activity = $"{count}.   ";
                activity += info.TitleId ;
                for (int i = 15; i >= info.TitleId.Length; i--)
                {
                    activity += " ";
                }
                for (int i = 0; i < 10; i++)
                {
                    activity += "-";
                }
                activity += ">";
                for (int i = 0; i < 7; i++)
                {
                    activity += " ";
                }
                

                activity += info.Plan;
                for (int i = 15; i >= info.Plan.Length; i--)
                {
                    activity += " ";
                }
                for (int i = 0; i < 10 ; i++)
                {
                    activity += "-";
                }
                activity += ">";
                for (int i = 0; i < 7; i++)
                {
                    activity += " ";
                }

                activity += $"{info.Date.Year}/{info.Date.Month}/{info.Date.Day}";
                activity += "\n\n";

                To_Do_List_xml.Text += activity;
                count++;
                EmptyTextBoxes();
            }
        }


        public void Reset_To_Do_List(object? sender, RoutedEventArgs args)
        {
            To_Do_List_xml.Text = string.Empty;
        }

        private bool CheckEmptyTextBoxes(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }

        public void EmptyTextBoxes()
        {
            TitleId_xml.Text = string.Empty;
            Plan_xml.Text = string.Empty;
        }
    }
}