using System;
using System.IO;
using System.Reflection;

namespace Evolve2016Twitter.UITest
{
    /// <summary>
    /// Main configuration file for local UI testing. This implementation should cover most cases. 
    /// 
    /// More advance usage scenarios might include multiple configurations for
    /// multiple conditional app builds (e.g., one for TEST env, another for QA, etc...).
    /// </summary>
    internal class MainLocalConfiguration : IUITestConfiguration
    {
        public string API_KEY => "";
        public string PathToAPK => Path.Combine(SlnPath, "Evolve2016Twitter", "android", "com.twitter.android.apk");
        public string AndroidPackageName => "com.twitter.android";

        private string _slnPath = null;
        private string SlnPath
        {
            get
            {
                if (_slnPath != null)
                    return _slnPath;

                var currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                var fi = new FileInfo(currentFile);
                _slnPath = fi.Directory.Parent.Parent.Parent.FullName;

                return _slnPath;
            }
        }
    }
}

