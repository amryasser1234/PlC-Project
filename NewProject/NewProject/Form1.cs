using com.calitha.goldparser;

namespace NewProject
{
    public partial class Form1 : Form
    {
        MyParser P;
        public Form1()
        {
            InitializeComponent();
            P = new MyParser("parser.cgt",listBox1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            P.Parse(textBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}