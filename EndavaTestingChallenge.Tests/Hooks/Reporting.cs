using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using EndavaTestingChallenge.Tests.FilesFacades;
using TechTalk.SpecFlow.Bindings;

namespace EndavaTestingChallenge.Tests.Hooks
{
    public class Reporting : StepDefinitions.Steps
    {
        private const string ReportName = "Reports\\report.html";

        public Reporting(ExtentReports extentReports) : base(extentReports) { }

        private static ExtentTest Feature { get; set; }

        private static ExtentTest Scenario { get; set; }

        private static ExtentTest Step { get; set; }

        [BeforeTestRun]
        public static void Init()
        {
            var path = FileManager.GetFilePathFromBaseDirectory(ReportName);
            var htmlReporter = new ExtentHtmlReporter(path);
            ExtentReport = new ExtentReports();
            ExtentReport.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void ReportFeatureStart()
        {
            var featureName = FeatureContext.Current.FeatureInfo.Description;
            Feature = ExtentReport.CreateTest<Feature>(featureName);
        }

        [BeforeScenario]
        public static void ReportScenarioStart()
        {
            var scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
            Scenario = Feature.CreateNode<Scenario>(scenarioName);
        }

        [BeforeStep]
        public static void ReportStepStart()
        {
            var stepName = ScenarioStepContext.Current.StepInfo.Text;
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType;
            switch (stepType)
            {
                case StepDefinitionType.Given: Step = Scenario.CreateNode<Given>(stepName); break;
                case StepDefinitionType.When: Step = Scenario.CreateNode<When>(stepName); break;
                case StepDefinitionType.Then: Step = Scenario.CreateNode<Then>(stepName); break;
            }

        }

        [AfterTestRun]
        public static void CrateReport()
        {
            ExtentReport.Flush();
        }
    }
}
