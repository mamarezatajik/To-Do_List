using System.ComponentModel.DataAnnotations;
namespace To_Do_Project;
public class To_Do
{
    public To_Do()
    {
    }
    public To_Do(string titleId, DateTime date, string plan )
    {
        Date = date;
        Plan = plan;
        TitleId = titleId;
    }
    public DateTime Date{get; set;}
    public string Plan {get; set;}
    [Key]
    public string TitleId {get; set;}
}