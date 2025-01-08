using Microsoft.EntityFrameworkCore;
using To_Do_Project;
public class To_Do_Service
{
    private readonly To_Do_Context _context;
    public To_Do_Service(To_Do_Context context)
    {
        _context = context;
    }

    public IEnumerable<To_Do> Get_All() => _context.To_Do_DataBase_List.AsNoTracking().ToList();

    public To_Do Get_To_Do_By_TitleId(string id) => _context.To_Do_DataBase_List.Find(id);

    public To_Do Add_To_Do(To_Do newTo_Do)
    {
        _context.To_Do_DataBase_List.Add(newTo_Do);
        _context.SaveChanges();
        return newTo_Do;
    }

    public void Delete_To_Do_By_TitleId(string id)
    {
        var td_delete = Get_To_Do_By_TitleId(id);
        if (td_delete is not null)
        {
            _context.To_Do_DataBase_List.Remove(td_delete);
            _context.SaveChanges();
        }
    }
}