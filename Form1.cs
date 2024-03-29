using System.Diagnostics.Eventing.Reader;
using System.Xml.Serialization;

namespace wf_hw_two
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int guessedNumber))
            {
                if (guessedNumber >= 0 && guessedNumber <= 2000)
                {
                    int min = 0;
                    int max = 2000;
                    int num = -1;
                    int choice;
                    int attempts = 0;
                    Random random = new Random();
                    while (num != guessedNumber)
                    {
                        attempts++;
                        choice = random.Next(0, 2);
                        num = min + (max - min) / 2;
                        var numResult = MessageBox.Show($"���� ����� {num}?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (numResult == DialogResult.Yes)
                        {
                            break;
                        }
                        else
                        {
                            if (choice == 0)
                            {
                                numResult = MessageBox.Show($"���� ����� ������ {num}?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (numResult == DialogResult.Yes)
                                {
                                    min = num;
                                }
                                else
                                {
                                    max = num;
                                }
                            }
                            else
                            {
                                numResult = MessageBox.Show($"���� ����� ������ {num}?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (numResult == DialogResult.Yes)
                                {
                                    max = num;
                                }
                                else
                                {
                                    min = num;
                                }
                            }
                        }
                    }
                    var retryResult = MessageBox.Show($"� ������ ���� �����: {num}. ���������� �������: {attempts}. ������ ���������?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (retryResult == DialogResult.No)
                    {
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("���� ����� ������ 2000 ���� ������ 0!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("������� �����!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = string.Empty;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}