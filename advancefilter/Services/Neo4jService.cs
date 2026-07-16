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

    public async Task SeedKnowledgeGraph()
    {
        var session = _driver.AsyncSession();

        await session.RunAsync(@"
MERGE (c:Chatbot {name:'MovieBot'})

MERGE (r:RAG {name:'RAG'})
MERGE (k:KnowledgeGraph {name:'Neo4j'})
MERGE (m:Model {name:'Gemma4'})
MERGE (f1:Feature {name:'Movie Search'})
MERGE (f2:Feature {name:'Chat'})
MERGE (f3:Feature {name:'Recommendation'})

MERGE (c)-[:USES]->(m)

MERGE (c)-[:HAS_FEATURE]->(f1)
MERGE (c)-[:HAS_FEATURE]->(f2)
MERGE (c)-[:HAS_FEATURE]->(f3)

MERGE (c)-[:USES]->(r)
MERGE (r)-[:USES]->(k)
");

        await session.CloseAsync();
    }

    public async Task<List<string>> GetFeatures()
    {
        var session = _driver.AsyncSession();

        var cursor = await session.RunAsync(
            @"MATCH (:Chatbot)-[:HAS_FEATURE]->(f:Feature)
              RETURN f.name AS feature");

        var list = new List<string>();

        await cursor.ForEachAsync(record =>
        {
            list.Add(record["feature"].As<string>());
        });

        await session.CloseAsync();

        return list;
    }
    public async Task<string> GetChatbotContext()
    {
        var features = await GetFeatures();

        return $"This chatbot has the following features: {string.Join(", ", features)}";
    }
}