using ChatGPTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTXUnitTest
{
    internal class ChatGptTest
    {
        public static List<ChatGpt> GetGptList()
        {
            return new List<ChatGpt>
            {
                new ChatGpt
                {
                    Id = 1,
                    Name = "manpreet",
                    Summary = "singh",
                },
                new ChatGpt
                {
                    Id = 2,
                    Name = "Raj",
                    Summary = "Kumar",

                }
            };
        }
    }
}