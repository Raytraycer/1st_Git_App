using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using System.Runtime.InteropServices;
using WindowsInput;
using System.IO;

namespace _1st_Git_Apl
{
    public partial class Form1 : Form
    {
        globalKeyboardHook gkh = new globalKeyboardHook(); // срздаю глобальный хук для вызова хоткея, подлючив globalKeyboardHook.cs

        #region импортируем mouse_event():
        [DllImport("User32.dll")]
        static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        enum MouseFlags
        {
            //Move = 0x0001, LeftDown = 0x0002, LeftUp = 0x0004, RightDown = 0x0008,
            //RightUp = 0x0010, Absolute = 0x8000
            Move = 0x200, LeftDown = 0x201, LeftUp = 0x202, RightDown = 0x204,
            RightUp = 0x205, Absolute = 0x8000
        };
        #endregion

        ListView SpisokFilov = new ListView();
        List<string> SpisokStrok = new List<string>();
        DirectoryInfo dir = new DirectoryInfo("Marketlogs");
        string[,] ArrayMain = new string[500, 50];




        public Form1()
        {
            InitializeComponent();
            dg_OrderData.Rows.Add();
            dg_OrderData.Rows.Add();
            dg_OrderData.Rows.Add();
            dg_OrderData.Rows.Add();
            dg_OrderData.Rows[0].Cells[0].Value = "SellPrice";
            dg_OrderData.Rows[1].Cells[0].Value = "BuyPrice";
            dg_OrderData.Rows[2].Cells[0].Value = "DirectDiff";
            dg_OrderData.Rows[3].Cells[0].Value = "All taxes";
            dg_OrderData.Rows[4].Cells[0].Value = "Real diff";
            UpdateFont();
        }

        #region global hot keys
        private void Form1_Load(object sender, EventArgs e)
        {
            gkh.HookedKeys.Add(Keys.NumPad7); // нажимаемая кнопка
            gkh.HookedKeys.Add(Keys.NumPad8);
            //gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp); // вызиваемая функция
        }

        void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            //lb_CurrentCursorPosition.Text=("Up\t" + e.KeyCode.ToString());
            //string KeyUpName = e.KeyCode.ToString();
            //mouse_ClickToExportToMarket_Button();
            if (e.KeyCode.ToString() == "NumPad7")
            {
                get_SellPriceToClipBoard();
            }

            if (e.KeyCode.ToString() == "NumPad8")
            {
                get_BuyPriceToClipBoard();
            }
            e.Handled = true;
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            //lstLog.Items.Add("Down\t" + e.KeyCode.ToString());
            e.Handled = true;
        }
        #endregion




        /*
        #region функции управления мышью

        float X_coef = 65535 / 1920; // устанавливаю глобальные коэфициенты отношений абсолютных координат к разрешению экрана. 
        float Y_coef = 65535 / 1080; // устанавливаю глобальные коэфициенты отношений абсолютных координат к разрешению экрана.
        int X_marketBtn = 0;
        int Y_marketBtn = 0;

        void mouse_ClickToExportToMarket_Button()
        {
            //int x = 960;     // данные о фактических координатах кнопки в относительных координатах (в пикселях) -x
            //int y = 540;     // --//-- y

            int Abs_X = Convert.ToInt32(X_marketBtn * X_coef);
            int Abs_Y = Convert.ToInt32(Y_marketBtn * Y_coef);
            Cursor.Position = new Point(X_marketBtn, Y_marketBtn);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftDown, Abs_X, Abs_Y, 0, UIntPtr.Zero);
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp, Abs_X, Abs_Y, 0, UIntPtr.Zero);
        }
        #endregion

        
        void get_MarketButtonCoordinatos()
        {
            X_marketBtn = Control.MousePosition.X;
            Y_marketBtn = Control.MousePosition.Y;
            lb_CurrentCursorPosition.Text = ("Market Btn.: X:" + X_marketBtn.ToString() + " - Y:" + Y_marketBtn.ToString());

        }
        */


        
        

        public void get_TypeOfCalculation()
        {
            // Обрабатываю список файлов в зависимости от кол-ва найденных файлов в папке
            
            // завожу списки для импорта файла маркета
            SpisokFilov.Clear();
            SpisokStrok.Clear();
            

            // Собираю список файлов из директории.
            foreach (FileInfo files in dir.GetFiles())
            {
                SpisokFilov.Items.Add(files.Name);
            }



            // если файл один - значит просто беру из него данные о ценах в текущей локации
            if (SpisokFilov.Items.Count == 1)
            {
                get_Sell_Buy_PricesFromFile();
            }
            if (SpisokFilov.Items.Count == 0)
            {
                MessageBox.Show("Nothing to read.");
            }

        }




