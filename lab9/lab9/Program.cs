using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


FootballMatch match = new FootballMatch("Karpaty", "Dynamo");

BettingClient client1 = new BettingClient("Mark", "Karpaty");
BettingClient client2 = new BettingClient("Ivan", "Dynamo");

match.Attach(client1);
match.Attach(client2);

match.PlayMatch();

interface IObserver
{
    void Update(string matchEvent, int minute);
}

interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string matchEvent, int minute);
}

class FootballMatch : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private List<(int minute, string team)> goals = new List<(int, string)>();
    private Random rnd = new Random();
    public string TeamA { get; }
    public string TeamB { get; }

    public FootballMatch(string teamA, string teamB)
    {
        TeamA = teamA;
        TeamB = teamB;
    }

    public void Attach(IObserver observer) => observers.Add(observer);
    public void Detach(IObserver observer) => observers.Remove(observer);

    public void Notify(string matchEvent, int minute)
    {
        foreach (var observer in observers)
        {
            observer.Update(matchEvent, minute);
        }
    }

    public void PlayMatch()
    {
        GenerateRandomGoals();

        for (int minute = 1; minute <= 90; minute += 5)
        {
            var goalsNow = goals.Where(g => g.minute == minute).ToList();
            string matchEvent;

            if (goalsNow.Any())
            {
                matchEvent = string.Join(" & ", goalsNow.Select(g => $"Goal by {g.team}!"));
            }
            else
            {
                matchEvent = $"Minute {minute}: No goals.";
            }

            Console.WriteLine($"[MATCH UPDATE] {matchEvent}");
            Notify(matchEvent, minute);

            Thread.Sleep(500);
        }
    }

    private void GenerateRandomGoals()
    {
        int goalCount = rnd.Next(0, 5);
        HashSet<int> usedMinutes = new HashSet<int>();

        while (goals.Count < goalCount)
        {
            int minute = rnd.Next(5, 86);
            if (!usedMinutes.Contains(minute))
            {
                usedMinutes.Add(minute);
                string team = rnd.Next(0, 2) == 0 ? TeamA : TeamB;
                goals.Add((minute, team));
            }
        }

        goals.Sort((g1, g2) => g1.minute.CompareTo(g2.minute));
    }
}

class BettingClient : IObserver
{
    public string Name { get; }
    private string currentBet;

    public BettingClient(string name, string initialBet)
    {
        Name = name;
        currentBet = initialBet;
    }

    public void Update(string matchEvent, int minute)
    {
        Console.WriteLine($"[CLIENT {Name}] Update: {matchEvent}");
        ChangeBetIfNeeded(matchEvent, minute);
    }

    private void ChangeBetIfNeeded(string matchEvent, int minute)
    {
        if (matchEvent.Contains("Karpaty") && currentBet != "Karpaty")
        {
            Console.WriteLine($"[CLIENT {Name}] Changes bet to Karpaty");
            currentBet = "Karpaty";
        }
        else if (matchEvent.Contains("Dynamo") && currentBet != "Dynamo")
        {
            Console.WriteLine($"[CLIENT {Name}] Changes bet to Dynamo");
            currentBet = "Dynamo";
        }
    }
}