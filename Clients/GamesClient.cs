
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
        Id= 3,
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
        Genre genre = GetGenreByID(game.GenreId);

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

    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
    public void UpdateGame(GameDetails updateGame)
    {
        var genre = GetGenreByID(updateGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updateGame.Id);

        ArgumentNullException.ThrowIfNull(existingGame);

        existingGame.Name = updateGame.Name;
        existingGame.Price = updateGame.Price;
        existingGame.ReleaseDate = updateGame.ReleaseDate;
        existingGame.Genre = genre.Name;

    }
    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(x => x.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreByID(string? id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);

        return genres.Single(x => x.Id == int.Parse(id));
    }
}
