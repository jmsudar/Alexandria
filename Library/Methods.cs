using System;
using Alexandria.Library.Object;

namespace Alexandria.Library.Methods
{
	public static class Methods
	{
		public static Catalog GetCatalog(string FilePath) => new Catalog(System.IO.Directory.GetDirectories(FilePath), System.IO.Directory.GetFiles(FilePath));

		public static string PathBuilder(string root, string nextHop, string platform) => root + Constants.pathSeparators[platform] + nextHop;

		public static string BuildWebPath(string root, string nextHop) => PathBuilder(root, nextHop, "web");
	}
}

