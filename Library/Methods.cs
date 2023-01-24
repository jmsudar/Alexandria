using System;
using System.IO;
using Alexandria.Library.Object;

namespace Alexandria.Library.Methods
{
	public static class Methods
	{
		public static Catalog GetCatalog(string FilePath) => new Catalog(System.IO.Directory.GetDirectories(FilePath), System.IO.Directory.GetFiles(FilePath));

		public static string PathBuilder(string root, string nextHop, string platform) => root + Constants.pathSeparators[platform] + nextHop;

		public static string BuildWebPath(string root, string nextHop) => PathBuilder(root, nextHop, "web");

		public static void MapKeyword(string filePath, string root, ref Dictionary<string,string> MappingCollection)
		{
			var listing = GetCatalog(filePath);

			foreach (var directory in listing.Directories)
			{
				var nextFolder = GetNextFolder(directory);

				MappingCollection.Add(nextFolder, PathBuilder(root, nextFolder, GetOSSeparator()));
            }
        }

		public static string GetNextFolder(string filePath) => new DirectoryInfo(filePath).Name;

        //TODO: build this out to not just return Unix
        public static string GetOSSeparator() => "unix";
	}
}

