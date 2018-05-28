using System;

namespace Main_Project.Events
{
    public class MessageService
    {
        public void OnVideoEncoded(object sender, VideoEventArgs ve)
        {
            Console.WriteLine($"Message Service: '{ve.Video.Title}' Message Sent");
        }
    }
}