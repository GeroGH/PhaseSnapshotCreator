using System;
using System.IO;
using System.Linq;
using Tekla.Structures.Model;

namespace PhaseSnapshotCreator.Services
{
    public static class TeklaService
    {
        private const string ExportFolderName = "PhaseSnapshots";
        private const string FilterNamePrefix = "PhaseSnapshotFilter";
        private const string MacroName = "CreateSnapShotMacro.cs";

        public static Model Model { get; private set; }

        public static string ModelPath { get; private set; }

        public static string ExportFolderPath { get; private set; }

        public static string MacroPath { get; private set; }

        public static string FilterName { get; private set; }

        public static string UserInitials { get; private set; }

        public static void Initialise()
        {
            ConnectToModel();

            UserInitials = GetUserInitials();

            ModelPath = Model.GetInfo().ModelPath;

            CreateNewSnapshotSession();

            FilterName = FilterNamePrefix + UserInitials;

            MacroPath = Path.Combine(GetUserMacroDirectory(), MacroName);
        }
        public static void CreateNewSnapshotSession()
        {
            var sessionName = "Export " + DateTime.Now.ToString("yyyyMMdd-HHmmss");
            ExportFolderPath = Path.Combine(ModelPath, ExportFolderName, UserInitials, sessionName);
        }
        private static void ConnectToModel()
        {
            Model = new Model();

            if (!Model.GetConnectionStatus())
            {
                throw new Exception("Tekla Structures is not running or no model is open.");
            }

            ModelPath = Model.GetInfo().ModelPath;
        }

        private static string GetUserMacroDirectory()
        {
            var macroDirectories = string.Empty;

            var success = Tekla.Structures.TeklaStructuresSettings.GetAdvancedOption("XS_MACRO_DIRECTORY", ref macroDirectories);

            if (!success)
            {
                throw new Exception("Unable to determine the Tekla macro directory.");
            }

            var directory = macroDirectories.Split(';').Select(x => x.Trim()).FirstOrDefault(x => x.IndexOf("user-macros", StringComparison.OrdinalIgnoreCase) >= 0);

            return directory == null ? throw new Exception("Tekla user macro directory could not be found.") : directory;
        }

        private static string GetUserInitials()
        {
            return string.Concat(Environment.UserName.Split('.', '_', '-').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x[0])).ToUpper();
        }
    }
}