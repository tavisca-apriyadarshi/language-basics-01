using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(String Equation){
            int MissingNumber = -1;
            int FirstNumber=0, SecondNumber=0, MultiplicationResult=0;
            String FirstNumberString="", SecondNumberString="", MultiplicationResultString="";
            int MultiplicationPosition = Equation.IndexOf("*");
            int equalsPosition = Equation.IndexOf("=");
            
            MultiplicationResultString = Equation.Substring(equalsPosition+1);
            SecondNumberString = Equation.Substring(MultiplicationPosition+1, equalsPosition-MultiplicationPosition-1);
            FirstNumberString = Equation.Substring(0, MultiplicationPosition);

            //Converting FirstNumberString SecondNumberString MultiplicationResultString into no.
            if(FirstNumberString.IndexOf('?')<0){
                FirstNumber = Int32.Parse(FirstNumberString);
            }
            if(SecondNumberString.IndexOf('?')<0){
                SecondNumber = Int32.Parse(SecondNumberString);
            }
            if(MultiplicationResultString.IndexOf('?')<0){
                MultiplicationResult = Int32.Parse(MultiplicationResultString);
            }

            //Checking for missing digit
            if(MultiplicationResultString.IndexOf('?')>=0){
                MissingNumber = missingDigitInResult(FirstNumber,SecondNumber,MultiplicationResultString);
            }

            if(FirstNumberString.IndexOf('?')>=0){
                MissingNumber = missingDigitInFirstNumber(MultiplicationResult, SecondNumber, FirstNumberString);
            }

            if(SecondNumberString.IndexOf('?')>=0){
                MissingNumber = missingDigitInSecondNumber(MultiplicationResult, FirstNumber, SecondNumberString);
            }


            return MissingNumber;
        }

        public static int missingDigitInResult(int FirstNumber, int SecondNumber, string MultiplicationResultString){
            int MissingNumber = -1;
            int answer = FirstNumber*SecondNumber;
                String answerString = answer.ToString();
                int position = MultiplicationResultString.IndexOf('?');
                char result = answerString[position];
                MissingNumber = result - '0';
                String verifyAnswer = MultiplicationResultString.Replace('?', result);

                if(MultiplicationResultString.IndexOf('?')==0){
                    if(answerString.Equals(MultiplicationResultString.Substring(1))){
                        MissingNumber=-1;
                    }
                }
                if(answerString.Equals(verifyAnswer)){
                    MissingNumber = result - '0';
                }else{
                    MissingNumber = -1;
                }

                return MissingNumber;
        }

        public static int missingDigitInFirstNumber(int MultiplicationResult, int SecondNumber, string FirstNumberString){
            int MissingNumber = -1;
            if(SecondNumber != 0){
                    int answer = MultiplicationResult/SecondNumber;
                    String answerString = answer.ToString();
                    int position = FirstNumberString.IndexOf('?');
                    char result = answerString[position];
                    MissingNumber = result - '0';

                    if(FirstNumberString.IndexOf('?')==0){
                        if(answerString.Equals(FirstNumberString.Substring(1))){
                        MissingNumber=-1;
                        }
                    }
                    if(FirstNumberString.IndexOf('?')==FirstNumberString.Length-1){
                        if(answerString.Equals(FirstNumberString.Substring(0, FirstNumberString.Length-2))){
                        MissingNumber=-1;
                        }else {
                            String firstNumberString = FirstNumberString.Substring(0,FirstNumberString.Length-1);
                            int firstNumber = Int32.Parse(firstNumberString);
                            for(int x=0; x<10; x++){
                                if(((firstNumber)*10+x)*SecondNumber==MultiplicationResult){
                                    MissingNumber = x;
                                    break;
                                }
                                if((firstNumber*10+x)*SecondNumber!=MultiplicationResult){
                                    MissingNumber=-1;
                                }
                            }
                        }
                    }
                }else{
                    MissingNumber=-1;
                }
                return MissingNumber;
        }

        public static int missingDigitInSecondNumber(int MultiplicationResult, int FirstNumber, string SecondNumberString){
                int MissingNumber = -1;
                if(FirstNumber != 0){
                    int answer = MultiplicationResult/FirstNumber;
                    String answerString = answer.ToString();
                    int position = SecondNumberString.IndexOf('?');
                    char result = answerString[position];
                    MissingNumber = result - '0';

                    if(SecondNumberString.IndexOf('?')==0){
                        if(answerString.Equals(SecondNumberString.Substring(1))){
                        MissingNumber=-1;
                        }
                    }
                    if(SecondNumberString.IndexOf('?')==SecondNumberString.Length-1){
                        if(answerString.Equals(SecondNumberString.Substring(0, SecondNumberString.Length-2))){
                        MissingNumber=-1;
                        }else {
                            String secondNumberString = SecondNumberString.Substring(0,SecondNumberString.Length-1);
                            int secondNumber = Int32.Parse(secondNumberString);
                            for(int x=0; x<10; x++){
                                if(((secondNumber)*10+x)*FirstNumber==MultiplicationResult){
                                    MissingNumber = x;
                                    break;
                                }
                                if((secondNumber*10+x)*FirstNumber!=MultiplicationResult){
                                    MissingNumber=-1;
                                }
                            }
                        }
                    }
                }else{
                    MissingNumber=-1;
                }
                return MissingNumber;
            }


    }
}
