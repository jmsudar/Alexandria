using System;
using Alexandria.Library.Object;

namespace Alexandria.Library.Interface
{
	public interface IDirectoryIterator
	{
		string DirectoryRoot { get; set; }
	}

	public interface ICatalog
	{
		string SourcePath { get; set; }
		Dictionary<string, List<string>> MappingCollection { get; set; }
	}

	public interface ICatalogTraversal
	{
		List<string> Files { get; set; }
		List<string> Directories { get; set; }
	}
}