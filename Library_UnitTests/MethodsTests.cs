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
}