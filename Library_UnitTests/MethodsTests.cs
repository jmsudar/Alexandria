using System.Collections.Generic;
using Alexandria.Library.Object;
using SUT = Alexandria.Library.Methods;

namespace Library_UnitTests;

[TestClass]
public class MethodsTests
{
    string testDir;

    [TestInitialize]
    public void Initialize()
    {
        this.testDir = Environment.GetEnvironmentVariable("ALX_TESTDIR") + "TestSource";
        
    }

    [TestMethod]
    public void TestGetCatalog_DirectoryList()
    {
        string[] proof = new string[] { testDir + "/Foo", testDir + "/Bar" };

        var test = SUT.Methods.GetCatalog(testDir);

        Assert.AreEqual(proof[0], test.Directories[0]);
        Assert.AreEqual(proof[1], test.Directories[1]);
    }

    [TestMethod]
    public void TestGetCatalog_FileList()
    {
        var test = SUT.Methods.GetCatalog(testDir);

        Assert.IsTrue(test.Files.Count() == 1);
    }

    [TestMethod]
    public void TestPathBuilder_BasicAsssembly()
    {
        string proof = "home/page";

        var test = SUT.Methods.PathBuilder("home", "page", "web");

        Assert.AreEqual(proof, test);
    }

    [TestMethod]
    public void TestPathBuilder_WebPath()
    {
        string proof = "home/page";

        var test = SUT.Methods.BuildWebPath("home", "page");

        Assert.AreEqual(proof, test);
    }

    [TestMethod]
    public void TestGetNextFolder_RetrieveNextFolderFromTestDir()
    {
        string proof = "TestSource";

        var test = SUT.Methods.GetNextFolder(testDir);

        Assert.AreEqual(proof, test);
    }

    [TestMethod]
    public void TestMapKeyword_GetListingInTestDir()
    {
        string Foo = "/TestSource/Foo";
        string Bar = "/TestSource/Bar";

        var proof = new Dictionary<string, List<string>>()
        {
            {Foo, new List<string>() { testDir + Foo + "/Definition.txt" } },
            {Bar, new List<string>() { testDir + Bar + "/Definition.txt" } }
        };

        var test = new Dictionary<string, List<string>>();

        SUT.Methods.MapKeyword(testDir + "/Foo", "/TestSource", ref test);
        SUT.Methods.MapKeyword(testDir + "/Bar", "/TestSource", ref test);

        Assert.AreEqual(proof[Foo].Count(), test[Foo].Count());
        Assert.AreEqual(proof[Bar].Count(), test[Bar].Count());
    }

    [TestMethod]
    public void TestBuildCatalog_BuildTestSourceCatalog()
    {
        string Foo = "/TestSource/Foo";
        string Bar = "/TestSource/Bar";
        string HelloWorld = "/TestSource/Bar/HelloWorld";

        var proofMapping = new Dictionary<string, List<string>>()
        {
            {Foo, new List<string>() { testDir + Foo + "/Definition.txt" } },
            {Bar, new List<string>() { testDir + Bar + "/Definition.txt" } },
            {HelloWorld, new List<string>() { testDir + HelloWorld + "/Definition.txt" } }
        };

        var proof = new Catalog(testDir, proofMapping);

        var test = SUT.Methods.BuildCatalog(testDir);

        Assert.AreEqual(proof.SourcePath, test.SourcePath);
        Assert.AreEqual(proof.MappingCollection[Foo].Count(), test.MappingCollection[Foo].Count());
        Assert.AreEqual(proof.MappingCollection[Bar].Count(), test.MappingCollection[Bar].Count());
        Assert.AreEqual(proof.MappingCollection[HelloWorld].Count(), test.MappingCollection[HelloWorld].Count());
    }
}