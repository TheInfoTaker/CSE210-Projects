using System;
using System.Collections.Generic;

public class ProvidePrompt
{
//     static void Main(string[] args)
//     {
//         Entry jounal = new Entry();
//         string fileName = "";

//         List<string> prompts = new List<string>
//     }
    private List<string> prompts = new List<string>
    {
        "What is a recent accomplishment you're proud of, no matter how small?",
        "Describe a person who has had a positive impact on your life and explain why.",
        "Reflect on a challenging situation you faced recently and how you handled it",
        "Write about a place you visited recently and what you observed or experienced there.",
        "What are three things you are grateful for today, and why?"
    };
    public string ProvideRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}