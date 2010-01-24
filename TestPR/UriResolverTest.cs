using Jeebook.PageReleaser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestPR
{
    
    
    /// <summary>
    ///This is a test class for UriResolverTest and is intended
    ///to contain all UriResolverTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UriResolverTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ToRelative
        ///</summary>
        [TestMethod()]
        public void ToRelativeTest()
        {
            string uri = string.Empty; // TODO: Initialize to an appropriate value
            bool bFolder = false; // TODO: Initialize to an appropriate value
            UriResolver target = new UriResolver(uri, bFolder); // TODO: Initialize to an appropriate value
            string absoluteUri = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToRelative(absoluteUri);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToAbsolute
        ///</summary>
        [TestMethod()]
        public void ToAbsoluteTest()
        {
            string uri = string.Empty; // TODO: Initialize to an appropriate value
            bool bFolder = false; // TODO: Initialize to an appropriate value
            UriResolver target = new UriResolver(uri, bFolder); // TODO: Initialize to an appropriate value
            string relativeUri = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToAbsolute(relativeUri);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
