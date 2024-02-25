using MySql.Data.MySqlClient;
using System.Linq.Expressions;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost;Database=geography;Uid=root;Pwd=root;";
            using MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            Console.Write("Enter the name of the requested country: ");
            string requestedName = Console.ReadLine();

            Country? country = GetCountry(requestedName, connection);
            if (country is null) Console.WriteLine("This country was not found.");
            else Console.WriteLine($"The requested country has the following code: {country.Code}");

            long countriesCount = GetCountriesCount(connection);
            Console.WriteLine(countriesCount);

            List<Country> countries = GetCountries(connection);
            Func<Country, bool> hasCurrencyCodeFunc = c => c.CurrencyCode != null;
            Expression<Func<Country, bool>> hasCurrencyCodeExpression = c => c.CurrencyCode != null;

            for (int i = 0; i < countries.Count; i++)
            {
                Console.WriteLine($"Country code: {countries[i].Code}");
                Console.WriteLine($"Country name: {countries[i].Name}");
                Console.WriteLine($"ISO code: {countries[i].IsoCode}");
                Console.WriteLine($"Currency code: {countries[i].CurrencyCode ?? "<null>"}");
                Console.WriteLine($"Continent code: {countries[i].ContinentCode}");
                Console.WriteLine($"Population: {countries[i].Population}");
                Console.WriteLine($"Area: {countries[i].Area}");
                Console.WriteLine($"Capital: {countries[i].Capital}");
                Console.WriteLine();
            }
        }

        static Country? GetCountry(string name, MySqlConnection connection)
        {
            using MySqlCommand command = new MySqlCommand("select * from countries where country_name = @name", connection);
            command.Parameters.AddWithValue("@name", name);

            using MySqlDataReader reader = command.ExecuteReader();
            if (!reader.Read()) return null;

            var country = ReadCountryValues(reader);
            return country;
        }

        static List<Country> GetCountries(MySqlConnection connection)
        {
            using MySqlCommand command = new MySqlCommand("select * from countries", connection);

            using MySqlDataReader reader = command.ExecuteReader();

            List<Country> result = new List<Country>();
            while (reader.Read())
            {
                var country = ReadCountryValues(reader);
                result.Add(country);
            }

            return result;
        }

        static Country ReadCountryValues(MySqlDataReader reader)
        {
            var country = new Country
            {
                Code = reader.GetFieldValue<string>(0),
                IsoCode = reader.GetFieldValue<string>(1),
                Name = reader.GetFieldValue<string>(2),
                ContinentCode = reader.GetFieldValue<string>(4),
                Population = reader.GetFieldValue<long>(5),
                Area = reader.GetFieldValue<long>(6),
                Capital = reader.GetFieldValue<string>(7)
            };

            if (!reader.IsDBNull(3))
                country.CurrencyCode = reader.GetFieldValue<string>(3);

            return country;
        }

        static long GetCountriesCount(MySqlConnection connection)
        {
            using MySqlCommand command = new MySqlCommand("select count(*) from countries", connection);

            return (long)command.ExecuteScalar();
        }
    }
}
