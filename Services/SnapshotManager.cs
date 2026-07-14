using System.IO;

namespace SingleSnapShot.Services
{
    public class SnapshotManager
    {
        public string CreateExportFolder(string modelPath, string userInitials)
        {
            var folder = Path.Combine(modelPath, "PhaseSnapshots", userInitials);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            return folder;
        }

        public string CreateSnapshotFileName(string folder, string name)
        {
            return Path.Combine(folder, name);
        }
    }
}