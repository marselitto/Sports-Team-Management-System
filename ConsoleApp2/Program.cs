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
class Program
{
    static void Main(string[] args)
    {
        var team = new Team();
        Console.WriteLine("Ile zawodników chcesz dodać do drużyny?");
        int playerCount;
        while (!int.TryParse(Console.ReadLine(), out playerCount) || playerCount <= 0)
        {
            Console.WriteLine("Proszę podać poprawną liczbę zawodników:");
        }
        for (int i = 0; i < playerCount; i++)
        {
            Console.WriteLine($"\nWprowadzanie danych dla zawodnika {i + 1}:");
            Console.Write("Imię zawodnika: ");
            string name = Console.ReadLine();
                
            Console.Write("Pozycja zawodnika: ");
            string position = Console.ReadLine();
                
            int score;
            Console.Write("Wynik zawodnika: ");
            while (!int.TryParse(Console.ReadLine(), out score) || score < 0)
            {
                Console.WriteLine("Proszę podać poprawny wynik:");
            }
            team.AddPlayer(new Player(name, position, score));
        }

            
        Console.WriteLine("\nStatystyki drużyny:");
        foreach (var player in team.players)
        {
            Console.WriteLine($"Imie: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
        }
            
        double average = Team.CalculateTeamAverage(team.players);
        Console.WriteLine($"\nŚredni wynik drużyny: {average}");
            
        Console.Write("\nPodaj pozycję, aby wyszukać zawodników: ");
        string positionSearch = Console.ReadLine();
        var filteredPlayers = team.SearchPlayersByPosition(positionSearch);
        Console.WriteLine($"Zawodnicy z pozycją {positionSearch}:");
        foreach (var player in filteredPlayers)
        {
            Console.WriteLine(player.Name);
        }
            
        Console.Write("\nPodaj imię zawodnika, którego chcesz usunąć: ");
        string playerToRemove = Console.ReadLine();
        team.RemovePlayer(playerToRemove);
        Console.WriteLine("\nPo usunięciu zawodnika:");
        foreach (var player in team.players)
        {
            Console.WriteLine($"Imie: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
        }
    }
}

