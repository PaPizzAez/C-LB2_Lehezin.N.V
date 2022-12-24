namespace LABA2
{
  public partial class Screen : Form
  {
    private readonly List<StudioGenerator> _list = new List<StudioGenerator>();

    public Screen()
    {
      InitializeComponent();
    }

    private void СreateStudio_Click(object sender, EventArgs e)
    {
      string name = textBox1.Text;
      string address = textBox2.Text;

      string moneyForTrack = textBox4.Text;
      string timeForTraсk = textBox5.Text;
      string salaryForMonth = textBox6.Text;

      if (name.Length == 0 || address.Length == 0)
      {
        MessageBox.Show("Введіть щось у поля, вони усі обов'язкові!");
        return;
      }

      var newStudio = new StudioGenerator(name, address, Int32.Parse(moneyForTrack), Int32.Parse(timeForTraсk), Int32.Parse(salaryForMonth));
      _list.Add(newStudio);

      comboBox1.Items.Add(name);
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = comboBox1.SelectedIndex;

      textBox1.Text = _list[index].name;
      textBox2.Text = _list[index].address;
      textBox3.Text = _list[index].people.ToString();
      textBox4.Text = _list[index].moneyForTrack.ToString();
      textBox5.Text = _list[index].timeForTraсk.ToString();
      textBox6.Text = _list[index].salaryForMonth.ToString();
      textBox7.Text = _list[index].allSalaryForMonth.ToString();
      textBox8.Text = _list[index].InstNum.ToString();
      textBox9.Text = _list[index].RoomsNum.ToString();
      textBox10.Text = _list[index].money.ToString();
    }

    private void buildNewRoom_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      int index = comboBox1.SelectedIndex;
      _list[index].CreateRoom();

      textBox9.Text = _list[index].RoomsNum.ToString();
      textBox10.Text = _list[index].money.ToString();
    }
    private void destroyRoom_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      int index = comboBox1.SelectedIndex;
      _list[index].DeleteRoom();

      textBox9.Text = _list[index].RoomsNum.ToString();
    }

    private void hireWorker_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      int index = comboBox1.SelectedIndex;
      _list[index].Hire();

      textBox3.Text = _list[index].people.ToString();
    }
    private void dismissWorker_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      int index = comboBox1.SelectedIndex;
      _list[index].Dismiss();

      textBox3.Text = _list[index].people.ToString();
    }

    private void buyInstrument_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      int index = comboBox1.SelectedIndex;
      _list[index].BuyInstrument();

      textBox8.Text = _list[index].InstNum.ToString();
    }
    private void brokeInstrument_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      int index = comboBox1.SelectedIndex;
      _list[index].DeleteInstrument();

      textBox8.Text = _list[index].InstNum.ToString();
    }
    private void copyStudio_Click(object sender, EventArgs e)
    {
      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      int index = comboBox1.SelectedIndex;
      StudioGenerator cloned = (StudioGenerator)_list[index].Clone();

      _list.Add(cloned);
      comboBox1.Items.Add(cloned.name);
    }

    private void addBalance_Click(object sender, EventArgs e)
    {
      string toCheck = textBox11.Text;

      if (comboBox1.SelectedIndex == -1)
      {
        MessageBox.Show("Оберіть студію зі списку!");
        return;
      }

      if (toCheck != "")
      {
        int index = comboBox1.SelectedIndex;

        _list[index].AddBalance(Int32.Parse(textBox11.Text));
        textBox10.Text = _list[index].money.ToString();
      }
    }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
