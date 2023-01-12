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

        #region   ����Windows��Ϣ
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            //const int WM_DESTROY = 0x0002;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                //��׽�رմ�����Ϣ      
                //   User   clicked   close   button      
                this.Hide();
                return;
            }
            base.WndProc(ref m);
        }
        #endregion

        // ��������
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            (new AboutBox()).Show();
        }
        // �˳�����
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.Dispose(true);//����ǰ������������ʹ�õ���Դ��
            Application.Exit();//ǿ��������Ϣ��ֹ���˳����еĴ��壬���������й��̣߳������̣߳���Ҳ�޷��ɾ����˳���
            System.Diagnostics.Process.GetCurrentProcess().Kill();//������������
            Environment.Exit(0);//������׵��˳���ʽ������ʲô�̶߳���ǿ���˳����ѳ�������ĺܸɾ���
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //ע��ȫ���ȼ�
            GlobalHotkey();
        }

        //ע��ȫ���ȼ�
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

        // �ȼ�����
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

        //������̴򿪴���
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