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
                //yalan iþ
                await Task.Delay(5000, cts.Token);
            }
            catch (OperationCanceledException)
            {
                //sadece cancel iþleminden kaynaklý exceptionlarý görmezden gel (yut)
            }
            catch (NullReferenceException)
            {
            }
            catch (IndexOutOfRangeException)
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

        private void btnFill_Click(object sender, EventArgs e)
        {
            Task.Run(async () => { 
                var sections = new List<List<object>>();
                for (var i = 0; i < 100; i++)
                {
                    sections.Add(new List<object>());
                }
                var section = 0;

                for (var i = 0; i < 100000; i++)
                {
                    sections[section].Add(i);
                    if (i % 1000 == 0)
                    {
                        //Ana thread (UI Thread) iþi gönder
                        lstNumbers.Invoke(() =>
                        {
                            var numbers = sections[section].ToArray();
                            //Bu kod UI thread içinde çalýþýr
                            lstNumbers.Items.AddRange(numbers);
                        });
                        section++;
                    }
                    await Task.Yield();
                }
            });
        }
    }
}
