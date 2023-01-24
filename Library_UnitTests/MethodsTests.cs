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
        string[] proof = new string[] { testDir + "/Foo/Definition.txt", testDir + "/Bar/Definition.txt" };

        var test = SUT.Methods.GetCatalog(testDir);

        Assert.IsTrue(test.Files.Count() == 0);
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
        string Foo = "Foo";
        string Bar = "Bar";

        var proof = new Dictionary<string, string>()
        {
            {Foo, "/TestSource/Foo" },
            {Bar, "/TestSource/Bar" }
        };

        var test = new Dictionary<string, string>();

        SUT.Methods.MapKeyword(testDir, "/TestSource", ref test);

        Assert.AreEqual(proof[Foo], test[Foo]);
        Assert.AreEqual(proof[Bar], test[Bar]);
    }
}