namespace jdm_d35e.Models
{
    internal class File
    {
        public File()
        {
            Game = new Game();
            IsDirty = true;
        }

        public File(Game game)
        {
            Game = game;
            IsDirty = false;
        }

        public Game Game { get; set; }

        public bool IsDirty { get; set; }

        public string? Path { get; set; }
    }
}
