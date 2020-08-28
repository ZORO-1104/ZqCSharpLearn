using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZqCSharpLearn.MultiThread.A03
{
    internal class MultiThreadA03 : ICodeTest
    {
        private Form form = new Form();
        private TextBox textBox = new TextBox();

        public void Execute()
        {
            Test01();
        }

        /// <summary>
        /// 利用封送技术，实现对客户端控件的更新
        /// </summary>
        private void Test01()
        {
            textBox.Width = 200;
            form.Controls.Add(textBox);

            new Thread(DoWork).Start();

            form.ShowDialog();
        }

        private void DoWork()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(2000);
                UpdateMessage("Hello...");
            }
        }

        private void UpdateMessage(string v)
        {
            Action act = () => { UpdateControlsDisplay(v); };
            form.BeginInvoke(act);
        }

        private void UpdateControlsDisplay(string v)
        {
            textBox.Text = $"{DateTime.Now.ToString()}>>{v}";
        }
    }
}