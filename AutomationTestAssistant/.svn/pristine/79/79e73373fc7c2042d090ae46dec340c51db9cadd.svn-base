using System;

namespace AutomationTestAssistantCore
{
    public class ConfigWriterSettings
    {
        public String AppSettingsNode { get; set; }
        public String NodeForEdit { get; set; }
        public string ConfigPath { get; set; }    
    
        public ConfigWriterSettings(String appSettingsNode, String nodeForEdit, string configPath)
        {
            this.AppSettingsNode = appSettingsNode;
            this.NodeForEdit = nodeForEdit;
            this.ConfigPath = configPath;
        }

        public ConfigWriterSettings(String appSettingsNode, string configPath)
        {
            this.AppSettingsNode = appSettingsNode;
            this.ConfigPath = configPath;
        }

        public ConfigWriterSettings(string configPath)
        {
            this.ConfigPath = configPath;
            this.AppSettingsNode = "//GoogleAnalyticsReportGenerator.ReportGeneratorSettings";
            this.NodeForEdit = "//setting[@name='{0}']";
        }

        
    }
}