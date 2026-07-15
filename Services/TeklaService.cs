using System;
using System.IO;
using System.Linq;
using Tekla.Structures.Model;

namespace PhaseSnapshotCreator.Services
{
    public static class TeklaService
    {
        private const string ExportFolderName = "PhaseSnapshots";
        private const string FilerNamePrefix = "SnapshotCreatorTempFilter";
        private const string MacroName = "CreateSnapShotMacro.cs";
        public static string ExportFolderPath { get; private set; }
        public static string MacroPath { get; private set; }
        public static string FilterName { get; private set; }
        public static string ModelPath { get; private set; }

        public static void Initialise()
        {
            var modelPath = GetModelPath();
            var userInitials = GetUserInitials();
            var macroDirectory = GetUserMacroDirectory();

            ExportFolderPath = Path.Combine(modelPath, ExportFolderName, userInitials);
            FilterName = FilerNamePrefix + userInitials;
            Directory.CreateDirectory(ExportFolderPath);
            MacroPath = Path.Combine(macroDirectory, MacroName);
            ModelPath = GetModelPath();
        }

        private static string GetModelPath()
        {
            var model = new Model();
            return !model.GetConnectionStatus() ? throw new Exception("Tekla Structures is not running or a model is not connected.") : model.GetInfo().ModelPath;
        }

        private static string GetUserMacroDirectory()
        {
            var macroDirectories = string.Empty;

            var success = Tekla.Structures.TeklaStructuresSettings.GetAdvancedOption("XS_MACRO_DIRECTORY", ref macroDirectories);

            if (!success)
            {
                throw new Exception("Unable to determine the Tekla macro directory.");
            }

            var userMacroDirectory = macroDirectories.Split(';').FirstOrDefault(x => x.IndexOf("user-macros", StringComparison.OrdinalIgnoreCase) >= 0);

            return userMacroDirectory == null ? throw new Exception("Tekla user macro directory not found.") : userMacroDirectory.Trim();
        }

        private static string GetUserInitials()
        {
            return string.Concat(Environment.UserName.Split('.', '_', '-').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x[0])).ToUpper();
        }
    }
}