namespace PokeAdvantage
{
    public interface IPokemonApiClient
    {
        Task<string> GetPokemonAsync(string pokemonName);
        Task<string> GetTypeRelationsAsync(string typeName);
    }

}
