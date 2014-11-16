using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTestAssistantCore
{
    public class XmlParser
    {
        public static string ParseStringToXml(string textForParse)
        {
            StringBuilder escapedText = new StringBuilder(textForParse.Length);
            foreach (char currentChar in textForParse)
            {
                if(currentChar == '<')
                {
                    escapedText.Append("&lt;");
                }
                else if (currentChar == '>')
                {
                    escapedText.Append("&gt;");
                }
                else if (currentChar == '&')
                {
                    escapedText.Append("&amp;");
                }
                else if (currentChar == '\'')
                {
                    escapedText.Append("&apos;");
                }
                else if (currentChar == '"')
                {
                    escapedText.Append("&quot;");
                }                    
                else
                {
                    escapedText.Append(currentChar);
                }
            }

            return escapedText.ToString();
        }
    }
}
