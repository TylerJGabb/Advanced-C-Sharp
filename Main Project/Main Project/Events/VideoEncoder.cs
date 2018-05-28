using System;
using System.Threading;

namespace Main_Project.Events
{
    public class VideoEncoder
    {

        //1- Define a delegate
        //2- Define an event based on that delegate, which allows subscriptions
        //3- Raise the event


        public delegate void VideoEncodedEventHandler(object sender, VideoEventArgs args);

        public event EventHandler<VideoEventArgs> VideoEncoded;

        protected virtual void OnVideoEncoded(Video video)
        {
            VideoEncoded?.Invoke(this, new VideoEventArgs(){Video = video});
        }


        public void Encode(Video video)
        {
            Console.WriteLine($"Encoding '{video.Title}'");
            Thread.Sleep(3000);
            Console.WriteLine("Video Encoded");
            OnVideoEncoded(video);
        }

        public static void Demo()
        {
            var video = new Video
            {
                Title = "Some Video"
            };

            var encoder = new VideoEncoder();
            var mailService = new MailService();
            var messageService = new MessageService();

            encoder.VideoEncoded += mailService.OnVideoEncoded;
            encoder.VideoEncoded += messageService.OnVideoEncoded;


            encoder.Encode(video);

        }
    }
}