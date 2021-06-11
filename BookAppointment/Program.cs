using System;

namespace BookAppointment
{
    class Program
    {
        public static string[] BookAppoint(int age)
        {
            int age_category = 0;
            string[] locations = { "1.Region of Waterloo Public Health website", "2.A participating pharmacy", "3.Walmart pharmac", "1.Wellington-Dufferin-Guelph Health Unit website", "2.A participating pharmacy", "3.Shopper’s Drug Mar", "1.Brant County Health Unit website", "2.A participating pharmac", "3.ABC pharmacy" };
            string[] return_locations = {"0","0","0" };
            if (age >= 31)
                age_category = 2;
            else if (age >= 19)
                age_category = 1;     
            else
                age_category = 0;
            int j = 3 * age_category;
            for(int i = 0; i < 3; i++)
            {
                return_locations[i] = locations[j];
                j++;
            }
            return return_locations;

        }
        static void Main(string[] args)
        {
            int dose = 0, valid_choice = 0, birth_year = 0, age_category = 0, age=0;
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
                Console.WriteLine("Please enter your Birth year");
                var birth_year1 = Console.ReadLine();
                bool age_check = int.TryParse(birth_year1, out birth_year);
                if(age_check == true)
                {
                    age = 2021 - birth_year;
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
                        valid_choice = 0;
                        int pin_choice = 1;
                        do
                        {
                            Console.WriteLine("Please Enter Pincode");
                            string pincode = Console.ReadLine();

                            if (age >= 31 && pincode == "N3E 3K2")
                            {
                                pin_choice = 0;
                                break;
                            }
                            else if (age >= 19 && age <=30 && pincode == "N1E 3K2")
                            {
                                pin_choice = 0;
                                break;
                            }
                            else if (age >= 12 && pincode == "N2E 3K2")
                            {
                                pin_choice = 0;
                                break;
                            }
                            else
                                Console.WriteLine("We could not match your postal code to a public health unit. Try entering the postal code again.");

                        } while (pin_choice == 1);
                    }
                }
            } while (valid_choice == 1);            

            if (age_category < 3)
            {
                String[] return_locations = Program.BookAppoint(age);
                for (int i = 0; i < return_locations.Length; i++)
                {
                    Console.WriteLine(return_locations[i]);
                }
            }
        }
    }
}
