namespace Лаб2_1ТП
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.textBox1.ToString();
            textBox2.Text = Properties.Settings.Default.textBox2.ToString();
            textBox3.Text = Properties.Settings.Default.textBox3.ToString();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c;
            try
            {
                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox2.Text);
                c = double.Parse(textBox3.Text);
            }
            catch (FormatException) 
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.textBox1 = a;
            Properties.Settings.Default.textBox2 = b;
            Properties.Settings.Default.textBox3 = c;
            Properties.Settings.Default.Save();

            MessageBox.Show(Logic.GetAllAnswers(a, b, c));
        }
    }
    public class Logic
    {
        public static string OutputMonthB(double a, double b)
        {
            string[] months = new string[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            int numberOfMonth = 2;
            string outMessage = "";
            for (double i = 0; i <= b; i = a * 0.02)
            {
                a += i;
                if (numberOfMonth == 11)
                    numberOfMonth = 0;
                else
                    numberOfMonth++;
            }
            outMessage = "a)Величина ежемесячного увеличения вклада превысит " + b + " руб. за " + months[numberOfMonth];
            return outMessage;
        }
        public static string OutputCountOfMonthsC(double a, double c)
        {
            int countOfMonth = 0;
            string outMessage = "";
            for (double i = a; i < c; i += a * 0.02)
            {
                a *= 1.02;
                countOfMonth++;
            }
            if (countOfMonth > 0)
                outMessage = "б)Количество месяцев, за которое размер вклада превысит " + c + " руб.: " + countOfMonth.ToString();
            else
                outMessage = "б)Внесенная сумма изначально уже больше " + c + " руб.";
            return outMessage;
        }
        public static string GetAllAnswers(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
                return "Ошибка: введены отрицательные значения, вводите только положительные";
            var answer = OutputMonthB(a, b) + "\n" + OutputCountOfMonthsC(a, c);
            return answer;
        }
    }
}