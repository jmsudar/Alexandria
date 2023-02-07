using System.Collections.Generic;
using Alexandria.Library.Object;
using SUT = Alexandria.Library.Methods;

namespace Library_UnitTests;

[TestClass]
public class MethodsTests
{
    /// <summary>
    /// The path to the test directory on your development machine
    /// </summary>
    string? testDir;

    /// <summary>
    /// Initializes the test by getting the source path for the test directory
    /// </summary>
    [TestInitialize]
    public void Initialize()
    {
        this.testDir = Environment.GetEnvironmentVariable("ALX_TESTDIR") + "TestSource";
        
    }

    /// <summary>
    /// Tests Catalog method to get a directory list at a given path
    /// </summary>
    [TestMethod]
    public void TestGetCatalog_DirectoryList()
    {
        string[] proof = new string[] { testDir + "/Foo", testDir + "/Bar" };

        var test = SUT.Methods.BuildCatalogTraversal(testDir);

        Assert.AreEqual(proof[0], test.Directories[0]);
        Assert.AreEqual(proof[1], test.Directories[1]);
    }

    /// <summary>
    /// Tests Catalog method to get a file list at a given path
    /// </summary>
    [TestMethod]
    public void TestGetCatalog_FileList()
    {
        var test = SUT.Methods.BuildCatalogTraversal(testDir);

        Assert.IsTrue(test.Files.Count() == 1);
    }

    /// <summary>
    /// Tests Path Builder method to create a relative path
    /// </summary>
    [TestMethod]
    public void TestPathBuilder_BasicAsssembly()
    {
        string proof = "home/page";

        var test = SUT.Methods.PathBuilder("home", "page", "web");

        Assert.AreEqual(proof, test);
    }

    /// <summary>
    /// Tests Web specific Path Builder method
    /// </summary>
    [TestMethod]
    public void TestPathBuilder_WebPath()
    {
        string proof = "home/page";

        var test = SUT.Methods.BuildWebPath("home", "page");

        Assert.AreEqual(proof, test);
    }

    /// <summary>
    /// Tests method to get directory name in a Catalog
    /// </summary>
    [TestMethod]
    public void TestGetNextFolder_RetrieveDirectoryNameFromTestDir()
    {
        string proof = "TestSource";

        var test = SUT.Methods.GetDirectoryName(testDir);

        Assert.AreEqual(proof, test);
    }

    /// <summary>
    /// Tests method to map relative path to file list 
    /// </summary>
    [TestMethod]
    public void TestMapKeyword_GetListingInTestDir()
    {
        string Foo = "/TestSource/Foo";
        string Bar = "/TestSource/Bar";

        var proof = new Dictionary<string, List<string>>()
        {
            {Foo, new List<string>() { "Definition.txt" } },
            {Bar, new List<string>() { "Definition.txt" } }
        };

        var test = new Dictionary<string, List<string>>();

        SUT.Methods.MapKeyword(testDir + "/Foo", "/TestSource", ref test);
        SUT.Methods.MapKeyword(testDir + "/Bar", "/TestSource", ref test);

        Assert.AreEqual(proof[Foo].Count(), test[Foo].Count());
        Assert.AreEqual(proof[Bar].Count(), test[Bar].Count());
    }

    /// <summary>
    /// Test method to build a collection of relative paths and files found at said path
    /// </summary>
    [TestMethod]
    public void TestBuildCatalog_BuildTestSourceCatalog()
    {
        string Foo = "/TestSource/Foo";
        string Bar = "/TestSource/Bar";
        string HelloWorld = "/TestSource/Bar/HelloWorld";

        var proofMapping = new Dictionary<string, List<string>>()
        {
            {Foo, new List<string>() { "Definition.txt" } },
            {Bar, new List<string>() { "Definition.txt" } },
            {HelloWorld, new List<string>() { "Definition.txt" } }
        };

        var proof = new Catalog(testDir, proofMapping);

        var test = SUT.Methods.BuildCatalog(testDir);

        Assert.AreEqual(proof.SourcePath, test.SourcePath);
        Assert.AreEqual(proof.MappingCollection[Foo].Count(), test.MappingCollection[Foo].Count());
        Assert.AreEqual(proof.MappingCollection[Bar].Count(), test.MappingCollection[Bar].Count());
        Assert.AreEqual(proof.MappingCollection[HelloWorld].Count(), test.MappingCollection[HelloWorld].Count());
    }

    /// <summary>
    /// Test method to determine if a destination is a valid http address
    /// </summary>
    [TestMethod]
    public void TestGetDestinationType_ValidHTTP()
    {
        string destination = "http://example.com/file.html";

        var proof = "web";

        Assert.AreEqual(proof, SUT.Methods.GetDestinationType(destination));
    }

    /// <summary>
    /// Test method to determine if a destination is a valid https address
    /// </summary>
    [TestMethod]
    public void TestGetDestinationType_ValidHTTPS()
    {
        string destination = "https://example.com/file.html";

        var proof = "web";

        Assert.AreEqual(proof, SUT.Methods.GetDestinationType(destination));
    }

    /// <summary>
    /// Test method to determine if a destionation is a valid Unix-style filepath
    /// </summary>
    [TestMethod]
    public void TestGetDestinationType_ValidUnixfile()
    {
        string destination = "/Users/user/output/file.html";

        var proof = "file";

        Assert.AreEqual(proof, SUT.Methods.GetDestinationType(destination));
    }
}