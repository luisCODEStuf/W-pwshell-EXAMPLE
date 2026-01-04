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
        public string? SumValueRefered(Variable variable)
        {  
            if (variable == null)
            {
                return null;
            }
            _value += variable.GetValue();
            return "operation sucessfully done";
        }
        public void SubtractValue(int subValue)
        {
            _value -= subValue;
        }
        public string? SubtractValueRefered(Variable variable)
        {  
            if (variable == null)
            {
                return null;
            }
            _value -= variable.GetValue();
            return "operation sucessfully done";
        }
        public void MultiplyValue(int mulValue)
        {
            _value *= mulValue;
        }
        public string? MultiplyValueRefered(Variable variable)
        {  
            if (variable == null)
            {
                return null;
            }
            _value *= variable.GetValue();
            return "operation sucessfully done";
        }
        public void DivideValue(int divValue)
        {
            if (divValue != 0)
            {
                _value /= divValue;
            }
        }
        public string? DivideValueRefered(Variable variable)
        {  
            if (variable == null || variable.GetValue() == 0)
            {
                return null;
            }
            _value /=variable.GetValue();
            return "operation sucessfully done";
        }


    } 

}