        double SellPrice = 999999999999;
        double BuyPrice = 0;
        
       //dg_OrderData.Rows.Add();
          //      






        public void get_SellPriceToClipBoard()
        {
            get_TypeOfCalculation();
            Clipboard.SetText(Convert.ToString(SellPrice));
        }



        public void get_BuyPriceToClipBoard()
        {
            get_TypeOfCalculation();
            Clipboard.SetText(Convert.ToString(BuyPrice));
        }





        public void get_Sell_Buy_PricesFromFile()
        {
            // завожу списки для импорта файла маркета
            
            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    ArrayMain[i, j] = "";
                }
            }
           


            string File_Name = SpisokFilov.Items[0].ToString();
            string[] F_cut = File_Name.Split('{');

            File_Name = F_cut[1].Trim('}');
            if (File.Exists("Marketlogs/" + File_Name))
            {
                try //Считываю все строки.
                {
                    FileStream fs = new FileStream("Marketlogs/" + File_Name, FileMode.Open, FileAccess.Read);
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string str;
                        while ((str = sr.ReadLine()) != null)
                        {
                            SpisokStrok.Add(str);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Couldnt read from file.\n");
                }

                //string[,] ArrayMain = new string[SpisokStrok.Count,50]; // просто задаю размерность
                for (int t = 0; t < SpisokStrok.Count; t++)
                {
                    ArrayMain[t, 0] = SpisokStrok[t];
                    string[] BufferLine = SpisokStrok[t].Split(',');
                    int r = 0;
                    foreach (string item in BufferLine)
                    {
                        ArrayMain[t, r] = BufferLine[r];
                        r++;
                    }
                }
            }
            #region поиск минимльной/максимальной цены.
            SellPrice = 999999999999;
            BuyPrice = 0;

            for (int i = 0; i < 500; i++)
            {
                if (ArrayMain[i, 7] == "False")
                {
                    if (ArrayMain[i, 13] == "0")
                    {
                        if (Convert.ToDouble(ArrayMain[i, 0]) < SellPrice)
                        {
                            SellPrice = Convert.ToDouble(ArrayMain[i, 0]) - 0.01;
                           // MessageBox.Show(Convert.ToString(SellPrice));
                            //Clipboard.SetText(Convert.ToString(SellPrice));
                        }
                    }
                }
            }


            for (int i = 0; i < 500; i++)
            {
                if (ArrayMain[i, 7] == "True")
                {
                    if (ArrayMain[i, 13] == "0")
                    {
                        if (Convert.ToDouble(ArrayMain[i, 0]) > BuyPrice)
                        {
                            BuyPrice = Convert.ToDouble(ArrayMain[i, 0]) + 0.01;

                        }
                    }
                }
            }


            const string dir = @"Marketlogs";
            foreach (string file in Directory.GetFiles(dir))
            //File.Delete(file);

            dg_OrderData.Rows[0].Cells[1].Value = get_UserFrendlyViewOfPrice(SellPrice.ToString());
            dg_OrderData.Rows[1].Cells[1].Value = get_UserFrendlyViewOfPrice(BuyPrice.ToString());
            UpdateFont();
            #endregion
        }

        public string get_UserFrendlyViewOfPrice(string Price)
        {
            double dprice = Convert.ToDouble(Price);
            int billions = ((int)dprice / 1000000000);
            int millions = ((int)(dprice-billions*1000000000) / 1000000);
            int thousands= ((int)(dprice - billions*1000000000- millions*1000000) / 1000);
            int pcs      = ((int)(dprice - billions*1000000000- millions*1000000 -thousands*1000));
            
            //преобразовываю в стринг с добавлением нулей перед разрядами для красоты
            string sbillions = get_CorrectPresentationOfPrices(billions.ToString());
            string smillions = get_CorrectPresentationOfPrices(millions.ToString());
            string sthousands = get_CorrectPresentationOfPrices(thousands.ToString());
            string spcs = get_CorrectPresentationOfPrices(pcs.ToString());
            string sprice = sbillions + "B " + smillions + "M " + sthousands + "K " + spcs + "isk";
            return sprice;
        }

        public string get_CorrectPresentationOfPrices (string sPrice)
        {
            while (sPrice.Length < 3)
            {
                sPrice = "0" + sPrice;
            } 
            return sPrice;
        }


        public void UpdateFont()
        {
            //Change cell font
            foreach (DataGridViewColumn c in dg_OrderData.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 8.5F, GraphicsUnit.Pixel);
            }
        }





    }
}
