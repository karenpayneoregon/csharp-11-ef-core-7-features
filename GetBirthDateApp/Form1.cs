using GetBirthDateApp.Classes;
using NodaTime;
using System;

namespace GetBirthDateApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Shown += Form1_Shown;
    }

    private void Form1_Shown(object sender, EventArgs e)
    {
        NodaDateTimePicker.Value = new DateOnly(1956, 9, 24).ToDateTime(TimeOnly.MinValue);

        ZonesComboBox.DataSource = DateTimeZoneProviders.Tzdb.Ids.Where(x => x.StartsWith("America")).ToList();
        ZonesComboBox.SelectedIndex = ZonesComboBox.FindString("America/Los_Angeles");

        NodaTimeGetAge();
        GetAgeRaw();
    }

    private void NodaGetAgeButton_Click(object sender, EventArgs e)
    {
        NodaTimeGetAge();
    }

    private void NodaTimeGetAge()
    {
        NodaAgeTextBox.Text = NodaTimeOperations.GetAge(NodaDateTimePicker.Value.ToLocalDate(), ZonesComboBox.Text).ToString();
    }

    private void GetAgeRawButton_Click(object sender, EventArgs e)
    {
        GetAgeRaw();
    }

    private void GetAgeRaw()
    {

        GetAgeRawTextBox1.Text = ((2024_11_10 - 1956_09_24) / 10000).ToString();

        int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
        int dob = int.Parse(new DateOnly(1956, 9, 24).ToString("yyyyMMdd"));
        int age2 = (now - dob) / 10000;

        GetAgeRawTextBox2.Text = new DateOnly(1956, 9, 24).GetAge().ToString();

    }
}
