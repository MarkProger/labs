using System;


IAlarmCImpl soundAlarm = new SoundAlarm();
IAlarmCImpl smsAlarm = new SMSAlarm();

AlarmC basicAlarm = new BasicAlarm(soundAlarm);
basicAlarm.Start();
basicAlarm.ToWake();
basicAlarm.Stop();

Console.WriteLine();

AlarmC smsBasedAlarm = new BasicAlarm(smsAlarm);
smsBasedAlarm.Start();
smsBasedAlarm.ToWake();
smsBasedAlarm.Stop();


public interface IAlarmCImpl
{
    void Ring();
    void Notify();
}

public class SoundAlarm : IAlarmCImpl
{
    public void Notify()
    {
        Console.WriteLine("Sending notification: TIme to wake up!");
    }

    public void Ring()
    {
        Console.WriteLine("Alarm is ringing!");
    }
}

public class SMSAlarm : IAlarmCImpl
{
    public void Notify()
    {
        Console.WriteLine("SMS Notification sent!");
    }

    public void Ring()
    {
        Console.WriteLine("SMS Alarm: Wake up!");
    }
}

public abstract class AlarmC
{
    protected IAlarmCImpl alarmCImpl;

    protected AlarmC(IAlarmCImpl alarmCImpl)
    {
        this.alarmCImpl = alarmCImpl;
    }

    public abstract void Start();
    public abstract void Stop();
    public abstract void ToWake();
}

public class BasicAlarm : AlarmC
{
    public BasicAlarm(IAlarmCImpl alarmCImpl) : base(alarmCImpl) { }

    public override void Start()
    {
        Console.WriteLine("Starting the alarm...");
    }
    public override void Stop()
    {
        Console.WriteLine("Stopping the alarm...");
    }
    public override void ToWake()
    {
        Console.WriteLine("Activating wake-up process");
        alarmCImpl.Ring();
        alarmCImpl.Notify();
    }
}