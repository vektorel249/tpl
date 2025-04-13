namespace Vektorel.Tpl.FormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CancellationTokenSource cts;
        private void btnSum_Click(object sender, EventArgs e)
        {
            var sum = int.Parse(txtNum1.Text) + int.Parse(txtNum2.Text);
            txtSum.Text = sum.ToString();
        }

        private async void btnWait_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            btnWait.Enabled = false;
            try
            {
                //yalan i�
                await Task.Delay(5000, cts.Token);
            }
            catch (OperationCanceledException)
            {
                //sadece cancel i�leminden kaynakl� exceptionlar� g�rmezden gel (yut)
            }
            catch(NullReferenceException) 
            {
            }
            catch(IndexOutOfRangeException)
            {
            }
            btnWait.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cts is null)
            {
                return;
            }
            cts.Cancel();
        }
    }
}
