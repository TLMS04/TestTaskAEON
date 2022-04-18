using UnityEngine;
public class Result
{
   
    private static Result _instance;
    public bool HasResult { get; set; }
    public string ResultText { get; private set; } = "����������� ���� ���";
    private Result()
    {}
    public static Result GetInstance()
    {
        if (_instance == null)
            _instance = new Result();
        return _instance;
    }
    public void SetText(string text)
    {
        HasResult = true;
        ResultText = text;
    }
}
