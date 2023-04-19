namespace jdm_d35e.Handlers
{
    internal static class GameHandler
    {
        public static Models.Game Deserialize(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<Models.Game>(json)
                ?? throw new System.InvalidOperationException();
        }

        public static string Serialize(Models.Game game)
        {
            return System.Text.Json.JsonSerializer.Serialize(game);
        }
    }
}
