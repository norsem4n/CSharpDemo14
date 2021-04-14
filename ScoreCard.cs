/* Project:         Assignment Set 6 - Program 15
 * Date:            October 2020
 * Developed By:    LV
 * Modified By:     Christopher Karnas
 * Last Modified:   11.20.20
 * Class Name:      ScoreCard
 * Assumption:      The scorecard is for a specific tournament and year
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS605AS6
{
    class ScoreCard
    {
        #region "Constants"

        const string PGATour = "2020 U.S. Open Championship", CourseName = "Winged Foot Golf Club";

        int[] CoursePars = { 4, 4, 3, 4, 4, 4, 3, 4, 5, 3, 4, 5, 3, 4, 4, 4, 4, 4 };

        #endregion

        #region "Properties"

        public string PlayerName { get; private set; }
        public int[,] ScoresByRound { get; private set; }

        #endregion

        #region "Constructor"

        public ScoreCard(string name, int[,] scores)
        {
            PlayerName = name;

            ScoresByRound = scores;
        }

        #endregion

        #region "Methods"

        /* Complete this method to calculate and return the player's status after each hole for a given round.
         * 
         * Status after hole 1 =  Score for hole 1 - Par for hole 1
         * 
         * Status after holes 2 through 18 = 
         * 
         *    Status after previous hole + (Score for current hole - Par for current hole)
        */

        public int[] CalcStatusAfterHole(int round)
        {
            int numHoles = ScoresByRound.GetLength(1);

            int[] overUnder = new int[numHoles];

            overUnder[0] = ScoresByRound[round - 1, 0] - CoursePars[0];

            for (int hole = 1; hole < numHoles; ++hole)
            {
                overUnder[hole] = overUnder[hole - 1] + (ScoresByRound[round - 1, hole] - CoursePars[hole]);
            }
            return overUnder;   
        }

        /* Complete this method to calculate and return the player's average score for holes of a specific par (i.e., 3, 4 or 5).
         * 
         * Player's average score for holes of a specific par = 
         * 
         * Player's total score for holes of a specific par for all 4 rounds / (Total number of holes of a specific par * number of rounds (i.e., 4))
         *           
         *  Note: Do not use a manual count of the number of holes of a specific par.
         *  
         *  Instead, write code to find the number of holes of a specific par.
        */

        public double CalcAverageScoreByPar(int par)
        {
            // assign the pars to a variable

            int numRounds = ScoresByRound.GetLength(0);
            int numHoles = ScoresByRound.GetLength(1);

            int numberOfPars = 0;
            double totalPars = 0;

            for (int hole = 0; hole < numHoles; ++hole)
            {
                if (CoursePars[hole] == par)
                {
                    ++numberOfPars;

                    for (int round = 0; round < numRounds; ++round)
                    {
                        totalPars += ScoresByRound[round, par];
                    }
                }
            }
            return totalPars / (numberOfPars * numRounds);
        }

        /* A player's score for a given hole is "consistent" if it is the same for all four rounds. 
         * 
         * Complete this method to find and return the number of holes for which the player's score was "consistent".
        */

        public int FindNumberOfHolesWithConsistentScore()
        {
            int numRounds = ScoresByRound.GetLength(0);
            int numHoles = ScoresByRound.GetLength(1);

            int consistentHoles = 0;

            for (int hole = 0; hole < numHoles; ++hole)
            {
                bool consistentScores = true;
                for (int round = 0; round < numRounds-1; ++round)
                {
                    if (ScoresByRound[round, hole] != ScoresByRound[round + 1, hole])
                    {
                        consistentScores = false;
                        break;
                    }
                }
                if(consistentScores)
                {
                    ++consistentHoles;
                }
            }
            return consistentHoles;
        }

        /* Complete this method to calculate and return the player's overall performance by score type (i.e., Number of Eagles, Birdies, Pars, Bogeys and Double Bogeys)
         * 
         * Number of Eagles = Count of number of times player's score is two strokes below par
         * 
         * Number of Birdies = Count of number of times player's score is one stroke below par
         * 
         * Number of Pars = Count of number of times player's score is equal to par
         * 
         * Number of Bogeys = Count of number of times player's score is one stroke above par
         * 
         * Number of Double Bogeys = Count of number of times player's score is two strokes above par
         */

        public string CalcPerformanceByScoreType()
        {
            int eagles = 0;
            int birdies = 0;
            int pars = 0;
            int bogeys = 0;
            int doubleBogeys = 0;
            int others = 0;
            string message = string.Empty;

            int numRounds = ScoresByRound.GetLength(0);
            int numHoles = ScoresByRound.GetLength(1);

            for (int hole = 0; hole < numHoles; ++hole)
            {
                for (int round = 0; round < numRounds; ++round)
                {
                    int underOver = (ScoresByRound[round, hole] - CoursePars[hole]);
                    switch (underOver)
                    {
                        case (-2):
                            ++eagles;
                            break;
                        case (-1):
                            ++birdies;
                            break;
                        case (0):
                            ++pars;
                            break;
                        case (1):
                            ++bogeys;
                            break;
                        case (2):
                            ++doubleBogeys;
                            break;
                        default:
                            ++others;
                            break;
                    }
                }
            }
            return message = ($"{eagles} - Eagle(s)\n{birdies} - Birdies\n{pars} - Pars\n{bogeys} - Bogeys\n{doubleBogeys} - Double Bogey(s)\n{others} - other");

            #endregion
        }
    }
}