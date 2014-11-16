using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace BulgarianToEnglishTranslator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string currentRichTextBoxText = this.StringFromRichTextBox(rbTextToTranslate);
            StringBuilder sb = new StringBuilder(currentRichTextBoxText.Length * 2);
            currentRichTextBoxText = currentRichTextBoxText.Replace("улица", "street");
            currentRichTextBoxText = currentRichTextBoxText.Replace("България", "Bulgaria");
            currentRichTextBoxText = currentRichTextBoxText.Replace("я ", "ia ");
            currentRichTextBoxText = currentRichTextBoxText.Replace("я\r\n", "ia\r\n");
            currentRichTextBoxText =  currentRichTextBoxText.Replace("иi", "i");
            foreach (char currentChar in currentRichTextBoxText)
            {
                switch (currentChar)
                {
                    default:
                        sb.Append(currentChar);
                        break;
                    case 'А':
                        sb.Append('A');
                        break;
                    case 'Б':
                        sb.Append('B');
                        break;
                    case 'В':
                        sb.Append('V');
                        break;
                    case 'Г':
                        sb.Append('G');
                        break;
                    case 'Д':
                        sb.Append('D');
                        break;
                    case 'Е':
                        sb.Append('E');
                        break;
                    case 'Ж':
                        sb.Append("Zh");
                        break;
                    case 'З':
                        sb.Append('Z');
                        break;
                    case 'И':
                        sb.Append('I');
                        break;
                    case 'Й':
                        sb.Append('Y');
                        break;
                    case 'К':
                        sb.Append('K');
                        break;
                    case 'Л':
                        sb.Append('L');
                        break;
                    case 'М':
                        sb.Append('M');
                        break;
                    case 'Н':
                        sb.Append('N');
                        break;
                    case 'О':
                        sb.Append('O');
                        break;
                    case 'П':
                        sb.Append('P');
                        break;
                    case 'Р':
                        sb.Append('R');
                        break;
                    case 'С':
                        sb.Append('S');
                        break;
                    case 'Т':
                        sb.Append('T');
                        break;
                    case 'У':
                        sb.Append('U');
                        break;
                    case 'Ф':
                        sb.Append('F');
                        break;
                    case 'Х':
                        sb.Append('H');
                        break;
                    case 'Ц':
                        sb.Append("Tz");
                        break;
                    case 'Ч':
                        sb.Append("Ch");
                        break;
                    case 'Ш':
                        sb.Append("Sh");
                        break;
                    case 'Щ':
                        sb.Append("Sht");
                        break;
                    case 'Ъ':
                        sb.Append('A');
                        break;
                    case 'Ь':
                        sb.Append('Y');
                        break;
                    case 'Ю':
                        sb.Append("Yu");
                        break;
                    case 'Я':
                        sb.Append("Ya");
                        break;
                    case 'а':
                        sb.Append("a");
                        break;
                    case 'б':
                        sb.Append('b');
                        break;
                    case 'в':
                        sb.Append('v');
                        break;
                    case 'г':
                        sb.Append('g');
                        break;
                    case 'д':
                        sb.Append('d');
                        break;
                    case 'е':
                        sb.Append('e');
                        break;
                    case 'ж':
                        sb.Append("zh");
                        break;
                    case 'з':
                        sb.Append('z');
                        break;
                    case 'и':
                        sb.Append('i');
                        break;
                    case 'й':
                        sb.Append('y');
                        break;
                    case 'к':
                        sb.Append('k');
                        break;
                    case 'л':
                        sb.Append('l');
                        break;
                    case 'м':
                        sb.Append('m');
                        break;
                    case 'н':
                        sb.Append('n');
                        break;
                    case 'о':
                        sb.Append('o');
                        break;
                    case 'п':
                        sb.Append('p');
                        break;
                    case 'р':
                        sb.Append('r');
                        break;
                    case 'с':
                        sb.Append('s');
                        break;
                    case 'т':
                        sb.Append('t');
                        break;
                    case 'у':
                        sb.Append('u');
                        break;
                    case 'ф':
                        sb.Append('f');
                        break;
                    case 'х':
                        sb.Append('h');
                        break;
                    case 'ц':
                        sb.Append("tz");
                        break;
                    case 'ч':
                        sb.Append("ch");
                        break;
                    case 'ш':
                        sb.Append("sh");
                        break;
                    case 'щ':
                        sb.Append("sht");
                        break;
                    case 'ь':
                        sb.Append('y');
                        break;
                    case 'ъ':
                        sb.Append('a');
                        break;
                    case 'ю':
                        sb.Append("yu");
                        break;
                    case 'я':
                        sb.Append("ya");
                        break;
                }
            }
            Clipboard.SetText(sb.ToString());
            sb.Clear();
        }

        private string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd);

            // The Text property on a TextRange object returns a string 
            // representing the plain text content of the TextRange. 
            return textRange.Text;
        }
    }
}