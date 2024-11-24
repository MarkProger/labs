using System;


IPhone phoneCall = new Phone();
phoneCall.MakeCall();

Console.WriteLine();

VideoCamera videoCamera = new VideoCamera();
IPhone videoCall = new VideoCallAdapter(videoCamera);
videoCall.MakeCall();

Console.ReadLine();

public interface IPhone
{
    void MakeCall();
}

public class Phone : IPhone
{
    public void MakeCall()
    {
        Console.WriteLine("Making a voice call...");
    }
}

public class VideoCamera
{
    public void StartVideo()
    {
        Console.WriteLine("Video camera is now streaming video...");
    }
}

public class VideoCallAdapter : IPhone
{
    private readonly VideoCamera _videoCamera;

    public VideoCallAdapter(VideoCamera videoCamera)
    {
        _videoCamera = videoCamera;
    }

    public void MakeCall()
    {
        Console.WriteLine("Starting a video call...");
        _videoCamera.StartVideo();
    }
}