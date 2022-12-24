namespace LABA2
{
  class StudioGenerator : ICloneable
  {
    public string name { get => _name; set { _name = value; } }
    private string _name;
    public int money { get => _money; }
    private int _money;
    public string address { get => _address; }
    private string _address;
    public int people { get => _people; set { _people = value; } }
    private int _people;
    public int moneyForTrack { get => _moneyForTrack; }
    private int _moneyForTrack;
    public int timeForTraсk { get => _timeForTraсk; }
    private int _timeForTraсk;
    public int salaryForMonth { get => _salaryForMonth; }
    private int _salaryForMonth;
    public int allSalaryForMonth { get => _allSalaryForMonth; }
    private int _allSalaryForMonth;
    public int InstNum { get => _instNum; set { _instNum = value; } }
    private int _instNum;
    public int RoomsNum { get => _roomsNum; set { _roomsNum = value; } }
    private int _roomsNum;

    public const int instPerRoom = 2;
    public const int peoplePerRoom = 2;

    public StudioGenerator(string name, string address, int moneyForTrack, int timeForTraсk, int salaryForMonth)
    {
      _money = 99999999;
      _name = name;
      _address = address;
      _people = 10;
      _moneyForTrack = moneyForTrack;
      _timeForTraсk = timeForTraсk;
      _salaryForMonth = salaryForMonth;

      _allSalaryForMonth = _salaryForMonth * _people;
      _instNum = 10;
      _roomsNum = 5;
    }

    public static StudioGenerator operator ++(StudioGenerator studio)
    {
      if (studio._money < 20000)
      {
        MessageBox.Show("У студії немає грошей на виконання цієї операції!");
        return studio;
      }

      studio._money -= 20000;
      studio.RoomsNum++;
      studio.InstNum += instPerRoom;
      studio.people += peoplePerRoom;

      MessageBox.Show("Нова кімната збудована!");
      return studio;
    }
    public static StudioGenerator operator --(StudioGenerator studio)
    {
      if (studio.RoomsNum == 0)
      {
        MessageBox.Show("Немає кімнат!");
        return studio;
      }

      studio.RoomsNum--;
      MessageBox.Show("Кімната розвалена. Ну чому??????");
      return studio;
    }
    public int this[int i]
    {
      get
      {
        switch (i)
        {
          case 0: return _salaryForMonth;
          case 1: return _money;

          default: throw new ArgumentException("i");
        }
      }
    }
    public object Clone()
    {
      return new StudioGenerator(_name, _address, _moneyForTrack, _timeForTraсk, _salaryForMonth);
    }
    public void Hire()
    {
      if (_money < salaryForMonth)
      {
        MessageBox.Show("Немає грошей щоб купити інструмент");
        return;
      }

      _money -= salaryForMonth;
      _people++;
    }
    public void Dismiss()
    {
      if (_people == 0)
      {
        MessageBox.Show("Немає працівників щоб їх звільнювати");
        return;
      }

      if (_people - 1 < _roomsNum * instPerRoom)
      {
        MessageBox.Show("Недостатньо працівників!");
        return;
      }

      _people--;
    }
    public void BuyInstrument()
    {
      if (_money < 5000)
      {
        MessageBox.Show("Немає грошей щоб купити інструмент");
        return;
      }

      _money -= 5000;
      InstNum++;
    }
    public void DeleteInstrument()
    {
      if (InstNum == 0)
      {
        MessageBox.Show("Немає інструментів!");
      }
      if (InstNum - 1 < _roomsNum * 2)
      {
        MessageBox.Show("Недостатньо інструментів для обслуговування " + _roomsNum + " кімнат! 2 інструмент = 1 кімната");
      }

      InstNum--;
    }
    public void CreateRoom()
    {
      if ( 
        (_instNum - _roomsNum * instPerRoom > 1 && _people - _roomsNum * instPerRoom > 1) 
        || _roomsNum == 0
      )
      {
        _roomsNum++;
        MessageBox.Show("Збудована нова кімната!");
        return;
      }
      else
      {
        if (_instNum - _roomsNum * instPerRoom <= 1)
        {
          MessageBox.Show("Неможливо збудувати кімнату, бо немає інструментів для неї!");
        }

        if (_people - _roomsNum * peoplePerRoom <= 1)
        {
          MessageBox.Show("Неможливо збудувати кімнату, бо немає працівників для неї!");
        }
      }
    }
    public void DeleteRoom()
    {
      if (_roomsNum == 0)
      {
        MessageBox.Show("Немає кімнат!");
        return;
      }
      _roomsNum--;
    }
    public void AddBalance(int moneyAmount)
    {
      _money += moneyAmount;
    }
  }
}
