namespace Project
{
    public class SystemOperations
    {   
        public static string? ShowList(List<Variable> lista) 
        {   
            if(lista == null)
            {
                return null;
            }
            string result = "results: \n";
            foreach (var variable in lista)
            {
                result += $"-----\n name: {variable.GetName()}\n value: {variable.GetValue()}\n index: {lista.IndexOf(variable)}\n-----\n";
            }
            return result;
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
                   "DIVIDE <name> <value> - Divide the variable with the specified name by the specified value.\n"+
                   "SHOW_LIST - Display all variables in the list.\n";
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
                else if (string.Equals(parts[0].ToUpper(), "SHOW_LIST", StringComparison.OrdinalIgnoreCase) && parts.Length == 1)
                {
                    if (lista.Count == 0)
                    {
                        Console.WriteLine("No variables in the list.");
                    }
                    else
                    {
                        Console.WriteLine(SystemOperations.ShowList(lista: lista));
                    }
                }
                else if (parts.Length == 3 || parts.Length == 4)
                {   
                    if(parts.Length == 3 && int.TryParse(parts[2], out int value))
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
                    }
                    if (parts.Length == 4 && parts[1].Equals("-r", StringComparison.CurrentCultureIgnoreCase))
                    {
                        int FIRSTindex = SystemOperations.GetVariableByName(lista, parts[2]);
                        int SECONDindex = SystemOperations.GetVariableByName(lista, parts[3]);
                        if (FIRSTindex != -1 && SECONDindex != -1)
                        {
                            switch (parts[0].ToUpper())
                            {
                                case "SUM":
                                    lista[FIRSTindex].SumValueRefered(lista[SECONDindex]);
                                    Console.WriteLine($"Value at index {FIRSTindex} increased by value at index {SECONDindex}");
                                    break;
                                case "SUBTRACT":
                                    lista[FIRSTindex].SubtractValueRefered(lista[SECONDindex]);
                                    Console.WriteLine($"Value at index {FIRSTindex} decreased by value at index {SECONDindex}");
                                    break;
                                case "MULTIPLY":
                                    lista[FIRSTindex].MultiplyValueRefered(lista[SECONDindex]);
                                    Console.WriteLine($"Value at index {FIRSTindex} multiplied by value at index {SECONDindex}");
                                    break;
                                case "DIVIDE":
                                    if (lista[SECONDindex].GetValue() != 0)
                                    {
                                        lista[FIRSTindex].DivideValueRefered(lista[SECONDindex]);
                                        Console.WriteLine($"Value at index {FIRSTindex} divided by value at index {SECONDindex}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cannot divide by zero.");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Unknown command.");
                                    break;
                        }}
                        else
                        {
                            Console.WriteLine("Invalid index.");
                                Console.WriteLine("Error: Variable not found.");
                        }
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid index.");
                    }
                }else
                {
                    Console.WriteLine("Invalid command or parameters.");
                }
            }

        }
    }
}