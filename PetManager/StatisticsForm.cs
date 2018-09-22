namespace PetManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class StatisticsForm : Form
    {
        public StatisticsForm(ICollection<Person> persons)
        {
            InitializeComponent();

            var avg = 0m;
            if (persons.Any())
            {
                var petCnt = 0m;
                foreach (var person in persons)
                {
                    petCnt += person.Pets.Count;
                }

                avg = petCnt / persons.Count;
            }

            this.lblVal.Text = string.Format(this.lblVal.Text, avg.ToString("N2"));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}