namespace OOP
{
    public class PersonDemo
    {
        public static void Run()
        {
            Console.WriteLine("=== Person Class Demo ===\n");

            try
            {
                // Create persons using different constructors
                Console.WriteLine("1. Creating persons with different constructors:");
                Console.WriteLine("================================================");

                var person1 = new Person("Alice Johnson", 25);
                var person2 = new Person("Bob Smith", new DateTime(1990, 5, 15));
                var person3 = new Person(); // Default constructor

                // Display person information
                Console.WriteLine("\n2. Displaying person information:");
                Console.WriteLine("==================================");

                Console.WriteLine("Person 1:");
                person1.PersonInfo();

                Console.WriteLine("\nPerson 2:");
                person2.PersonInfo();

                Console.WriteLine("\nPerson 3 (default):");
                person3.PersonInfo();

                // Test greeting method
                Console.WriteLine("\n3. Testing greeting method:");
                Console.WriteLine("===========================");
                Console.WriteLine(person1.Greet());
                Console.WriteLine(person2.Greet());
                Console.WriteLine(person3.Greet());

                // Test birthday celebration
                Console.WriteLine("\n4. Celebrating birthdays:");
                Console.WriteLine("=========================");
                person1.CelebrateBirthday();
                person2.CelebrateBirthday();
                person3.CelebrateBirthday();

                // Test adult status
                Console.WriteLine("\n5. Checking adult status:");
                Console.WriteLine("=========================");
                Console.WriteLine($"{person1.Name} is adult: {person1.IsAdult}");
                Console.WriteLine($"{person2.Name} is adult: {person2.IsAdult}");
                Console.WriteLine($"{person3.Name} is adult: {person3.IsAdult}");

                // Test ToString override
                Console.WriteLine("\n6. Testing ToString override:");
                Console.WriteLine("=============================");
                Console.WriteLine(person1.ToString());
                Console.WriteLine(person2.ToString());
                Console.WriteLine(person3.ToString());

                // Test equality
                Console.WriteLine("\n7. Testing equality:");
                Console.WriteLine("===================");
                var person4 = new Person("Alice Johnson", new DateTime(1998, 1, 1));
                Console.WriteLine($"person1 equals person4: {person1.Equals(person4)}");

                // Test error handling
                Console.WriteLine("\n8. Testing error handling:");
                Console.WriteLine("==========================");

                Console.WriteLine("Trying to create person with null name...");
                try
                {
                    var invalidPerson = new Person(null!, 30);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Caught expected exception: {ex.Message}");
                }

                Console.WriteLine("\nTrying to set negative age...");
                try
                {
                    person1.Age = -5;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Caught expected exception: {ex.Message}");
                }

                Console.WriteLine("\nTrying to set future date of birth...");
                try
                {
                    person1.DateOfBirth = DateTime.Now.AddYears(1);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Caught expected exception: {ex.Message}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            Console.WriteLine("\n=== Person Demo Complete ===");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}