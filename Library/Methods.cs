using System;
using System.IO;
using System.Reflection.Metadata;
using Alexandria.Library.Object;

namespace Alexandria.Library.Methods
{
	public static class Methods
	{
		public static Catalog BuildCatalog(string sourcePath)
		{
			var mappingCollection = new Dictionary<string, List<string>>();

			MapKeyword(sourcePath, string.Empty, ref mappingCollection);

			return new Catalog(sourcePath, mappingCollection);
		}

		public static CatalogTraversal GetCatalog(string filePath) => new CatalogTraversal(System.IO.Directory.GetDirectories(filePath), System.IO.Directory.GetFiles(filePath));

		public static void OutputContent(string destination, string content)
		{
			string destinationType = GetDestinationType(destination);

            if (destinationType.Equals(Constants.FileTypes.Web))
			{
				//TODO
			}
			else if (destinationType.Equals(Constants.FileTypes.File))
			{
				System.IO.File.WriteAllText(destination, content);
			}
		}

		public static string GetDestinationType(string destination)
		{
            if (destination.ToLower().Contains("http") | destination.ToLower().Contains("https"))
            {
				return Constants.FileTypes.Web;
            }
            else
            {
				return Constants.FileTypes.File;
            }
        }

		public static string PathBuilder(string root, string nextHop, string platform) => root + Constants.PathSeparators[platform] + nextHop;

		public static string BuildWebPath(string root, string nextHop) => PathBuilder(root, nextHop, "web");

		public static void MapKeyword(string filePath, string root, ref Dictionary<string, List<string>> MappingCollection)
		{
			var listing = GetCatalog(filePath);

			var nextHop = PathBuilder(root, GetNextFolder(filePath), GetOSSeparator());

			MappingCollection.Add(nextHop, listing.Files);

			foreach (var directory in listing.Directories)
			{
				MapKeyword(directory, nextHop, ref MappingCollection);
            }
        }

		public static string GetNextFolder(string filePath) => new DirectoryInfo(filePath).Name;

        //TODO: build this out to not just return Unix
        public static string GetOSSeparator() => "unix";
	}
}

