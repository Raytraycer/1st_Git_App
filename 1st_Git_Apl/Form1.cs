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


        public Form1()
        {
            InitializeComponent();
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
                get_MarketButtonCoordinatos();
            }

            if (e.KeyCode.ToString() == "NumPad8")
            {
                mouse_ClickToExportToMarket_Button();
            }
            e.Handled = true;
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            //lstLog.Items.Add("Down\t" + e.KeyCode.ToString());
            e.Handled = true;
        }
        #endregion



        
       
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
            mouse_event(MouseFlags.Absolute | MouseFlags.LeftUp  , Abs_X, Abs_Y, 0, UIntPtr.Zero); 
        }
        #endregion


        void get_MarketButtonCoordinatos()
        {
            X_marketBtn = Control.MousePosition.X;
            Y_marketBtn = Control.MousePosition.Y;
            lb_CurrentCursorPosition.Text = ("Market Btn.: X:" + X_marketBtn.ToString() + " - Y:" + Y_marketBtn.ToString());

        }

        

        public static void DoMouseClick()
        {
            
        }

    }
}
