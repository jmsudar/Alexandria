using System;

namespace Alexandria.Library.Interface
{
	public interface IDirectoryIterator
	{
		string DirectoryRoot { get; set; }
	}

	public interface ICatalog
	{
		List<string> Files { get; set; }
		List<string> Directories { get; set; }
	}
}