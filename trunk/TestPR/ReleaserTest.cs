using Jeebook.PageReleaser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestPR
{
    /// <summary>
    ///This is a test class for ReleaserTest and is intended
    ///to contain all ReleaserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ReleaserTest
    {
        private TestContext testContextInstance;

        private void SetPath( SettingManager sm, string strFunctionName)
        {
            UriResolver uiRes = new UriResolver(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, true);
            sm.PageName = uiRes.ToAbsolute("Website\\index.html");
            sm.OutputPath = uiRes.ToAbsolute("Result\\" + strFunctionName + "\\");
        }

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
        ///A test for Release
        ///</summary>
        [TestMethod()]
        public void ReleaseAllTrueTest()
        {
            Releaser target = new Releaser(); // TODO: Initialize to an appropriate value
            SettingManager sm = new SettingManager(); ; // TODO: Initialize to an appropriate value
            SetPath(sm, "ReleaseAllTrueTest");

            sm.IsHtmlCompress = true;
            sm.IsHtmlGZip = true;

            sm.IsJavaScriptCompress = true;
            sm.IsJavaScriptCombine = true;
            sm.IsJavaScriptEmbed = true;
 //           sm.IsJavaScriptGZip = true;

            sm.IsCssCompress = true;
            sm.IsCssCombine = true;
            sm.IsCssEmbed = true;
 //           sm.IsCssGZip = true;
            
 //           sm.IsImageCombine = true;

            sm.IgnoreRemoteFile = true;
            sm.IgnoreParentFolder = true;

            target.Release(sm);

            FileValidator fv = new FileValidator(sm.OutputPath, true);
            fv.Add("index.html", true);
 //           fv.Add("image/loading.gif", true);
            fv.Add("images\\logo.png", true);

            Assert.IsTrue(fv.Validate());
        }

        [TestMethod()]
        public void ReleaseAllFalseTest()
        {
            //
            Releaser target = new Releaser(); 
            SettingManager sm = new SettingManager(); 
            SetPath(sm, "ReleaseAllFalseTest");

            sm.IsHtmlCompress = false;
  //          sm.IsHtmlGZip = false;

            sm.IsJavaScriptCompress = false;
            sm.IsJavaScriptCombine = false;
            sm.IsJavaScriptEmbed = false;
  //          sm.IsJavaScriptGZip = false;

            sm.IsCssCompress = false;
            sm.IsCssCombine = false;
            sm.IsCssEmbed = false;
  //          sm.IsCssGZip = false;

 //           sm.IsImageCombine = false;

            sm.IgnoreRemoteFile = false;
            sm.IgnoreParentFolder = false;

            //
            target.Release(sm);

            //
            FileValidator fv = new FileValidator(sm.OutputPath, true);
            fv.Add("index.html", true);
            // fv.Add("image/loading.gif", true);
            fv.Add("images\\logo.png", true);
            fv.Add("js\\test.js", true);
            fv.Add("css\\test.css", true); 
            Assert.IsTrue(fv.Validate());
        }

        [TestMethod()]
        public void ReleaseDefaultTest()
        {
            //
            Releaser target = new Releaser(); 
            SettingManager sm = new SettingManager(); 
            SetPath(sm, "ReleaseDefaultTest");

            sm.IsHtmlCompress = true;
            sm.IsHtmlGZip = false;

            sm.IsJavaScriptCompress = true;
            sm.IsJavaScriptCombine = true;
            sm.IsJavaScriptEmbed = false;
            sm.IsJavaScriptGZip = false;

            sm.IsCssCompress = true;
            sm.IsCssCombine = true;
            sm.IsCssEmbed = false;
            sm.IsCssGZip = false;

            sm.IsImageCombine = true;

            sm.IgnoreRemoteFile = true;
            sm.IgnoreParentFolder = true;

            //
            target.Release(sm);

            //
            FileValidator fv = new FileValidator(sm.OutputPath, true);
            fv.Add("index.html", true);
            // fv.Add("image/loading.gif", true);
            fv.Add("images\\logo.png", true);
            fv.Add("js\\test.js", true);
            fv.Add("css\\test.css", true); 
            Assert.IsTrue(fv.Validate());
        }
    }
}
