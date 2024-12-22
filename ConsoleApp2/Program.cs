public class Player
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int Score { get; set; }

    public Player(string name, string position, int score)
    {
        Name = name;
        Position = position;
        Score = score;
    }
    
    public void UpdateScore(int newScore)
    {
        Score = newScore;
    }
}
public class Team
{
    public List<Player> players = new List<Player>();
    public void AddPlayer(Player player)
    {
        players.Add(player);
    }
    public void RemovePlayer(string name)
    {
        var player = players.FirstOrDefault(player => player.Name == name);
        if (player != null)
        {
            players.Remove(player);
        }
        else
        {
            Console.WriteLine("Zawodnik nie znaleziony.");
        }
    }
    
    public void DisplayTeamStats()
    {
        Console.WriteLine("Statystyki druzyny:");
        foreach (var player in players)
        {
            Console.WriteLine($"Imie: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
        }
    }
    public static double CalculateTeamAverage(List<Player> players)
    {
        if (players.Count == 0) return 0;
        return players.Average(player => player.Score);
    }
    
    public List<Player> SearchPlayersByPosition(string position)
    {
        return players.Where(player => player.Position.Equals(position, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    
    public List<Player> FilterPlayers(Func<Player, bool> filter)
    {
        return players.Where(filter).ToList();
    }
    
}

