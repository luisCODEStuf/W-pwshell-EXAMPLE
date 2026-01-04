namespace Project
{
    public class SystemOperations
    {   
        public static Variable? ShowList(List<Variable> Lista) 
        {
            foreach (var variable in Lista)
            {
                return variable;
            }
            return null;
        }
        public static string Help()
        {
            return "Available commands:\n" +
                   "CREATE <name> <initialValue> - Create a new variable with the specified name and initial value.\n" +
                   "GET_BY_NAME <name> - Retrieve a variable by its name.\n" +
                   "GET_BY_INDEX <index> - Retrieve a variable by its index in the list.\n" +
                   "CHANGE <name> <newValue> - Change the value of the variable with the specified name.\n" +
                   "SUM <name> <value> - Add the specified value to the variable with the specified name.\n" +
                   "SUBTRACT <name> <value> - Subtract the specified value from the variable with the specified name.\n" +
                   "MULTIPLY <name> <value> - Multiply the variable with the specified name by the specified value.\n" +
                   "DIVIDE <name> <value> - Divide the variable with the specified name by the specified value.";
        }
        public static Variable? GetVariableAtIndex(List<Variable> lista, int index)
        {   
            if (index >= 0 && index < lista.Count)
            {
                return lista[index];
            }
            return null;
        }
        public static int GetVariableByName(List<Variable> lista, string name)
        {   
           int index = lista.FindIndex(v => v.GetName() == name);
           return index;
        }
    }
    class Program
    {   
        public static void Main(string[] args)
        {
           var lista = new List<Variable>();
           while (true)
            {
                Console.Write("C:\\Users\\luis\\Downloads\\teste CSHARP\\MeuProjeto>(--help or /? for help): ");
                string written = Console.ReadLine() ?? string.Empty;
                var parts = written.Split(' ');
                if (string.Equals(parts[0].ToUpper(), "CREATE") && parts.Length == 3 && int.TryParse(parts[2], out int initialValue))
                {   
                    if(string.IsNullOrEmpty(parts[1]))
                    {
                        Console.WriteLine("Variable name cannot be empty.");
                        continue;
                    }
                    Variable variable = new Variable(initialValue, parts[1]);
                    lista.Add(variable);
                    Console.WriteLine($"Variable created with initial value {initialValue} at index {lista.Count - 1}");
                }
                else if (string.Equals(parts[0].ToUpper(), "GET_BY_NAME") && parts.Length == 2)
                {
                    if  (SystemOperations.GetVariableAtIndex(lista, lista.FindIndex(v => v.GetName() == parts[1])) is Variable foundVarByName)
                    {
                        Console.WriteLine($"Found variable: index: {lista.FindIndex(v => v.GetName() == parts[1])}, value: {foundVarByName.GetValue()}");
                    }
                    else
                    {
                        Console.WriteLine("Variable not found.");
                    }
                }
                else if (string.Equals(parts[0].ToUpper(), "GET_BY_INDEX") && parts.Length == 2 && int.TryParse(parts[1], out int getIndex))
                {
                    if   (SystemOperations.GetVariableAtIndex(lista, getIndex) is Variable foundVar)
                    {
                        Console.WriteLine($"Found variable at index {getIndex}: name: {foundVar.GetName()} ,value: {foundVar.GetValue()}");
                    }
                    else
                    {
                        Console.WriteLine("Variable not found at the specified index.");
                    }
                }
                else if(string.Equals(parts[0].ToUpper(), "--help") || string.Equals(parts[0].ToUpper(), "/?"))
                {
                    Console.WriteLine(SystemOperations.Help());
                }
                else if (parts.Length == 3 && int.TryParse(parts[2], out int value))
                {   
                    int index = SystemOperations.GetVariableByName(lista, parts[1]);
                    if (index != -1)
                    {
                        switch (parts[0].ToUpper())
                        {
                            case "CHANGE":
                                lista[index].ChangeValue(value);
                                Console.WriteLine($"Value at index {index} changed to {value}");
                                break;
                            case "SUM":
                                lista[index].SumValue(value);
                                Console.WriteLine($"Value at index {index} increased by {value}");
                                break;
                            case "SUBTRACT":
                                lista[index].SubtractValue(value);
                                Console.WriteLine($"Value at index {index} decreased by {value}");
                                break;
                            case "MULTIPLY":
                                lista[index].MultiplyValue(value);
                                Console.WriteLine($"Value at index {index} multiplied by {value}");
                                break;
                            case "DIVIDE":
                                if (value != 0)
                                {
                                    lista[index].DivideValue(value);
                                    Console.WriteLine($"Value at index {index} divided by {value}");
                                }
                                else
                                {
                                    Console.WriteLine("Cannot divide by zero.");
                                }
                                break;
                            default:
                                Console.WriteLine("Unknown command.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid index.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command or parameters.");
                }
            }

        }
    }
}