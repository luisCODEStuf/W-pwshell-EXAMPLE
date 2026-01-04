namespace Project
{
    public class Variable
    {
        public int _value;
        public string _name;
        public Variable(int value, string name)
        {   
            _value = value;
            _name = name;
        }
        public string GetName()
        {
            return _name;
        }
        public int GetValue()
        {
            return _value;
        }
        public void ChangeValue(int newValue)
        {
            _value = newValue;
        }
        public void SumValue(int addValue)
        {
            _value += addValue;
        }
        public void SubtractValue(int subValue)
        {
            _value -= subValue;
        }
        public void MultiplyValue(int mulValue)
        {
            _value *= mulValue;
        }
        public void DivideValue(int divValue)
        {
            if (divValue != 0)
            {
                _value /= divValue;
            }
        }

    } 

}