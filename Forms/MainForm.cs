using FireLadder.Forms;

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
            this.Dispose(true);
            Application.Exit();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Environment.Exit(0);
        }
    }
}