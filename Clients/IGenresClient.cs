
using GameStore.FrontEnd.Models;

namespace GameStore.FrontEnd.Clients;

public interface IGenresClient
{
  Genre[] GetGenres();
}
