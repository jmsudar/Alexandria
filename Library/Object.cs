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

    public class Catalog : ICatalog
    {
        public Catalog(string sourcePath, Dictionary<string, List<string>> mappingCollection)
        {
            MappingCollection = mappingCollection == null ? new Dictionary<string, List<string>>() : new Dictionary<string, List<string>>(mappingCollection);
        }

        public string SourcePath { get; set; }
        public Dictionary<string, List<string>> MappingCollection { get; set; }
    }

    public class CatalogTraversal : ICatalogTraversal
    {
        public CatalogTraversal(string[] directories, string[] files)
        {
            Directories = files == null ? new List<string>() : new List<string>(directories);
            Files = files == null ? new List<string>() : new List<string>(files);
        }

        public List<string> Directories { get; set; }
        public List<string> Files { get; set; }
    }

    public class Constants
    {
        public static Dictionary<string, string> PathSeparators = new Dictionary<string, string>()
        {
            { "web", "/" },
            { "unix", "/"}
        };

        public static class FileTypes
        {
            public static string Web = "web";
            public static string File = "file";
        }
    }
}

