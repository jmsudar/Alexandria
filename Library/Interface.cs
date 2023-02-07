using System;
using Alexandria.Library.Object;

namespace Alexandria.Library.Interface
{
    #region Configuration

	/// <summary>
	/// Interface for DirectoryIterator
	/// </summary>
    public interface IDirectoryIterator
	{
		string DirectoryRoot { get; set; }
	}

    #endregion

    #region Book

	/// <summary>
	/// Interface for Book object
	/// </summary>
    public interface IBook
	{
		string Title { get; set; }
		string Forward { get; set; }
		string[] Text { get; set; }
	}

    #endregion

    #region Catalog

	/// <summary>
	/// Interface for Catalog object
	/// </summary>
    public interface ICatalog
	{
		string SourcePath { get; set; }
		Dictionary<string, List<string>> MappingCollection { get; set; }
	}

	/// <summary>
	/// Interface for CatalogTraversal object
	/// </summary>
    public interface ICatalogTraversal
	{
		List<string> Files { get; set; }
		List<string> Directories { get; set; }
	}

    #endregion
}