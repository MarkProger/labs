var player = new Player(new LockedState());

player.Play();

player.SetState(new BatteryLowState());
player.Play();

player.SetState(new UnlockedState());
player.Play();
player.Pause();


public interface IPlayerState
{
    void Play(Player player);
    void Stop(Player player);
    void Pause(Player player);
    void Repeat(Player player);
}

public class Player
{
    private IPlayerState _state;

    public Player(IPlayerState initialState)
    {
        _state = initialState;
    }

    public void SetState(IPlayerState state)
    {
        _state = state;
    }

    public void Play() => _state.Play(this);
    public void Stop() => _state.Stop(this);
    public void Pause() => _state.Pause(this);
    public void Repeat() => _state.Repeat(this);
}

public class UnlockedState : IPlayerState
{
    public void Play(Player player) => Console.WriteLine("Вiдтворення радiо...");
    public void Stop(Player player) => Console.WriteLine("Зупинка радiо.");
    public void Pause(Player player) => Console.WriteLine("Пауза.");
    public void Repeat(Player player) => Console.WriteLine("Повтор вiдтворення.");
}

public class LockedState : IPlayerState
{
    public void Play(Player player) => ShowUnlockScreen();
    public void Stop(Player player) => ShowUnlockScreen();
    public void Pause(Player player) => ShowUnlockScreen();
    public void Repeat(Player player) => ShowUnlockScreen();

    private void ShowUnlockScreen() => Console.WriteLine("Плеєр заблокований. Розблокуйте пристрiй.");
}

public class BatteryLowState : IPlayerState
{
    public void Play(Player player) => ShowLowBattery();
    public void Stop(Player player) => ShowLowBattery();
    public void Pause(Player player) => ShowLowBattery();
    public void Repeat(Player player) => ShowLowBattery();

    private void ShowLowBattery() => Console.WriteLine("Низький заряд. Пiдключiть зарядку.");
}
