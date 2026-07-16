using Neo4j.Driver;

namespace advancefilter.Services;

public class Neo4jService
{
    private readonly IDriver _driver;

    public Neo4jService()
    {
        _driver = GraphDatabase.Driver(
            "bolt://localhost:7687",
              
            AuthTokens.Basic("neo4j", "12345678"));
    }

    public async Task CreateMovie(string title, string genre)
    {
        var session = _driver.AsyncSession();

        await session.RunAsync(
            "CREATE (m:Movie {title:$title, genre:$genre})",
            new
            {
                title,
                genre
            });

        await session.CloseAsync();
    }
}