using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using Alexandria.Library.Object;

namespace Alexandria.Library.Methods
{
	public static class Methods
	{
        #region Catalog

        /// <summary>
        /// Build Catalog object from directories and files at source path
        /// </summary>
        /// <param name="sourcePath">The source path for your Catalog</param>
        /// <returns>A modeled Catalog object of directories and files</returns>
        public static Catalog BuildCatalog(string sourcePath)
		{
			var mappingCollection = new Dictionary<string, List<string>>();

			MapKeyword(sourcePath, string.Empty, ref mappingCollection);

			return new Catalog(sourcePath, mappingCollection);
		}

        /// <summary>
        /// Build CatalogTraversal object from a given file path
        /// </summary>
        /// <param name="filePath">The file path you are attempting to traverse</param>
        /// <returns>A modeled CatalogTraversal object from the file path</returns>
        public static CatalogTraversal BuildCatalogTraversal(string filePath) => new CatalogTraversal(System.IO.Directory.GetDirectories(filePath),
			System.IO.Directory.GetFiles(filePath).Select(file => Path.GetFileName(file)).ToArray());

        /// <summary>
        /// Add any relative paths and lists of files at said paths to a Catalog's MappingCollection dictionary
        /// </summary>
        /// <param name="filePath">The file path being traversed creating the association</param>
        /// <param name="root">The relative file path up to this point</param>
        /// <param name="MappingCollection">The Catalot's referenced MappingCollection dictionary</param>
        public static void MapKeyword(string filePath, string root, ref Dictionary<string, List<string>> MappingCollection)
        {
            var listing = BuildCatalogTraversal(filePath);

            var nextHop = PathBuilder(root, GetDirectoryName(filePath), GetOSSeparator());

            MappingCollection.Add(nextHop, listing.Files);

            foreach (var directory in listing.Directories)
            {
                MapKeyword(directory, nextHop, ref MappingCollection);
            }
        }

        #endregion

        #region Output

        /// <summary>
        /// Outputs Library content to a given destination
        /// </summary>
        /// <param name="destination">The destination target</param>
        /// <param name="content">The content being sent to the destination</param>
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

        /// <summary>
        /// Determine the type of a given destination
        /// </summary>
        /// <param name="destination">The destination being determined</param>
        /// <returns>A valid destination as determined in Constants.FileTypes</returns>
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

        /// <summary>
        /// Build a path from the root, next hop, and platform
        /// </summary>
        /// <param name="root">The root being built on</param>
        /// <param name="nextHop">The next hop in the path</param>
        /// <param name="platform">The platform being built for</param>
        /// <returns>The assembled path</returns>
        public static string PathBuilder(string root, string nextHop, string platform) => root + Constants.PathSeparators[platform] + nextHop;

        /// <summary>
        /// Dedicated method to build a web path
        /// </summary>
        /// <param name="root">The root being built on</param>
        /// <param name="nextHop">The next hop in the path</param>
        /// <returns>The assembled path</returns>
        public static string BuildWebPath(string root, string nextHop) => PathBuilder(root, nextHop, "web");

        /// <summary>
        /// Gets the name of a current directory
        /// </summary>
        /// <param name="filePath">The file path for which you need the directory name</param>
        /// <returns>The directory name</returns>
        public static string GetDirectoryName(string filePath) => new DirectoryInfo(filePath).Name;

        /// <summary>
        /// Gets the OS separator for the current system
        /// </summary>
        /// <returns>The system type, for mapping the OS separator</returns>
        public static string GetOSSeparator() => (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
            | RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
            | RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD)) ? "unix" : "windows";

        #endregion
	}
}

