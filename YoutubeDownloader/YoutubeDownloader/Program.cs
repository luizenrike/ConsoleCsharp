
using VideoLibrary;

VideoDownload();

// codificação básica para testagem 
static void VideoDownload()
{
    Console.Write("URL: ");
    string URI = Console.ReadLine();

    Console.Write("QUALITY(360, 480, 720): ");
    int quality = Convert.ToInt32(Console.ReadLine());

    try
    {
        var youtube = YouTube.Default;
        
        var videoInfos = youtube.GetAllVideosAsync(URI).GetAwaiter().GetResult();
        //var video = youtube.GetVideoAsync(URI).GetAwaiter().GetResult();
        Thread.Sleep(20);
        
        Video video = videoInfos.First(v => v.Resolution == quality);
        Console.WriteLine(video.FullName+" downloaded");

        if (!Directory.Exists(@"C:\youtube"))
        {
            Directory.CreateDirectory(@"C:\youtube");
        }
        File.WriteAllBytes(@"C:\youtube\" + video.FullName, video.GetBytesAsync().GetAwaiter().GetResult());
        Console.WriteLine("Download completed, video in directory: " + @"C:\youtube");
    }catch(Exception e)
    {
        Console.WriteLine(e);
    }

}
