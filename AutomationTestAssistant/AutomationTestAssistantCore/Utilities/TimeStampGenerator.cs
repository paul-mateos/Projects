using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace AutomationTestAssistantCore
{
    public class TimeStampGenerator
    {
        private CultureInfo ci = CultureInfo.InvariantCulture;

        public string Generate()
        {
            return DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss");
        }

        public string GenerateTrxFilePath(string workingDir)
        {
            string tempFolder = Path.GetTempPath();
            string fileName = String.Concat(ATACore.Utilities.TimeStampGenerator.Generate(), ".trx");
            string uniqueTestResultName = Path.Combine(workingDir, "results", fileName);

            return uniqueTestResultName;
        }
    }
}
