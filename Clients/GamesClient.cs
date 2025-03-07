
using GameStore.FrontEnd.Models;

namespace GameStore.FrontEnd.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games =
     [
     new() {
        Id= 1,
        Name = "Street Fighter II",
        Genre = "Fighting",
        Price= 19.99M,
        ReleaseDate = new DateOnly(1992,7,15)
        },
        new() {
        Id= 2,
        Name = "Final Fantasy XIV",
        Genre = "Roleplaying",
        Price= 59.99M,
        ReleaseDate = new DateOnly(2010,9,30)
        },
        new() {
        Id= 2,
        Name = "FIFA 23",
        Genre = "Sports",
        Price= 69.99M,
        ReleaseDate = new DateOnly(2022,9,27)
        }
     ];

    public GameSummary[] GetGames() => [.. games];
    public readonly Genre[] genres = new GenresClient().GetGenres();
    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrEmpty(game.GenreId);

        var genre = genres.Single(x => x.Id == int.Parse(game.GenreId));

        var gameSummary = new GameSummary()
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        games.Add(gameSummary);
        
    }
}
