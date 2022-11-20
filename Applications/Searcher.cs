namespace DispatchSys.Applications;

public class Searcher
{
    public void Submit(string text)
    {
        File.AppendAllText(@$"./logs_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.log", text);
    }
}
