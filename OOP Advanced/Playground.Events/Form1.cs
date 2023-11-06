namespace Playground.Events
{
    public partial class Form1 : Form
    {
        private int _clicksCount;

        public Form1()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            this.ChangeButtonName();
            this.IncreaseClicksCount();
        }

        private void ChangeButtonName()
        {
            this.operativeButton.Text = "Hello!";
        }

        private void IncreaseClicksCount()
        {
            this._clicksCount++;
            this.clicksCounter.Text = $"Clicks count: {this._clicksCount}";
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            this.textLabel.Text = this.textBox.Text;
        }
    }
}