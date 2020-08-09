using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assinment_Task_2_quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            int HighestScore = 51;// The Highest score Possible.
            int HighestQuestionScore = 10;// The highest Question score possible.
            int OverallPlayerScore = 0; // the players overall score.
            
            //Question array
            String[] Questions = {"The second month of the Year is ...","When you have made your mind up, you have ...","If something is not boring, it is ...","Not all the time but ...","Not the same but"};
            //Anwser Array
            String[] Anwsers = {"February","Decided","Interesting","Sometimes","Different"};

            //for the ShowFeedback Function

            int[] IsRight = {0 ,0 ,0 ,0 ,0};//This stores Whether a Anwser is right or wrong
            String[] userputs = {"","","","",""};// stores the users input in this variable
            
            //Functions

            //Intro Message

            void Intromessage(){
                
                // for the user
                Console.WriteLine("Whould you like to start the Quiz Make sure to look at the Guide before you start.");
                Console.WriteLine();
                Console.WriteLine("Start - 1");
                Console.WriteLine();
                Console.WriteLine("Look at Guide - 2");
                Console.WriteLine();
                //lets the user interact with the menu
                String UserInput = Console.ReadLine();

                if (UserInput == "1") // if the user input equals 1 the console will clear and quiz will Start.
                {
                    Console.Clear();
                    StartQuiz();
                }
            

                if (UserInput == "2")// if the user input equals 1 the console will clear and the guide will show.
                {
                    Console.Clear();
                    ShowGuide();
                }


            }
            
            // Shows the user a guide for the quiz

            void ShowGuide()
            {   
                // Tells the User how to play.
                Console.WriteLine("These are the rules:");
                Console.WriteLine();
                Console.WriteLine("Each Question awards 10 points");
                Console.WriteLine();
                Console.WriteLine("your mark will be reduce by 2 for every letter wrong");
                Console.WriteLine();
                Console.WriteLine("your final mark will be given as a percentage");
                Console.WriteLine();
                Console.WriteLine("The Awards are as follows:");
                Console.WriteLine("Bronze = 40% ");
                Console.WriteLine("silver = 60%");
                Console.WriteLine("gold = 80%");
                Console.WriteLine("platinum = 100%");
                Console.WriteLine();
                Console.WriteLine("Remember to put a capital in the beginning of a word");
                Console.WriteLine("press enter");
                //clears the console and goes back to the intro menu when you press enter.
                Console.ReadLine();
                Console.Clear();
                Intromessage();

            } 

            //lets the player start the Quiz
            void StartQuiz()
            {
                int Qnum = 1;
                OverallPlayerScore = 0;
                
                for (int i = 0; i < Questions.Length; i++, Qnum++)
                {
                    
                    Console.Clear();

                    //displaying question
                    if (i >= 1) // if the quiz is on the second question or higher show the player score
                    {
                        Console.WriteLine();
                        Console.WriteLine("current score: {0}",OverallPlayerScore);// displays the player score
                        Console.WriteLine();
                    }
                    Console.WriteLine("Question {0}. {1}?",Qnum,Questions[i]);//displays the question

                    //The Users Anwser 

                    Console.WriteLine("Your Anwser:");
                    String UserInput = Console.ReadLine();
                    char[] Check = Anwsers[i].ToCharArray();// converts the anwser into a array of characters
                    char[] UserChar = UserInput.ToCharArray();// converts the input into a array of characters


                    void TryAgain() //give the player a hint and lets them try again
                    {
                        Console.WriteLine("Hint: the word has {0} letters",Check.Length);
                        Console.WriteLine("Your Anwser:");
                        UserInput = Console.ReadLine();
                    }


                    if (UserInput == "")//if the user has entered nothing
                    {
                        //do nothing
                    }
                    else
                    {


                        while (Check.Length != UserChar.Length)//while the amount of letters dont match try again.Note:this is done to prevent an error.
                        {
                            TryAgain();
                            UserChar = UserInput.ToCharArray();
                        }

                        //if perfect

                        if (UserInput == Anwsers[i]) // if the players anwser was correct give full point
                        {

                            OverallPlayerScore = OverallPlayerScore + HighestQuestionScore;
                            IsRight[i] = 1;// sets the question as right so it does not appear in feedback

                        }

                       //if wrong how many points to give


                        else if (UserInput != Anwsers[i]) // if the player 
                        {
                            userputs[i] = UserInput;//stores the user input for later


                            OverallPlayerScore = OverallPlayerScore + HighestQuestionScore; 
                            int wrongletter = 0;

                            for (int x = 0; x < Check.Length; x++)// For each letter if they equal user input if not add 1 to wrong letter
                            {



                                if (Check[x] == UserChar[x])
                                {

                                }
                                else
                                {
                                    wrongletter++;

                                }

                            }
                            Console.WriteLine();
                            OverallPlayerScore = OverallPlayerScore - wrongletter;//add question score to overall score
                        }
                    }
                    
                    //Tells the User what to do
                    Console.WriteLine("press enter to Move on to the next question");
                    Console.ReadLine();
                }
                QuizEnd();//finished Quiz
                

            }

            // Gives the player Feedback on what they have done wrong
            void QuizFeedBack()
            {
                int qnum = 1;//question Number.
                int Qright = 0;//questions right.
                int MaxQ = 5;//Max questions.
                Console.WriteLine("You need to do the quiz again again to get a better Reward so here is some feedback:");
                foreach (int x in IsRight) // checks the number of questions.
                {
                    if (IsRight[x] == 1)//checks whether the question is right
                    {
                        Qright = Qright + 1; // adds 1 to the amount of questions right.
                    }
                }

                //For user
                Console.WriteLine();
                Console.WriteLine("You Got {0} Questions perfect out of {1}",Qright,MaxQ);
                Console.WriteLine();

         
                for (int i = 0; i < Questions.Length; i++, qnum++)// check if the question is wrong then outputs
                {
                    
                    
                    if (IsRight[i] == 0)
                    {

                        //either
                        Console.WriteLine();
                        if (userputs[i] == "")
                        {
                            Console.WriteLine("You entered nothing on question {0} so there is no feedback",qnum); //there is no feedback
                        }
                        else
                        {

                            Console.WriteLine("Question {0}: you put {1} when {2} was the right answer",qnum,userputs[i],Anwsers[i]);//or if there is feedback

                        }
                    }
                    
                }

                //for user and returns them the the Quiz end function
                Console.WriteLine();
                Console.WriteLine("press enter to go back");
                Console.ReadLine(); 
                QuizEnd();
            }

            
            //The message when the quiz is finished
            void SAorFB()//Allows the user to select what to do after they are given there percentage and medal
            {
                 //User choice
                 string FeedBack = "1";
                 string startA = "2";

                 //Tells the user what to do on the console
                 Console.WriteLine();
                 Console.WriteLine();
                 Console.Write("See Feedback = 1 ");
                 Console.Write("--- Start again = 2 ");
                 Console.Write("--- exit = Enter ");
                 Console.WriteLine();

                 //user choice
                 String UserInput = Console.ReadLine();

                 if (UserInput == FeedBack) // if user input = 1 show quiz feedback
                 {
                     Console.Clear();
                     QuizFeedBack();
                 }
                    
                 if (UserInput == startA) // if user input = 2 restart quiz
                 {
                     Console.Clear();
                     StartQuiz();
                 }
                    
            }

            void QuizEnd()
            {
                
                
                
                int percentage = OverallPlayerScore % HighestScore * 2;//switches the score into a percentage

                Console.Clear();//clears console
                
                // Which medal the player gets.
                if (percentage == 100)
                {
                    Console.WriteLine("your score is {0}% and you did perfectly so you get a Platinum Medal", percentage);

                    Console.WriteLine();

                    Console.Write("You do not need to do the test again so ");
                }

                else if (percentage >= 80)
                {
                    Console.WriteLine("your score is {0}% and you have achieved a Gold Medal", percentage);
                    SAorFB();
                }

                else if (percentage >= 60)
                {
                    Console.WriteLine("your score is {0}% and you have achieved a Silver Medal", percentage);
                    SAorFB();
                }

                else if (percentage >= 40)
                {
                    Console.WriteLine("your score is {0}% and you have achieved a Bronze Medal", percentage);
                    SAorFB();
                }

                else if (percentage == 0)
                {
                    Console.WriteLine("your score is {0}% and you have achieved no Medal", percentage);
                    SAorFB();
                }

                

            }

            


            //starts the programme
           
            Intromessage();
            


        }
    }
}
