namespace SingleSnapShot.Models
{
    public class SnapshotSettings
    {
        public string Resolution { get; set; }

        public string ExportFolder { get; set; }

        public string MacroPath { get; set; }

        public string MacroName { get; set; } = "CreateSnapShotMacro.cs";
    }
}