using System;
using Alexandria.Library.Object;

namespace Alexandria.Library.Methods
{
	public static class Methods
	{
		public static Catalog GetCatalog(string FilePath) => new Catalog(System.IO.Directory.GetDirectories(FilePath), System.IO.Directory.GetFiles(FilePath));
	}
}

