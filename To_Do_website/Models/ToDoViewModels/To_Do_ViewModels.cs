using System.Collections.Generic;
using To_Do_Project;
namespace To_Do_website
{
    public class To_Do_ViewModels
    {
        public List<To_Do_ApiCli.Model.ToDo> TodoList { get; set; }
        public To_Do Todo { get; set; }
    }
}