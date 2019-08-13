using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonRegistry
{
    public partial class Form1 : Form
    {
        public List<Person> Person = new List<Person>();

        public Form1()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox1.Items.Clear();

            if (radioButton1.Checked == true)
            {
                if (!String.IsNullOrEmpty(FirstNameText.Text) && !String.IsNullOrEmpty(LastNameText.Text))
                {
                    Person.Add(new Male("Mr", FirstNameText.Text, LastNameText.Text));
                }
                else
                {
                    MessageBox.Show("Enter First and Lastname!");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (!String.IsNullOrEmpty(FirstNameText.Text) && !String.IsNullOrEmpty(LastNameText.Text))
                {
                    Person.Add(new Female("Miss", FirstNameText.Text, LastNameText.Text));
                }
                else
                {
                    MessageBox.Show("Enter First and Lastname!");
                } 
            }
            else
            {
                MessageBox.Show("Enter First and Lastname! \n or Pick Male or Female!");
                return;
            }
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            FirstNameText.Clear();
            LastNameText.Clear();
            PrintNameLists();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void PrintNameLists()
        {
            Person.Sort();
            foreach (var i in Person)
            {
                listBox1.Items.Add(i.GetFullNames());
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int indexnr;

            if(listBox1.SelectedIndex == -1)
            {
                indexnr = listBox1.SelectedIndex - 1;
                MessageBox.Show("Select a Person to Remove");
            }
            else
            {
                indexnr = listBox1.SelectedIndex;
                listBox1.Items.Clear();
                Person.RemoveAt(indexnr);
                PrintNameLists();
                Person.Sort();
            }
        }

        private void SortbuttonClick_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            PrintNameLists();
        }

        private void Mergebutton_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItems.Count == 2)
            {
                var indexnumber = listBox1.SelectedIndices;
                var member = Person[indexnumber[0]] + Person[indexnumber[1]];
                if(member!= null)
                {
                    Person.Add(member);
                    listBox1.Items.Clear();
                    PrintNameLists();
                }
                else
                {
                    MessageBox.Show("Mr and Miss Merge Only!");
                }
            }
            else
            {
                listBox1.ClearSelected();
            }
            
        }

        private void FirstNameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
            MessageBox.Show("Only Alphabets Here!");
        }

        private void LastNameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
            MessageBox.Show("Only Alphabets Here!");
        }
    }
}
