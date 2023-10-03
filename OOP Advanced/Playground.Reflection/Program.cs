using Playground.Reflection.Interfaces;
using System.Reflection;

namespace Playground.Reflection
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();

            var currentAssembly = Assembly.GetExecutingAssembly();

            List<object> instances = new List<object>();

            PrintMenu(writer);
            int operation = reader.ReadNumber("Enter the selected option: ");
            while (operation != 0)
            {
                if (operation == 1)
                {
                    var createdInstance = CreateInstanceDynamically(currentAssembly, reader, writer);
                    if (createdInstance is not null) instances.Add(createdInstance);
                }
                else if (operation == 2) ShowInstances(instances, writer);
                else if (operation == 3) AccessPropertyDynamically(instances, reader, writer);

                writer.WriteNewLine();
                PrintMenu(writer);
                operation = reader.ReadNumber("Enter the selected option: ");
            }
        }

        private static void PrintMenu(IWriter writer)
        {
            writer.WriteText("Options:");
            writer.WriteNewLine();

            writer.WriteText("1. Create an instance of a type.");
            writer.WriteNewLine();

            writer.WriteText("2. Show instances.");
            writer.WriteNewLine();
            
            writer.WriteText("3. Access the property of an instance.");
            writer.WriteNewLine();
            
            writer.WriteText("0. Exit");
            writer.WriteNewLine();
        }

        private static object? CreateInstanceDynamically(Assembly assembly, IReader reader, IWriter writer)
        {
            string input = reader.ReadString("Enter the (full) name of the type that you want to instantiate: ");

            var type = assembly.GetType(input, throwOnError: false, ignoreCase: true);
            if (type is null)
            {
                writer.WriteText("The specified type is not found.");
                writer.WriteNewLine();

                return null;
            }

            writer.WriteText($"Found the following type: {type.FullName}");
            writer.WriteNewLine();

            var constructors = type.GetConstructors();
            ShowConstructors(constructors, writer);

            if (constructors.Length == 0)
            {
                writer.WriteText("The specified type cannot be instantiated.");
                writer.WriteNewLine();

                return null;
            }

            int constructorIndex;
            if (constructors.Length == 1) constructorIndex = 0;
            else
            {
                constructorIndex = reader.ReadNumber("Enter the (zero-based) index of constructor to use: ");

                if (constructorIndex < 0 || constructorIndex >= constructors.Length)
                {
                    writer.WriteText("This constructor index is invalid!");
                    writer.WriteNewLine();

                    return null;
                }
            }

            var constructor = constructors[constructorIndex];
            var parameters = constructor.GetParameters();
            var arguments = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].ParameterType == typeof(string))
                {
                    arguments[i] = reader.ReadString($"Enter value for the \"{parameters[i].Name}\" parameter: ");
                }
                else
                {
                    writer.WriteText("This parameter type is unsupported");
                    writer.WriteNewLine();
                    return null;
                }
            }

            // return Activator.CreateInstance(type, arguments);
            return constructor.Invoke(arguments);
        }

        private static void AccessPropertyDynamically(List<object> instances, IReader reader, IWriter writer)
        {
            if (instances.Count == 0)
            {
                writer.WriteText("There are no dynamically created instances.");
                writer.WriteNewLine();

                return;
            }

            ShowInstances(instances, writer);
            int instanceIndex;
            if (instances.Count == 1) instanceIndex = 0;
            else
            {
                instanceIndex = reader.ReadNumber("Enter the (zero-based) index of the instance to use: ");

                if (instanceIndex < 0 || instanceIndex >= instances.Count)
                {
                    writer.WriteText("This instance index is invalid!");
                    writer.WriteNewLine();

                    return;
                }
            }

            var instanceType = instances[instanceIndex].GetType();
            var properties = instanceType.GetProperties();

            writer.WriteText($"There are {properties.Length} properties.");
            writer.WriteNewLine();

            if (properties.Length == 0) return;

            for (int i = 0; i < properties.Length; i++)
            {
                writer.WriteText($"- {properties[i].PropertyType} {properties[i].Name}");
                writer.WriteNewLine();
            }

            string propertyName = reader.ReadString("Enter the name of the property to access: ");
            var property = instanceType.GetProperty(propertyName);
            if (property is null)
            {
                writer.WriteText("This property is not found.");
                writer.WriteNewLine();

                return;
            }

            var value = property.GetValue(instances[instanceIndex]);

            if (value is null) writer.WriteText("<null>");
            else writer.WriteText(value.ToString());
            writer.WriteNewLine();
        }

        private static void ShowConstructors(ConstructorInfo[] constructors, IWriter writer)
        {
            writer.WriteText($"Found {constructors.Length} constructor(s):");
            writer.WriteNewLine();

            foreach (var constructor in constructors)
            {
                var parameters = constructor.GetParameters();
                var parametersInfo = parameters.Select(x => $"{x.ParameterType} {x.Name}");
                writer.WriteText($"- ({string.Join(", ", parametersInfo)})");
                writer.WriteNewLine();
            }
        }

        private static void ShowInstances(List<object> instances, IWriter writer)
        {
            writer.WriteText($"There are {instances.Count} available instances.");
            writer.WriteNewLine();

            for (var i = 0; i < instances.Count; i++)
            {
                writer.WriteText($"- {instances[i].ToString()}");
                writer.WriteNewLine();
            }
        }

        private static void ListTypesWithSameNameProperties(Assembly assembly)
        {
            Dictionary<string, List<Type>> typesByPropertyName = new Dictionary<string, List<Type>>();

            foreach (var type in assembly.GetTypes())
            {
                foreach (var property in type.GetProperties())
                {
                    if (!typesByPropertyName.ContainsKey(property.Name))
                        typesByPropertyName[property.Name] = new List<Type>();

                    typesByPropertyName[property.Name].Add(type);
                }
            }

            foreach (var (propertyName, containingTypes) in typesByPropertyName.Where(x => x.Value.Count > 1))
            {
                Console.WriteLine($"The property {propertyName} is contained in {containingTypes.Count} types: {string.Join(", ", containingTypes)}");
            }
        }

        private static void ShowTypesInfo(Assembly assembly)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            var assemblyName = assembly.GetName();
            Console.WriteLine($"Types in {assemblyName.Name}:");
            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine(type);

                Console.WriteLine("Properties:");
                foreach (var property in type.GetProperties(bindingFlags))
                    Console.WriteLine($"- {property.PropertyType} {property.Name}");

                Console.WriteLine("Methods:");
                foreach (var method in type.GetMethods(bindingFlags))
                    Console.WriteLine($"- {method.ReturnType} {method.Name}");

                Console.WriteLine("Fields:");
                foreach (var field in type.GetFields(bindingFlags))
                    Console.WriteLine($"- {field.FieldType} {field.Name}");

                Console.WriteLine();
            }
        }
    }
}