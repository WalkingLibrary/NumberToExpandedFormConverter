using System;
using System.Text.RegularExpressions;

namespace Dot_NET_Solutions_Developer_Question_7
{

    

   



    internal class Program
    {

       
        
        private static string[] _oneThroughTen = new string[] {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
        
        private static string[] _TenThroughNinteen = new string[] {
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen",
            "Nineteen"};
        
        private static string[] _TensPlaces = new string[] {
            "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety",};


        
        
        
        public static void Main(string[] args)
        {
            try
            {

            
            if (args.Length < 1)
            {
                Console.Out.WriteLine("You Did not Enter A number.\nUsage: ~Dot_NET_Solutions_Developer_Question_7.exe 55");
                return;
            }
            
            
            /*
             * Process for Converting User Input
             * Read in User's Number
             * Validate Users Input
             * Build Output String
             * 
             */
            
            
            //Read in User's Number
            string usersInput = args[0];


            //Validate Users Input
            Regex onlyNumbersPattern = new Regex("([-]{1}?)\\d*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            Match matches = onlyNumbersPattern.Match(usersInput);

            if (!matches.Success)
            {
                Console.Out.WriteLine("Please Enter A Valid Number.");
                return;
            }
            
            //Values used for Iteration
            string absoluteValueOfUsersInput = Math.Abs(Convert.ToInt32(usersInput)) + "";

            if (absoluteValueOfUsersInput.Length > 4)
            {
                Console.Out.WriteLine("The number You Entered was To Big.");
                return;
            }
            
            
            
            /*
             * Build Output String
             * Process for Building the Out Put String
             * Add Special Cases
             * Pair Numbers Place From Left to Right of Absolute value of userinput to Corresponding Expanded Form Number
             * 
             */
            //  

            string expandedNumberForm = "";
            
            
            //Add Special Cases
            //Pair to Negative
            if (usersInput.Contains("-") && Convert.ToInt32(usersInput) != 0)
            {
                expandedNumberForm += "Minus ";
            }
            
            
            //Pair Numbers Place From Left to Right of Absolute value of userinput to Corresponding Expanded Form Number
            //Currently Used For Ones Place Pairing
            int tensPlace = 0;
            
            //Used for adding And 
            bool addedAnd = false;
            
            for (int i = 0 ; i < absoluteValueOfUsersInput.Length; i++)
            {
                NumberPlace currentPlace = (NumberPlace) absoluteValueOfUsersInput.Length - 1 - i;
                int currentNumber = Convert.ToInt32(absoluteValueOfUsersInput.Substring(i, 1));

                
                //ADD the And
                //If and has not been added and the Current number Place is tens or one and the length of the
                //users input is big enough to need it
                if (!addedAnd && (int) currentPlace <= 1 && absoluteValueOfUsersInput.Length > 2)
                {
                    expandedNumberForm += "and ";
                    addedAnd = true;
                }

                //Filter for Place
                switch (currentPlace)
                {
                    case NumberPlace.ONES :
                        //To Pair for the Ones Place we need to Check the Tens Place.
                        
                        //If the Tens Place exists and does not start with one we need to add the ones place
                        if (absoluteValueOfUsersInput.Length <= 1 || (tensPlace != 1))
                        {
                            expandedNumberForm += "" + _oneThroughTen[currentNumber];
                            break;
                        }
                        break;
                    case NumberPlace.TENS:
                        //If the Tens Place Starts with a 1 we need to Pair to Teens
                        
                        tensPlace = currentNumber;
                        if (currentNumber == 1)
                        {
                            int onesPlace = Convert.ToInt32(absoluteValueOfUsersInput.Substring(i + 1, 1));
                            expandedNumberForm += "" + _TenThroughNinteen[onesPlace] ;
                            break;
                        }
                        
                        //We Don't Pronounce anything for 0 
                        if (currentNumber != 0)
                        {
                            expandedNumberForm += "" + _TensPlaces[currentNumber] + " ";
                        }
                        break;
                    case NumberPlace.HUNDEREDS :
                        
                        //If it's Zero we don say anything
                        if (currentNumber == 0)
                        {
                            break;
                        }
                        expandedNumberForm += "" + _oneThroughTen[currentNumber] + " hundred ";
                        break;
                    case NumberPlace.THOUSANDS:
                        
                        //Same here we don't say any thing if it's zero
                        if (currentNumber == 0)
                        {
                            break;
                        }
                        expandedNumberForm += "" + _oneThroughTen[currentNumber] + " thousand ";
                        break;
                    default:
                        expandedNumberForm += "Number("+ currentNumber + ")";
                        break;
                
                }
            }
            
            Console.Out.WriteLine("Your Number is: " + expandedNumberForm);
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.Out.WriteLine("There Was An Error Running The Program Sorry");
            }
        }

        internal enum NumberPlace
        {
            ONES, TENS, HUNDEREDS, THOUSANDS

        }
    }
    
}