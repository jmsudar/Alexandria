using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alexandria.Library.Interface;

namespace Alexandria.Library.Object
{
    #region Configuration

    /// <summary>
    /// Serializable path to root directory of a Library
    /// </summary>
    [Serializable]
	public class DirectoryIterator : IDirectoryIterator
    {
        public string DirectoryRoot { get; set; }
    }

    #endregion

    #region Book

    /// <summary>
    /// Used to model consumed text files for use by different output models
    /// </summary>
    public class Book : IBook
    {
        /// <summary>
        /// Accepts an array of lines read from a text file and models them for later use
        /// </summary>
        /// <param name="input">The input array read from a Catalog text file</param>
        public Book(string[] input)
        {
            Title = input.Length > 0 ? input[0] : null;
            Forward = input.Length > 1 ? input[1] : null;
            Text = input.Length > 2 ? input.Skip(2).ToArray() : null;
        }

        public string? Title { get; set; }
        public string? Forward { get; set; }
        public string[]? Text { get; set; }
    }

    #endregion

    #region Catalog

    /// <summary>
    /// Correlates a source path with a dictionary of relative paths and the files at said destination
    /// </summary>
    public class Catalog : ICatalog
    {
        /// <summary>
        /// Accepts a source path and the dictionary of path/file list associations
        /// </summary>
        /// <param name="sourcePath">The root path for use as the source</param>
        /// <param name="mappingCollection">A dictionary of relative paths to a list of files at each relative path</param>
        public Catalog(string sourcePath, Dictionary<string, List<string>> mappingCollection)
        {
            MappingCollection = mappingCollection == null ? new Dictionary<string, List<string>>() : new Dictionary<string, List<string>>(mappingCollection);
        }

        public string SourcePath { get; set; }
        public Dictionary<string, List<string>> MappingCollection { get; set; }
    }

    /// <summary>
    /// The object used to recursively traverse relative collections of directories and files at the source path
    /// </summary>
    public class CatalogTraversal : ICatalogTraversal
    {
        /// <summary>
        /// Creates a collection of directories to traverse and files to note
        /// </summary>
        /// <param name="directories">The subdirectories at a given path</param>
        /// <param name="files">The files at a given path</param>
        public CatalogTraversal(string[] directories, string[] files)
        {
            Directories = files == null ? new List<string>() : new List<string>(directories);
            Files = files == null ? new List<string>() : new List<string>(files);
        }

        public List<string> Directories { get; set; }
        public List<string> Files { get; set; }
    }

    #endregion

    #region Utilities

    /// <summary>
    /// A collection of constant values for use at runtime
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Dictionary of path separators for a given file system
        /// </summary>
        public static Dictionary<string, string> PathSeparators = new Dictionary<string, string>()
        {
            { "web", "/" },
            { "unix", "/"},
            { "windows", "\\" }
        };

        /// <summary>
        /// Collection of supported file types for telling Alexandria how to output to a given destination
        /// </summary>
        public static class FileTypes
        {
            public static string Web = "web";
            public static string File = "file";
        }
    }

    #endregion
}

