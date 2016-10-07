using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace JicaTweet.Controllers
{
    using System.Net;
    using Data;
    using Ionic.Zip;
    using MissingFeatures;
    using Models;

    public class HomeController : Controller
    {
        JicaTweetData data = new JicaTweetData();
        private const string SubmissionFileName = "Submission";

        public HomeController()
        {
            this.WorkingDirectory = @"C:\Users\Maika\Documents\Programming\uploads\";
        }

        public string WorkingDirectory { get; set; }

        public string JsProjectFilePathsConcatenated { get; set; }

        public ActionResult Tweets()
        {
            var tweets = this.data.Tweets.All();
            return this.View(tweets.AsEnumerable());
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            string submissionFilePath = $"{this.WorkingDirectory}\\{SubmissionFileName}";

            byte[] submissionContent = file.InputStream.ToByteArray();
            System.IO.File.WriteAllBytes(submissionFilePath, submissionContent);


            AddSandboxExecutorSourceFileToSubmissionZip(submissionFilePath);

            UnzipFile(submissionFilePath, this.WorkingDirectory);

            this.JsProjectFilePathsConcatenated = ExtractAllFileNamesFromUnzippedSubmission();
           
            return this.View();
        }

        private void AddSandboxExecutorSourceFileToSubmissionZip(string submissionZipFilePath)
        {

            using (var zipFile = new ZipFile(submissionZipFilePath))
            {
                zipFile.Save();
            }
        }
        private static void UnzipFile(string fileToUnzip, string outputDirectory)
        {
            using (var zipFile = ZipFile.Read(fileToUnzip))
            {
                foreach (var entry in zipFile)
                {
                    entry.Extract(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            System.IO.File.Delete(fileToUnzip);
        }
        private string ExtractAllFileNamesFromUnzippedSubmission()
        {
            var files = new List<string>(Directory.GetFiles(this.WorkingDirectory, "*", SearchOption.AllDirectories));
            foreach (var file in files)
            {
                this.JsProjectFilePathsConcatenated = file + ";";
            }
            return null;
        }
    }
}