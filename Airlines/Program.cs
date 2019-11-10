using System;
using static System.Console;
namespace Airlines
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            string mystring, res, cusseat;
            int response, end= 0, custres, custseat=0,number,airresp,booked_seats =0;
            Passenger pass = new Passenger(40); // creating pass object for passenger class and calling a constructor
            while(end!=999)// While loop for continuosly accepting passengers
            {
                bool valid = false;
                if (booked_seats==40) // Notify Airline staff if the plane is at maximum capacity
                {
                    WriteLine("All the seats have been taken, Airplane is at maximum capacity!");
                }
                WriteLine("Do you want a boarding pass Y or press 999 to exit");
                res = ReadLine();
                if (res == "999")
                    break;
                else if (res == "Y" || res == "y")
                {
                    WriteLine("Press 1 for Airline Staff member, 2 for Passenger");
                    // int.TryParse(ReadLine(), out response);
                    res = ReadLine();
                    response = pass.Int_check(res);
                    switch (response)
                    {
                        case 1:
                            Clear();
                            WriteLine("You are selected as Airline Staff member");
                            WriteLine("Press 1 to see available seats\nPress 2 to see passenger list\nPress 3 to issue boarding pass");
                            res = ReadLine();
                            airresp = pass.Int_check(res); // check if the number is integer or not
                            //int.TryParse(ReadLine(), out airresp);
                            switch (airresp)
                            {
                                case 1:
                                    if (booked_seats <= 40)
                                    {
                                        WriteLine("Available seats are :");
                                        pass.empty_seats();
                                    }
                                    else 
                                    WriteLine("All seats are booked, no empty seats left");
                                    break;
                                case 2:
                                    if (booked_seats == 0)
                                        WriteLine("No passengner has booked a seat yet");
                                    else
                                    pass.passenger_list();
                                    break;
                                case 3:
                                    if (booked_seats == 0)
                                        WriteLine("No passengner has booked a seat yet, cannot issue a boarding pass!");
                                    else
                                    pass.boarding_pass();
                                    break;


                            }
                            break;
                        case 2:
                            Clear();
                            WriteLine("You are selected as a passanger");
                            WriteLine("Press 1 to check empty seats, 2 to exit ");
                            res = ReadLine();
                            //int.TryParse(ReadLine(), out custres);
                            custres = pass.Int_check(res);
                            switch (custres)
                            {
                                case 1:
                                    if (booked_seats == 40)
                                        WriteLine("No empty seats left");
                                    else
                                    {
                                        WriteLine("Empty Seats are displayed below");
                                        pass.empty_seats();
                                        while (valid == false)  // Loop to check if number of seats required to book isn't greater than available seats
                                        { 
                                        WriteLine("How mnay seats do you want to book");
                                        cusseat = ReadLine();
                                        custseat = pass.Int_check(cusseat);
                                        int q =(custseat + booked_seats); 
                                        if ((40-q) < 0)         // if block to compare total seats available and customer's required number of seats
                                        {
                                            WriteLine("Only {0} seats are left, can't book {1} seats", 40 - booked_seats, cusseat);
                                        }
                                        else
                                            valid = true;
                                    }
                                        booked_seats = booked_seats + custseat; //increment total number of seats
                                    //int.TryParse(ReadLine(), out custseat);
                                    for (int i = 0; i < custseat; i++)
                                    {
                                        pass.Time = pass.time();// Time function to stamp system time on the boarding pass
                                        WriteLine("select seat {0}", i + 1);
                                        cusseat = ReadLine();
                                        //int.TryParse(ReadLine(), out number);
                                        number = pass.Int_check(cusseat);
                                        number = pass.seat_check(pass.Fname,number);
                                        WriteLine("Enter the First name");
                                        mystring = ReadLine();
                                        pass.Fname[number - 1] = pass.truncate(mystring);
                                        WriteLine("Enter the last name");
                                        mystring = ReadLine();
                                        pass.Lname[number - 1] = pass.truncate(mystring);
                                        pass.Security_number[number - 1] = pass.security_no(30000, 999999);
                                        pass.Temp_arr[i] = number - 1; // stroing indexes of booked seats in Temp array to issue boarding pass after booking
                                    }
                                    Clear();
                                        for (int i = 0; i < custseat; i++) // issue boarding pass to the passengers.
                                        {
                                            WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                            WriteLine("\t\t\t\t\t\t\tBoarding pass {0,15}", i + 1);
                                            int j = pass.Temp_arr[i];
                                            Write("Name: {0,4} {1,4} {2,2}", pass.Fname[j], pass.Lname[j], "|");
                                            Write("Seat: {0,4} {1,2}", j + 1, "|");
                                            Write("Departure Time: {0,4} {1,2}", pass.Departure_time, "|");
                                            Write("Departure Date: {0,4} {1,2}",pass.Departure_date,"|");
                                            Write("Security: {0,4} {1,2}", pass.Security_number[j], "|");
                                            Write("Flight: {0,4} {1,2}", pass.Flight_no, "|");
                                            Write("TIme: {0,6} {1,2}", pass.Time, "|");
                                            Write("Gate: {0,4}", pass.Gate);
                                            WriteLine();

                                    }
                                    }

                                    break;

                                case 2:
                                    break;

                            }
                            break;

                    }
                }



                WriteLine();

            }

            ReadKey();

        }// End of Main function
    }// End Of Class
}// End Of Namespace
