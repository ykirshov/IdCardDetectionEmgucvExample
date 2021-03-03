using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using EmguCVIDCardRecognizer.Enums;
using EmguCVIDCardRecognizer.Models;
using EmguCVIDCardRecognizer.Parsers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EmguCVIDCardRecognizer
{
    public partial class Form1 : Form
    {
        private List<string> _languages = new List<string>
        {
            "English",
            "Latina",
            "Ukrainian"
        };
        private List<string> _modes = new List<string>
        {
            "TesseractOnly",
            "LstmOnly",
            "TesseractLstmCombined",
            "Default"
        };
        private List<string> _typesDocument = new List<string>
        {
            "IDCardFrontSide",
            "IDCardBackSide",
            "INN",
            "SimpleText"
        };
        private List<string> _adaptiveThresholdTypes = new List<string>
        {
            "MeanC",
            "GaussianC"
        };
        private List<string> _thresholdTypes = new List<string>
        {
            "Binary",
            "BinaryInv",
        };

        private string _fileName = Path.GetFullPath("../../Resources/idcard_ukraine.jpg");
        private Image _imgDefault;
        private Image<Gray, Byte> _sourseImage;
        private Image<Gray, Byte> _img_gray;
        private Tesseract _ocr;
        private string _language;
        private OcrEngineMode _mode;
        private DocumentType _type;
        private AdaptiveThresholdType _adaptiveThresholdType;
        private ThresholdType _thresholdType;
        private bool useAdaptive = false;
        private bool useBinary = false;
        private bool useBinaryInv = false;

        public Form1()
        {
            InitializeComponent();
            comboLanguage.DataSource = _languages;
            comboEngineMode.DataSource = _modes;
            comboDocument.DataSource = _typesDocument;
            comboAdaptiveThresholdType.DataSource = _adaptiveThresholdTypes;
            comboThresholdType.DataSource = _thresholdTypes;

            labelThreshold.Text = $"Threshold = {trackThresholdBinary.Value}";
            _ocr = new Tesseract(Path.GetFullPath("../../tessdata/"), _language, OcrEngineMode.TesseractOnly);
            _imgDefault = Image.FromFile(_fileName);
            pictureDefault.Image = _imgDefault;
            _sourseImage = new Image<Gray, Byte>(_fileName).Resize(2, Inter.Linear);
            _img_gray = _sourseImage.CopyBlank();
            pictureBinarisation.Image = _sourseImage.ToBitmap();

            _type = DocumentType.IDCardFrontSide;
            _language = "eng";
            _mode = OcrEngineMode.TesseractOnly;
            checkBinaryThreshold.Checked = true;
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images(*.jpg,*.png,*.jpeg)|*.jpg;*.png;*.jpeg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _fileName = dialog.FileName;
                _imgDefault = Image.FromFile(_fileName);
                _sourseImage = new Image<Gray, Byte>(_fileName).Resize(2, Inter.Linear);
                _img_gray = _sourseImage.CopyBlank();
                pictureDefault.Image = _imgDefault;
                pictureBinarisation.Image = _sourseImage.ToBitmap();
            }    
        }

        private void buttonRecognize_Click(object sender, EventArgs e)
        {
            try
            {
                string data = "";
                _ocr = new Tesseract(Path.GetFullPath("../../tessdata/"), _language, _mode);
                Cursor.Current = Cursors.WaitCursor;
                _ocr.SetImage(_img_gray);
                _ocr.Recognize();
                data = _ocr.GetUTF8Text();
                textRecognize.Text = data;
                _ocr?.Dispose();

                IDCardClient client;
                switch (_type)
                {
                    case DocumentType.IDCardFrontSide:
                        client = IDCardParser.ReadIDCardFrontSide(data);
                        textResult.Text = client.ToStringFrontSide();
                        break;
                    case DocumentType.IDCardBackSide:
                        client = IDCardParser.ReadIDCardBackSide(data);
                        textResult.Text = client.ToString();
                        break;
                    case DocumentType.INN:
                        string clientInn = INNParser.Parse(data);
                        textResult.Text = $"INN = {clientInn}";
                        break;
                    case DocumentType.SimpleText:
                        textResult.Text = data;
                        break;

                    default: 
                        break;
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }     
        }

        private void CovertIntoGray()
        {
            if (useAdaptive && useBinary)
            {
                _img_gray = _sourseImage.SmoothGaussian(Convert.ToInt32(numericSmooth.Value)).ThresholdAdaptive(new Gray(255), _adaptiveThresholdType, _thresholdType, Convert.ToInt32(numericBlockSize.Value), new Gray(0.05));
                if (useBinaryInv)
                {
                    _img_gray = _img_gray.SmoothGaussian(Convert.ToInt32(numericSmooth.Value)).ThresholdBinaryInv(new Gray(trackThresholdBinary.Value), new Gray(255));
                } else
                {
                    _img_gray = _img_gray.SmoothGaussian(Convert.ToInt32(numericSmooth.Value)).ThresholdBinary(new Gray(trackThresholdBinary.Value), new Gray(255));
                }
            }
            else if (useAdaptive)
            {
                _img_gray = _sourseImage.SmoothGaussian(Convert.ToInt32(numericSmooth.Value)).ThresholdAdaptive(new Gray(255), _adaptiveThresholdType, _thresholdType, Convert.ToInt32(numericBlockSize.Value), new Gray(0.05));
            } 
            else if (useBinary)
            {
                if (useBinaryInv)
                {
                    _img_gray = _sourseImage.SmoothGaussian(Convert.ToInt32(numericSmooth.Value)).ThresholdBinaryInv(new Gray(trackThresholdBinary.Value), new Gray(255));
                }
                else
                {
                    _img_gray = _sourseImage.SmoothGaussian(Convert.ToInt32(numericSmooth.Value)).ThresholdBinary(new Gray(trackThresholdBinary.Value), new Gray(255));
                }
            } 
            else
            {
                _img_gray = _sourseImage.Copy();
            }
        }

        private void buttonBinarisation_Click(object sender, EventArgs e)
        {
            try
            {
                _img_gray?.Dispose();

                CovertIntoGray();
                pictureBinarisation.Image = _img_gray.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void comboLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboLanguage.SelectedIndex)
            {
                case (int)LanguageType.English:
                    _language = "eng";
                    break;
                case (int)LanguageType.Latina:
                    _language = "lat";
                    break;
                case (int)LanguageType.Ukrainian:
                    _language = "ukr";
                    break;
                default:
                    break;
            }
        }

        private void comboEngineMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboEngineMode.SelectedIndex)
            {
                case (int)OcrEngineMode.TesseractOnly:
                    _mode = OcrEngineMode.TesseractOnly;
                    break;
                case (int)OcrEngineMode.LstmOnly:
                    _mode = OcrEngineMode.LstmOnly;
                    break;
                case (int)OcrEngineMode.TesseractLstmCombined:
                    _mode = OcrEngineMode.TesseractLstmCombined;
                    break;
                case (int)OcrEngineMode.Default:
                    _mode = OcrEngineMode.Default;
                    break;
                default:
                    break;
            }
        }

        private void trackThreshold_Scroll(object sender, EventArgs e)
        {
            labelThreshold.Text = $"Threshold = {trackThresholdBinary.Value}";
            buttonBinarisation_Click(sender, e);
        }

        private void numericSmooth_ValueChanged(object sender, EventArgs e)
        {
            buttonBinarisation_Click(sender, e);
        }

        private void comboDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pictureBinarisation.Image != null)
            {
                int index = comboDocument.SelectedIndex;
                switch (index)
                {
                    case (int)DocumentType.IDCardFrontSide:
                        _type = DocumentType.IDCardFrontSide;
                        trackThresholdBinary.Value = 90;
                        numericSmooth.Value = 1;
                        checkAdaptiveThreshold.Checked = false;
                        checkBinaryThreshold.Checked = true;
                        checkBinaryInv.Checked = false;
                        groupBinaryThreshold.Visible = true;
                        groupAdaptiveThreshold.Visible = false;
                        labelThreshold.Text = $"Threshold = {trackThresholdBinary.Value}";
                        break;
                    case (int)DocumentType.IDCardBackSide:
                        _type = DocumentType.IDCardBackSide;
                        trackThresholdBinary.Value = 90;
                        numericSmooth.Value = 1;
                        checkAdaptiveThreshold.Checked = false;
                        checkBinaryThreshold.Checked = true;
                        checkBinaryInv.Checked = false;
                        groupBinaryThreshold.Visible = true;
                        groupAdaptiveThreshold.Visible = false;
                        labelThreshold.Text = $"Threshold = {trackThresholdBinary.Value}";
                        break;
                    case (int)DocumentType.INN:
                        _type = DocumentType.INN;
                        trackThresholdBinary.Value = 229;
                        numericSmooth.Value = 13;
                        checkAdaptiveThreshold.Checked = true;
                        checkBinaryThreshold.Checked = true;
                        checkBinaryInv.Checked = false;
                        groupAdaptiveThreshold.Visible = true;
                        groupBinaryThreshold.Visible = true;
                        numericBlockSize.Value = 3;
                        comboAdaptiveThresholdType.SelectedIndex = (int)AdaptiveThresholdType.GaussianC;
                        comboThresholdType.SelectedIndex = (int)ThresholdType.Binary;
                        labelThreshold.Text = $"Threshold = {trackThresholdBinary.Value}";
                        break;
                    case (int)DocumentType.SimpleText:
                        _type = DocumentType.SimpleText;
                        trackThresholdBinary.Value = 90;
                        numericSmooth.Value = 1;
                        checkAdaptiveThreshold.Checked = false;
                        checkBinaryThreshold.Checked = true;
                        checkBinaryInv.Checked = false;
                        groupBinaryThreshold.Visible = true;
                        groupAdaptiveThreshold.Visible = false;
                        labelThreshold.Text = $"Threshold = {trackThresholdBinary.Value}";
                        break;
                    default:
                        break;
                }
            }
        }

        private void checkAdaptiveThreshold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAdaptiveThreshold.Checked)
            {
                groupAdaptiveThreshold.Visible = true;
                useAdaptive = true;
            } else
            {
                groupAdaptiveThreshold.Visible = false;
                useAdaptive = false;
            }
            buttonBinarisation_Click(sender, e);
        }

        private void comboAdaptiveThresholdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (useAdaptive)
            {
                switch (comboAdaptiveThresholdType.SelectedIndex)
                {
                    case (int)AdaptiveThresholdType.MeanC:
                        _adaptiveThresholdType = AdaptiveThresholdType.MeanC;
                        break;
                    case (int)AdaptiveThresholdType.GaussianC:
                        _adaptiveThresholdType = AdaptiveThresholdType.GaussianC;
                        break;
                    default:
                        break;
                }
                buttonBinarisation_Click(sender, e);
            }
        }

        private void comboThresholdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (useAdaptive)
            {
                switch (comboThresholdType.SelectedIndex)
                {
                    case (int)ThresholdType.Binary:
                        _thresholdType = ThresholdType.Binary;
                        break;
                    case (int)AdaptiveThresholdType.GaussianC:
                        _thresholdType = ThresholdType.BinaryInv;
                        break;
                    default:
                        break;
                }
                buttonBinarisation_Click(sender, e);
            }
        }

        private void numericBlockSize_ValueChanged(object sender, EventArgs e)
        {
            buttonBinarisation_Click(sender, e);
        }

        private void checkBinaryThreshold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBinaryThreshold.Checked)
            {
                groupBinaryThreshold.Visible = true;
                useBinary = true;
            }
            else
            {
                groupBinaryThreshold.Visible = false;
                useBinary = false;
            }
            buttonBinarisation_Click(sender, e);
        }

        private void checkBinaryInv_CheckedChanged(object sender, EventArgs e)
        {
            useBinaryInv = checkBinaryInv.Checked;
            buttonBinarisation_Click(sender, e);
        }
    }
}
