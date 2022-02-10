using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PillReminderUI
{
    public partial class ReminderWindow : Form
    {
        BindingList<PillModel> medications = new BindingList<PillModel>();
        BindingList<PillModel> pillsToTake = new BindingList<PillModel>();

        public ReminderWindow()
        {
            InitializeComponent();
            allPillsListBox.DataSource = medications;
            allPillsListBox.DisplayMember = "PillInfo";

            pillsToTakeListBox.DataSource = pillsToTake;
            pillsToTakeListBox.DisplayMember = "PillInfo";

            PopulateDummyData();
            populatePillsToTake();
        }

        private void populatePillsToTake()
        {
            pillsToTake.ToList().ForEach(x => Console.WriteLine(x.LastTaken.TimeOfDay + " -> " + x.PillName + " " + x.TimeToTake));
            medications.Where(x => x.LastTaken < x.TimeToTake && x.TimeToTake.TimeOfDay < DateTime.Now.TimeOfDay)
                .ToList()
                .ForEach(x => 
                { 
                    pillsToTake.Add(x); 
                    medications.Remove(x); 
                });
        }

        private void PopulateDummyData()
        {
            medications.Add(new PillModel { PillName = "The white one", TimeToTake = DateTime.Parse("0:15 am") });
            medications.Add(new PillModel { PillName = "The big one", TimeToTake = DateTime.Parse("8:00 am") });
            medications.Add(new PillModel { PillName = "The red ones", TimeToTake = DateTime.Parse("23:45") });
            medications.Add(new PillModel { PillName = "The oval one", TimeToTake = DateTime.Parse("0:27 am") });
            medications.Add(new PillModel { PillName = "The round ones", TimeToTake = DateTime.Parse("18:15 pm") });
        }

        private void refreshPillsToTake_Click(object sender, EventArgs e)
        {
            pillsToTake.ToList().ForEach(x =>
            { 
                medications.Add(x);
                pillsToTake.Remove(x);
            });
            populatePillsToTake();
        }

        private void takePill_Click(object sender, EventArgs e)
        {
            var pill = (PillModel)pillsToTakeListBox.SelectedItem;
            pill.LastTaken = DateTime.Now;
            pill.TimeToTake.AddDays(1);
            Console.WriteLine(  pill.LastTaken);
            medications.Add(pill);
            pillsToTake.Remove(pill);
            populatePillsToTake();
        }
    }
}
