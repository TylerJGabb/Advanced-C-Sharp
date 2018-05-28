using System;

namespace Main_Project.Events
{
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs ve)
        {
            Console.WriteLine($"Mail Service: '{ve.Video.Title}' Mail Sent");
        }
    }
}