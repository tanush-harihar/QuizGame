using System.Collections.Generic;

[System.Serializable]
public class APIWrapper
{
    public List<APIQuestion> data;
}

public class APIQuestion
{
    public string text;
    public List<APIAnswer> answers;
}

public class APIAnswer
{
    public string text;
    public bool isCorrect;
}