using System;
using static System.Console;
namespace Airlines
{
    public class Passenger
    {
        public Passenger()
        {
        }
        private string[] lname, fname;
        private int[] security_number, temp_arr;
        private string departure_time = "19:00 PM", departure_date="01 Jun 2019", flight_no= "AIR745",times;
        int gate = 8;

        public string[] Lname
        {
            get { return lname; }
            set { lname = value; }
        }

        public string[] Fname
        {
            get { return fname; }
            set { fname = value; }
        }


        public string Departure_time
        {
            get { return departure_time;}

        }

        public string Departure_date
        {
            get { return departure_date;}
        }

        public int Gate
        {
            get { return gate;}
        }
        public string Flight_no
        {
            get { return flight_no;}
        }

        public int[] Security_number
        {
            get { return security_number; }
        }

        public int[] Temp_arr
        {
            get { return temp_arr; }
        }

        public string Time
        {
            get { return times;}
            set { times = value;}

        }


        public Passenger(int arraysize) //constructor to insitalise array
        {
            this.fname = new string[arraysize];
            this.lname = new string[arraysize];

            this.security_number = new int[arraysize];
            this.temp_arr = new int[arraysize];


        }

        public void empty_seats() //fucntion to check empty seats
        {
            for (int i = 0; i < 40; i++)
            {
                if (this.fname[i] == null)
                {

                    WriteLine("seat {0} ", i + 1);
                }



            }
        }

        public int security_no(int min, int max) //random function to generate random numbers 
        {
            Random rnd = new Random();

            return rnd.Next(min, max);

        }

        public void passenger_list() //function to generate passenger list
        {
            int j = 0;
            for (int i =0; i<40; i++)
                if(this.fname[i]!=null)
                {
                    WriteLine("Passenger list is displayed below");
                    WriteLine("Boarding pass {0}", j + 1);
                    WriteLine("First name : {0}", this.fname[i]);
                    WriteLine("Last name : {0}", this.lname[i]);
                    WriteLine("Seat number: {0}", i+1);
                    WriteLine("Security number: {0}", this.security_number[i]);
                    WriteLine();
                    WriteLine("*************--------------------*************");
                    j++;
                }

        }

        public string truncate(string mystring) // function to truncate name except first five letters
        {
            if (mystring.Length > 5)
                mystring = mystring.Substring(0, 5);
            return mystring;
        }


        public void boarding_pass() // Function to issue boarding pass to all the passengers 
        {
            int k = 0;
            for (int i =0; i<40; i++)
            {

                if(this.fname[i]!=null)
                {
                    WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    WriteLine("\t\t\t\t\t\t\tBoarding pass");
                    Write("Name: {0,4} {1,4} {2,2}", this.fname[i], this.lname[i], "|");
                    Write("Seat: {0,4} {1,2}", i + 1, "|");
                    Write("Departure Time: {0,4} {1,2}", this.departure_time, "|");
                    Write("Departure Date: {0,4} {1,2}", this.departure_date, "|");
                    Write("Security: {0,4} {1,2}", this.security_number[i], "|");
                    Write("Flight: {0,4} {1,2}", this.flight_no, "|");
                    Write("TIme: {0,6} {1,2}", this.times, "|");
                    Write("Gate: {0,4}", this.gate);
                    WriteLine();

                    k++;

                }
                else if(k==0 && i==39)
                {
                    WriteLine("CANNOT ISSUE A BOARDING PASS! ALL SEATS ARE EMPTY.");
                }
               
            }
        }
        public int Int_check(string input) // function to check if the input is integer or not
        {
            int number = 0;
            bool valid = false;
            while(valid == false)
            {

                if (int.TryParse(input, out number))
                {
                    valid = true;

                }
                else
                {
                    WriteLine("Wrong input, please enter a valid number");
                    input = ReadLine();

                }

            }
            return number;

        }
        public int seat_check(string[] booked, int seat) // function to check if the seat entered is empty or not
        {
            bool value = false;
            seat = seat - 1;
            while (value == false) 
            { 
            for (int i = 0; i < booked.Length; i++)
            {
                    if (booked[i] == null && seat == i)
                    value = true;

            }
                if (value == false)
                {
                    WriteLine("Seat has already been booked, please select an empty seat");
                    string resp = ReadLine();

                    //int.TryParse(ReadLine(), out seat);
                    seat = Int_check(resp);
                    seat = seat - 1;
                }
        }
            return seat + 1;
        }
        public string time()    // function to get time
        {
            DateTime now = DateTime.Now;
            string times = Convert.ToString(now);
            return times;


        }


    }
    }

