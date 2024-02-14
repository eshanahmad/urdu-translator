using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Cloud.Translation.V2;


namespace ut
{
    public partial class Form1 : Form
    {
        String textToTranslate = "";
        String transliterated = "";

        char[] alphabet =
        {
        //    0         1         2         3
        '\u0627', '\u0628', '\u067E', '\u062A',
        //    4         5         6         7 
        '\u0679', '\u062B', '\u062C', '\u0686',
        //    8         9        10        11
        '\u062D', '\u062E', '\u062F', '\u0688',
        //   12        13        14        15
        '\u0630', '\u0631', '\u0691', '\u0632',
        //   16        17        18        19
        '\u0698', '\u0633', '\u0634', '\u0635',
        //   20        21        22        23
        '\u0636', '\u0637', '\u0638', '\u0639',
        //   24        25        26        27
        '\u063A', '\u0641', '\u0642', '\u06A9',
        //   28        29        30        31
        '\u06AF', '\u0644', '\u0645', '\u0646', 
        //   32        33        34        35
        '\u06BA', '\u0648', '\u06C1', '\u06BE',
        //   36        37        38        39
        '\u06CC', '\u06D2', '\u0626', '\u0621',
        //  40
           ' '
        };

        const int alphabetLen = 41;


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //label3.Text = "";
            textBox1.Text = "";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = TranslationClient.Create();
            var response = client.TranslateText(textToTranslate, LanguageCodes.Urdu, LanguageCodes.English);
            
            
            transliterated = transliterate(response.TranslatedText, alphabet);
            if(textBox1.Text == transliterated)
            {
                richTextBox1.Text = "Translation error.";
                richTextBox2.Text = "Translation error.";
            }
            else
            {
                richTextBox1.Text = transliterated;
                this.richTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                richTextBox2.Font = new System.Drawing.Font("Noto Nastaliq Urdu", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                richTextBox2.Text = response.TranslatedText;

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textToTranslate = textBox1.Text;
        }


        static string transliterate(string inputStr, char[] inputArray)
        {
            string transliteratedStr = "";
            char inputChar = ' ';

            // handle numbers
            for (int i = 0; i < inputStr.Length; i++)
            {
                inputChar = inputStr[i];

                if (char.IsDigit(inputChar))
                {
                    transliteratedStr += inputChar;
                    continue;
                }


                switch (inputChar)
                {
                    // ء
                    case '\u0621':
                        transliteratedStr += 'a';
                        break;
                    // ا with zabar
                    case '\u0622':
                        transliteratedStr += "aa";
                        break;
                    // ا
                    case '\u0627':
                        transliteratedStr += 'a';
                        break;
                    // ب
                    case '\u0628':
                        transliteratedStr += 'b';
                        break;
                    // ت
                    case '\u062A':
                        transliteratedStr += 't';
                        break;
                    // ث
                    case '\u062B':
                        transliteratedStr += 'ṭ';
                        break;
                    // ج
                    case '\u062C':
                        transliteratedStr += 'j';
                        break;
                    // ح
                    case '\u062D':
                        transliteratedStr += 'ḥ';
                        break;
                    // خ
                    case '\u062E':
                        transliteratedStr += "\u1E35\u1E96";
                        break;
                    // د 
                    case '\u062F':
                        transliteratedStr += 'd';
                        break;
                    // ذ
                    case '\u0630':
                        transliteratedStr += 'z';
                        break;
                    // ر
                    case '\u0631':
                        transliteratedStr += 'r';
                        break;
                    // ز
                    case '\u0632':
                        transliteratedStr += 'z';
                        break;
                    // س
                    case '\u0633':
                        transliteratedStr += 's';
                        break;
                    // ش
                    case '\u0634':
                        transliteratedStr += "sh";
                        break;
                    // ص
                    case '\u0635':
                        transliteratedStr += 'ṣ';
                        break;
                    // ض
                    case '\u0636':
                        transliteratedStr += 'ẓ';
                        break;
                    // ط
                    case '\u0637':
                        transliteratedStr += 't';
                        break;
                    // ظ
                    case '\u0638':
                        transliteratedStr += 'z';
                        break;
                    // ع
                    case '\u0639':
                        transliteratedStr += "a‘";
                        break;
                    // غ
                    case '\u063A':
                        transliteratedStr += "gh";
                        break;
                    // ف 
                    case '\u0641':
                        transliteratedStr += 'f';
                        break;
                    // ق  
                    case '\u0642':
                        transliteratedStr += 'q';
                        break;
                    // ل
                    case '\u0644':
                        transliteratedStr += 'l';
                        break;
                    // م 
                    case '\u0645':
                        transliteratedStr += 'm';
                        break;
                    // ن
                    case '\u0646':
                        transliteratedStr += 'n';
                        break;
                    // noon gunnah  
                    case '\u06BA':
                        //transliteratedStr += 'n';
                        //transliteratedStr += transliteratedStr[i-1];
                        transliteratedStr += '\u1E49';
                        break;
                    // و
                    case '\u0648':
                        //transliteratedStr += "v/w/u";
                        transliteratedStr += "w";

                        break;
                    // or return  u depending on rule
                    //                    return 'u';
                    // or return  v depending on rule
                    //                    return 'v';
                    // or return  w depending on rule
                    //                    return 'w';


                    // ٹ
                    case '\u0679':
                        transliteratedStr += 'ṭ';
                        break;
                    // پ
                    case '\u067E':
                        transliteratedStr += 'p';
                        break;
                    // چ
                    case '\u0686':
                        transliteratedStr += "ch";
                        break;
                    // ڈ
                    case '\u0688':
                        transliteratedStr += 'ḍ';
                        break;
                    // ڑ
                    case '\u0691':
                        transliteratedStr += 'ṛ';
                        break;
                    // ژ
                    case '\u0698':
                        transliteratedStr += "zh";
                        break;
                    // ک
                    case '\u06A9':
                        transliteratedStr += 'k';
                        break;
                    // or return q depending on rule
                    //return 'q';

                    // گ
                    case '\u06AF':
                        transliteratedStr += 'g';
                        break;
                    // ھ
                    case '\u06BE':
                        transliteratedStr += 'h';
                        break;
                    // ہ 
                    case '\u06C1':
                        transliteratedStr += "h";

                        break;
                    // ی
                    case '\u06CC':
                        transliteratedStr += 'y';
                        break;
                    // or return  i depending on rule
                    //                    return 'i';
                    // bari ye
                    case '\u0626':
                        transliteratedStr += "ai";
                        break;
                    // ے
                    case '\u06D2':

                            transliteratedStr += 'e';

                        break;
                    // space
                    case '\u0020':
                        transliteratedStr += ' ';
                        break;
                    // ؟
                    case '\u061F':
                        transliteratedStr += '?';
                        break;
                    // . (period)
                    case '\u06D4':
                        transliteratedStr += '.';
                        break;
                    // , (comma)
                    case '\u060C':
                        transliteratedStr += '.';
                        break;

                    default:
                        transliteratedStr += inputChar;
                        //MessageBox.Show($"Character: {inputChar}, Unicode: {Convert.ToUInt16(inputChar):X4}");
                        break;
                }

            }


            return transliteratedStr;

        }


        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                //MessageBox.Show("hello");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            richTextBox1.Text = "Transliteration";
            richTextBox2.Text = "Translation";
        }
    }

}
