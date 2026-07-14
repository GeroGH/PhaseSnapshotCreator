using System;
using System.Linq;
using Tekla.Structures.Model;

namespace SingleSnapShot.Services
{
    public class TeklaService
    {
        public string GetModelPath()
        {
            var model = new Model();
            return !model.GetConnectionStatus() ? throw new Exception("Tekla Structures is not running or model is not connected.") : model.GetInfo().ModelPath;
        }

        public string GetUserMacroDirectory()
        {
            var macroDirectories = string.Empty;

            var success = Tekla.Structures.TeklaStructuresSettings.GetAdvancedOption("XS_MACRO_DIRECTORY", ref macroDirectories);

            if (!success)
            {
                throw new Exception("Unable to determine Tekla macro directory.");
            }

            var userMacroDirectory = macroDirectories.Split(';').FirstOrDefault(x => x.Contains("user-macros"));

            return userMacroDirectory == null ? throw new Exception("Tekla user macro directory not found.") : userMacroDirectory.Trim();
        }

        public string GetUserInitials()
        {
            var userName = Environment.UserName;
            return string.Concat(userName.Split('.', '_', '-').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Substring(0, 1))).ToUpper();
        }
    }
}