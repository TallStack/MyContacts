using System;
namespace MyContacts.DataStore.SQLLite
{
    public class Constants
    {
        public const string databaseFileName = "ContactsSQLite.db3";

        public static string databasePath => Path.Combine(FileSystem.AppDataDirectory, databaseFileName);

    }
}

