using SQLite;

namespace UserSettings;
public partial class UserSettingsPage
{
    public class UserSet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool classicOrNew { get; set; }
    }
}