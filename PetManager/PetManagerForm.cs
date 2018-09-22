namespace PetManager
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class PetManagerForm : Form
    {
        public PetManagerForm()
        {
            InitializeComponent();

            this.dgvPerson.DataSource = Person.GetDemoData();
            this.dgvPerson.Rows[0].Selected = true;
        }

        private void dgvPerson_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count > 0)
            {
                var person = (Person)dgv.SelectedRows[0].DataBoundItem;
                this.dgvPet.DataSource = person.Pets;
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            var personList = (BindingList<Person>)this.dgvPerson.DataSource;
            personList.Add(new Person());
            this.dgvPerson.Refresh();
        }

        private void btnRemovePerson_Click(object sender, EventArgs e)
        {
            if (this.dgvPerson.SelectedRows.Count > 0)
            {
                var person = (Person)this.dgvPerson.SelectedRows[0].DataBoundItem;
                var personList = (BindingList<Person>)this.dgvPerson.DataSource;
                personList.Remove(person);
            }
            else
            {
                MessageBox.Show("You have to select a person first.", "Remove person", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {
            if (this.dgvPerson.SelectedRows.Count > 0)
            {
                // TODO (RAY): Feld ergänzen!

                var person = (Person)this.dgvPerson.SelectedRows[0].DataBoundItem;
                person.Pets.Add(new Pet(new DateTime(2018, 1, 1)));
            }
            else
            {
                MessageBox.Show("You have to select a person first.", "Add pet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemovePet_Click(object sender, EventArgs e)
        {
            if (this.dgvPet.SelectedRows.Count > 0)
            {
                var person = (Person)this.dgvPerson.SelectedRows[0].DataBoundItem;
                var pet = (Pet)this.dgvPet.SelectedRows[0].DataBoundItem;
                person.Pets.Remove(pet);
            }
            else
            {
                MessageBox.Show("You have to select a pet first.", "Remove pet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnShowStatistic_Click(object sender, EventArgs e)
        {
            var personList = (BindingList<Person>)this.dgvPerson.DataSource;
            new StatisticsForm(personList).ShowDialog(this);
        }
    }
}