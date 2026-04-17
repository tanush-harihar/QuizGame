using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    private List<List<Question>> questions; // 0 = Networking, 1 = Programming, 2 = General

    private int currentCategory = 0;
    private int currentIndex = 0;

    private Question currentQuestion;

    void Awake()
    {
        questions = new List<List<Question>>();

        // ---------------- NETWORKING ----------------
        questions.Add(new List<Question>
        {
            new Question { questionText = "What is TCP?", answers = new string[] { "Protocol", "Cable", "Port", "Device" }, correctIndex = 0 },
            new Question { questionText = "What is UDP?", answers = new string[] { "Reliable", "Unreliable", "Connection-oriented", "Secure" }, correctIndex = 1 },
            new Question { questionText = "What does IP stand for?", answers = new string[] { "Internet Protocol", "Internal Port", "Input Process", "Internet Port" }, correctIndex = 0 },
            new Question { questionText = "Which layer is TCP in OSI?", answers = new string[] { "Application", "Transport", "Network", "Data Link" }, correctIndex = 1 },
            new Question { questionText = "What is a router?", answers = new string[] { "Connects networks", "Stores data", "Displays output", "Encrypts files" }, correctIndex = 0 },
            new Question { questionText = "Port number of HTTP?", answers = new string[] { "21", "25", "80", "443" }, correctIndex = 2 },
            new Question { questionText = "Port number of HTTPS?", answers = new string[] { "80", "443", "21", "22" }, correctIndex = 1 },
            new Question { questionText = "What is DNS?", answers = new string[] { "Name to IP resolver", "File transfer", "Security protocol", "Routing table" }, correctIndex = 0 },
            new Question { questionText = "Which device uses MAC address?", answers = new string[] { "Router", "Switch", "Firewall", "Modem" }, correctIndex = 1 },
            new Question { questionText = "What is ping used for?", answers = new string[] { "Check connectivity", "Transfer files", "Encrypt data", "Assign IP" }, correctIndex = 0 },
            new Question { questionText = "What is DHCP?", answers = new string[] { "Assigns IP automatically", "Encrypts traffic", "Stores data", "Controls bandwidth" }, correctIndex = 0 },
            new Question { questionText = "Which protocol is secure?", answers = new string[] { "HTTP", "FTP", "HTTPS", "Telnet" }, correctIndex = 2 },
            new Question { questionText = "What is firewall?", answers = new string[] { "Security system", "Storage device", "Cable type", "CPU part" }, correctIndex = 0 },
            new Question { questionText = "Which layer handles routing?", answers = new string[] { "Transport", "Network", "Session", "Application" }, correctIndex = 1 },
            new Question { questionText = "What is latency?", answers = new string[] { "Delay", "Speed", "Bandwidth", "Packet size" }, correctIndex = 0 },
            new Question { questionText = "What is bandwidth?", answers = new string[] { "Data capacity", "Delay", "Packet loss", "Error rate" }, correctIndex = 0 },
            new Question { questionText = "What is packet?", answers = new string[] { "Data unit", "Cable", "Protocol", "Device" }, correctIndex = 0 },
            new Question { questionText = "Which protocol sends emails?", answers = new string[] { "SMTP", "HTTP", "FTP", "DNS" }, correctIndex = 0 },
            new Question { questionText = "Which protocol retrieves emails?", answers = new string[] { "POP3", "SMTP", "DNS", "ARP" }, correctIndex = 0 },
            new Question { questionText = "What is ARP?", answers = new string[] { "IP to MAC mapping", "Encryption", "Routing", "Compression" }, correctIndex = 0 }
        });

        // ---------------- PROGRAMMING ----------------
        questions.Add(new List<Question>
        {
            new Question { questionText = "Which language does Unity use?", answers = new string[] { "Java", "Python", "C#", "C++" }, correctIndex = 2 },
            new Question { questionText = "What is a variable?", answers = new string[] { "Stores data", "Executes code", "Loops program", "Compiles code" }, correctIndex = 0 },
            new Question { questionText = "Which is a loop?", answers = new string[] { "if", "for", "int", "class" }, correctIndex = 1 },
            new Question { questionText = "What is function?", answers = new string[] { "Reusable code block", "Variable", "Loop", "Class" }, correctIndex = 0 },
            new Question { questionText = "What is a class?", answers = new string[] { "Blueprint", "Loop", "Variable", "Compiler" }, correctIndex = 0 },
            new Question { questionText = "What is an object?", answers = new string[] { "Instance of class", "Loop", "Variable", "Compiler" }, correctIndex = 0 },
            new Question { questionText = "Which is a loop?", answers = new string[] { "if", "for", "int", "class" }, correctIndex = 1 },
            new Question { questionText = "What is function?", answers = new string[] { "Reusable code block", "Variable", "Loop", "Class" }, correctIndex = 0 },
            new Question { questionText = "What is debugging?", answers = new string[] { "Fixing errors", "Writing code", "Running code", "Compiling" }, correctIndex = 0 },
            new Question { questionText = "What is syntax error?", answers = new string[] { "Code mistake", "Runtime error", "Logic error", "Memory leak" }, correctIndex = 0 },
            new Question { questionText = "What is compiler?", answers = new string[] { "Translates code", "Executes code", "Stores data", "Deletes files" }, correctIndex = 0 },
            new Question { questionText = "What is IDE?", answers = new string[] { "Development environment", "Compiler", "OS", "Database" }, correctIndex = 0 },
            new Question { questionText = "What is recursion?", answers = new string[] { "Function calling itself", "Loop", "Variable", "Class" }, correctIndex = 0 },
            new Question { questionText = "What is inheritance?", answers = new string[] { "Reuse code", "Delete code", "Loop", "Compile" }, correctIndex = 0 },
            new Question { questionText = "What is encapsulation?", answers = new string[] { "Data hiding", "Loop", "Execution", "Compilation" }, correctIndex = 0 },
            new Question { questionText = "What is polymorphism?", answers = new string[] { "Many forms", "Single form", "Loop", "Error" }, correctIndex = 0 },
            new Question { questionText = "What is exception?", answers = new string[] { "Runtime error", "Loop", "Class", "Compiler" }, correctIndex = 0 },
            new Question { questionText = "What is boolean?", answers = new string[] { "True/False", "Number", "String", "Array" }, correctIndex = 0 },
            new Question { questionText = "What is string?", answers = new string[] { "Text data", "Number", "Loop", "Class" }, correctIndex = 0 }
        });

        // ---------------- GENERAL ----------------
        questions.Add(new List<Question>
        {
            new Question { questionText = "Capital of India?", answers = new string[] { "Mumbai", "Delhi", "Pune", "Chennai" }, correctIndex = 1 },
            new Question { questionText = "2 + 2 = ?", answers = new string[] { "3", "4", "5", "6" }, correctIndex = 1 },
            new Question { questionText = "Largest planet?", answers = new string[] { "Earth", "Mars", "Jupiter", "Saturn" }, correctIndex = 2 },
            new Question { questionText = "Sun is a?", answers = new string[] { "Planet", "Star", "Galaxy", "Comet" }, correctIndex = 1 },
            new Question { questionText = "Human heart chambers?", answers = new string[] { "2", "3", "4", "5" }, correctIndex = 2 },
            new Question { questionText = "Which is a programming language?", answers = new string[] { "Python", "HTML", "CSS", "All" }, correctIndex = 3 },
            new Question { questionText = "Which gas do plants use?", answers = new string[] { "Oxygen", "Nitrogen", "CO2", "Hydrogen" }, correctIndex = 2 },
            new Question { questionText = "Speed of light?", answers = new string[] { "3x10^8 m/s", "1x10^6", "5x10^3", "10^2" }, correctIndex = 0 },
            new Question { questionText = "Who invented computer?", answers = new string[] { "Newton", "Einstein", "Babbage", "Tesla" }, correctIndex = 2 },
            new Question { questionText = "Binary of 2?", answers = new string[] { "10", "01", "11", "00" }, correctIndex = 0 },
            new Question { questionText = "Which is not OS?", answers = new string[] { "Windows", "Linux", "Oracle", "MacOS" }, correctIndex = 2 },
            new Question { questionText = "Which is input device?", answers = new string[] { "Monitor", "Keyboard", "Printer", "Speaker" }, correctIndex = 1 },
            new Question { questionText = "Which is output device?", answers = new string[] { "Mouse", "Keyboard", "Monitor", "Scanner" }, correctIndex = 2 },
            new Question { questionText = "RAM is?", answers = new string[] { "Volatile memory", "Storage", "CPU", "Cache" }, correctIndex = 0 },
            new Question { questionText = "Full form of CPU?", answers = new string[] { "Central Processing Unit", "Computer Processing Unit", "Core Processing Unit", "Central Program Unit" }, correctIndex = 0 },
            new Question { questionText = "HTML is?", answers = new string[] { "Programming language", "Markup language", "OS", "Database" }, correctIndex = 1 },
            new Question { questionText = "Which is browser?", answers = new string[] { "Chrome", "Windows", "Linux", "CPU" }, correctIndex = 0 },
            new Question { questionText = "Which is database?", answers = new string[] { "MySQL", "HTML", "CSS", "HTTP" }, correctIndex = 0 }
        });
    }
    public void SetCategory(int categoryIndex)
    {
        if (categoryIndex < 0 || categoryIndex >= questions.Count)
        {
            Debug.LogError("Invalid category index!");
            return;
        }

        currentCategory = categoryIndex;
        currentIndex = 0;
    }

    // 🔥 GET NEXT QUESTION (serial progression)
    public Question GetNextQuestion()
    {
        List<Question> selectedList = questions[currentCategory];

        if (selectedList.Count == 0)
        {
            Debug.LogError("No questions in this category!");
            return null;
        }

        if (currentIndex >= selectedList.Count)
        {
            Debug.Log("All questions in this category completed!");
            currentIndex = 0; // or stop game
        }

        currentQuestion = selectedList[currentIndex];
        currentIndex++;
        if (currentQuestion.answers.Length != 4)
        {
            EnsureFourAnswers(currentQuestion);
        }
        return currentQuestion;
    }

    public bool CheckAnswer(int index)
    {
        return index == currentQuestion.correctIndex;
    }
    void EnsureFourAnswers(Question q)
    {
        List<string> answers = new List<string>(q.answers);

        while (answers.Count < 4)
        {
            answers.Add("Unknown"); // fallback option
        }

        q.answers = answers.ToArray();
    }
}