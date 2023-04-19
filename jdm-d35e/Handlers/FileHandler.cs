namespace jdm_d35e.Handlers
{
    internal static class FileHandler
    {
        public static Models.File GetNew()
        {
            return new Models.File();
        }

        public static Models.File Load(string path)
        {
            return new Models.File(GameHandler.Deserialize(System.IO.File.ReadAllText(path)));
        }

        public static void Save(Models.File file)
        {
            if (file.Path == null) { throw new System.InvalidOperationException(); }
            System.IO.File.WriteAllText(file.Path, GameHandler.Serialize(file.Game));
            file.IsDirty = false;
        }

        public static void SaveAs(Models.File file, string path)
        {
            file.Path = path;
            System.IO.File.WriteAllText(file.Path, GameHandler.Serialize(file.Game));
            file.IsDirty = false;
        }
    }
}
