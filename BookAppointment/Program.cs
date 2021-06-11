using System;

namespace BookAppointment
{
    public enum pincode { N2E3K2 = 0, N1E3k2, N3R2K6}
    class Program
    {
        public static string[] BookAppoint(int age_category)
        {
            string[] locations = { "1.Region of Waterloo Public Health website", "2.A participating pharmacy", "3.Walmart pharmac", "1.Wellington-Dufferin-Guelph Health Unit website", "2.A participating pharmacy", "3.Shopper’s Drug Mar", "1.Brant County Health Unit website", "2.A participating pharmac", "3.ABC pharmacy" };
            string[] return_locations = {"0","0","0" };
            int j = 3 * age_category;
            for(int i = 0; i < 3; i++)
            {
                return_locations[i] = locations[j];
                j++;
            }
            //string pincode1 = Enum.GetName(typeof(pincode), age_category);

            //return pincode1;
            return return_locations;

        }
        static void Main(string[] args)
        {
            int dose = 0, valid_choice = 0, birth_year = 0, age_category = 0;
            do
            {
                Console.WriteLine("You want to book for my:\n1.First Dose\n2.Second Dose");
                var dose1 = Console.ReadLine();
                bool dose_check = int.TryParse(dose1, out dose);
                if (dose_check == true)
                {
                    if (dose == 1 || dose == 2)
                    {
                        valid_choice = 1;              
                        break;
                    }
                    else
                        Console.WriteLine("Please enter a valid input.");

                }
                else
                    Console.WriteLine("Please Enter valid choice");

            } while (valid_choice == 0);

            do
            {
                Console.WriteLine("Please Enter you pincode");
                string pincode1 = Console.ReadLine();

                Console.WriteLine("Please enter your Birth year");
                var birth_year1 = Console.ReadLine();
                bool age_check = int.TryParse(birth_year1, out birth_year);
                if(age_check == true)
                {
                    int age = 2021 - birth_year;
                    if (birth_year < 1900)
                    {
                        Console.WriteLine("Invalid birth year. Please try again.");
                        break;
                    }
                    else if (age < 12)
                    {
                        Console.WriteLine("You are not currently eligible to book an appointment.");
                        valid_choice = 0;
                        age_category = 3;
                        break;
                    }
                    else
                    {
                        if (age >= 31)
                        {
                            age_category = 2;
                            valid_choice = 0;
                        }
                        else if(age >= 19)
                        {
                            age_category = 1;
                            valid_choice = 0;
                        }
                        else
                        {
                            age_category = 0;
                            valid_choice = 0;
                        }
                    }

                }
            } while (valid_choice == 1);

            if (age_category < 3)
            {
                String[] return_locations = Program.BookAppoint(age_category);
                string pincode = Enum.GetName(typeof(pincode), age_category);
                Console.WriteLine("Pincode: ", pincode);
                for (int i = 0; i < return_locations.Length; i++)
                {
                    Console.WriteLine(return_locations[i]);
                }
            }
        }
    }
}
