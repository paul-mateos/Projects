using System;
using System.Linq;
using System.Xml;
using System.Reflection;

namespace AutomationTestAssistantCore
{
    public class ConfigWriter
    { 
        public static void WriteSetting(string key, string value, ConfigWriterSettings configWriterSettings)
        {
            XmlDocument doc = ConfigWriter.LoadConfigDocument(configWriterSettings.ConfigPath);
            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode(configWriterSettings.AppSettingsNode);

            if (node == null)
                throw new InvalidOperationException("appSettings section not found in config file.");

            try
            {
                // select the 'add' element that contains the key
                XmlElement elem = (XmlElement)node.SelectSingleNode(
                    string.Format(configWriterSettings.NodeForEdit, key));
                elem.FirstChild.InnerText = value;
                doc.Save(configWriterSettings.ConfigPath);
            }
            catch
            {
                throw;
            }
        }

        public static void ChangeValueByKey(string key, string value, string attributeForChange, ConfigWriterSettings configWriterSettings)
        {
            XmlDocument doc = ConfigWriter.LoadConfigDocument(configWriterSettings.ConfigPath);
            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode(configWriterSettings.AppSettingsNode);

            if (node == null)
                throw new InvalidOperationException("appSettings section not found in config file.");

            try
            {
                // select the 'add' element that contains the key
                XmlElement elem = (XmlElement)node.SelectSingleNode(
                    string.Format(configWriterSettings.NodeForEdit, key));
                elem.SetAttribute(attributeForChange, value);
                doc.Save(configWriterSettings.ConfigPath);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static XmlDocument LoadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(GetConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }

        public static XmlDocument LoadConfigDocument(string configFilePath)
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(configFilePath);
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }

        public static string GetConfigFilePath()
        {
            return Assembly.GetExecutingAssembly().Location + ".config";
        }
    }   
}
