using System.Data;

namespace HW_010923
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		// Всё гениальное - просто. Это собыьтие срабатывает когда мы меняем мат формулу задачи. Мы просто переводим 'sender' в строку и достаем последний символ.
		private void Updating_Task_Conditions(object sender, EventArgs e)
		{
			tbDisplay.Text += sender.ToString()[sender.ToString().Length - 1];
		}

		private void bEqual_Click(object sender, EventArgs e)
		{
			string MathFormula = tbDisplay.Text;

			try {
				DataTable table = new DataTable();
				table.Columns.Add("expression", typeof(string), MathFormula);

				DataRow row = table.NewRow();
				table.Rows.Add(row);

				double result = double.Parse((string)row["expression"]);
				tbDisplay.Text = result.ToString();
			} catch (Exception ex) {
				tbDisplay.Text = ("Error: " + ex.Message);
			}
		}

		private void bLArrow_Click(object sender, EventArgs e)
		{
			tbDisplay.Text = tbDisplay.Text.Substring(0, tbDisplay.Text.Length - 1);
		}

		private void bAC_Click(object sender, EventArgs e)
		{
			tbDisplay.Text = null;
		}
	}
}