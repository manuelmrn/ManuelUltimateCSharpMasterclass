namespace FirstWinFormsApp
{
	public partial class MainForm : Form
	{
		private int _count = 0;

		public MainForm()
		{
			InitializeComponent();
		}

		private void btnIncreaseCounter_Click(object sender, EventArgs e)
		{
			_count++;

			lblCounter.Text = _count.ToString();
		}
	}
}
