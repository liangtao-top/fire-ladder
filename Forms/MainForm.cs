using FireLadder.Forms;
using NHotkey.WindowsForms;
using NHotkey;

namespace FireLadder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region   拦截Windows消息
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            //const int WM_DESTROY = 0x0002;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                //捕捉关闭窗体消息      
                //   User   clicked   close   button      
                this.Hide();
                return;
            }
            base.WndProc(ref m);
        }
        #endregion

        // 关于我们
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            (new AboutBox()).Show();
        }
        // 退出程序
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.Dispose(true);//清理当前窗体所有正在使用的资源。
            Application.Exit();//强制所有消息中止，退出所有的窗体，但是若有托管线程（非主线程），也无法干净地退出；
            System.Diagnostics.Process.GetCurrentProcess().Kill();//结束整个进程
            Environment.Exit(0);//这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //注册全局热键
            GlobalHotkey();
        }

        //注册全局热键
        private void GlobalHotkey()
        {
            HotkeyManager.Current.AddOrReplace("About", Keys.Control | Keys.F11, delegate (object sender, HotkeyEventArgs e)
            {
                MainForm_KeyDown(sender, new KeyEventArgs(Keys.F11));
            });
            HotkeyManager.Current.AddOrReplace("Exit", Keys.Control | Keys.F12, delegate (object sender, HotkeyEventArgs e)
            {
                MainForm_KeyDown(sender, new KeyEventArgs(Keys.F12));
            });
        }

        // 热键处理
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F11:
                    AboutBox aboutBox = new AboutBox();
                    aboutBox.Show();
                    break;
                case Keys.F12:
                    this.toolStripMenuItem7_Click(sender, e);
                    break;
            }
        }

        //点击托盘打开窗口
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Show();
            this.Activate();
        }
    }
    }