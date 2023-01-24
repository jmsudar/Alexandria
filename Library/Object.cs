using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alexandria.Library.Interface;

namespace Alexandria.Library.Object
{
	[Serializable]
	public class DirectoryIterator : IDirectoryIterator
    {
        public string DirectoryRoot { get; set; }
    }

    [Serializable]
    public class Catalog : ICatalog
    {
        public Catalog(string[] directories, string[] files)
        {
            Directories = files == null ? new List<string>() : new List<string>(directories);
            Files = files == null ? new List<string>() : new List<string>(files);
        }

        public List<string> Directories { get; set; }
        public List<string> Files { get; set; }
    }

    public class Constants
    {
        public static Dictionary<string, string> pathSeparators = new Dictionary<string, string>()
        {
            { "web", "/" },
            { "unix", "/"}
        };
    }
}

