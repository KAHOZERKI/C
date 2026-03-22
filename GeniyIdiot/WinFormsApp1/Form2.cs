
using GeniusIdiot.Library;
namespace GeniyIdiot.WinForm
{
    public partial class resultsForm : Form
    {
        public resultsForm()
        {
            InitializeComponent();
            LoadResults();
        }
        public void LoadResults()

        {
            resultsBox.Rows.Clear();
            var results = UsersResultStorage.GetAllResults();
            foreach (var user in results)
            {
                resultsBox.Rows.Add(user.Name, user.CorrectRightAnswers, user.Diagnosis);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
