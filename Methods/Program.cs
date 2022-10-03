using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class Program
    {

        static string studio = "Fake Bacon Games";
        static string title = "Not A Real Game";
        static int score = 0;
        static int enemyScore = 10;
        static int scoreMultiplier = 1;
        static int scoreMultiplyItem = 2;
        static int HP = 100;
        static int HPMin = 0;
        static int HPMax = 100;
        static int enemyDMG = 10;
        static int healthKit = 25;
        static int lives = 3;
        static int loseLife = 1;
        static int oneUp = 1;
        static float shield = 0.0f;
        static float shieldDMGReduce = 3.0f;
        static float shieldMin = 0.0f;
        static float shieldFull = 10.0f;
        static int lavaDMG = 100;

        static void Main(string[] args)
        {
            studio = "Fake Bacon Games";
            title = "Not A Real Game";
            score = 0;
            enemyScore = 10;
            scoreMultiplier = 1;
            scoreMultiplyItem = 2;
            HP = 100;
            HPMin = 0;
            HPMax = 100;
            enemyDMG = -10;
            healthKit = 25;
            lives = 3;
            loseLife = -1;
            oneUp = 1;
            shield = 0.0f;
            shieldDMGReduce = 3.0f;
            shieldMin = 0.0f;
            shieldFull = 10.0f;
            lavaDMG = -100;

            RandomizedUpdate();
            RandomizedUpdate();
            RandomizedUpdate();
            RandomizedUpdate();
            RandomizedUpdate();
            RandomizedUpdate();
            RandomizedUpdate();
            RandomizedUpdate();
            RandomizedUpdate();
            RandomizedUpdate();
            Update(0, lavaDMG, 0, 0, 0);
            ShowHud();

            Console.ReadKey(true);
        }


        static void Respawn()
        {
            studio = "Fake Bacon Games";
            title = "Not A Real Game";
            score = 0;
            enemyScore = 10;
            scoreMultiplier = 1;
            scoreMultiplyItem = 1;
            HP = 100;
            HPMin = 0;
            HPMax = 100;
            enemyDMG = -10;
            healthKit = 25;
            lives = 3;
            loseLife = -1;
            oneUp = 1;
            shield = 0.0f;
            shieldDMGReduce = 3.0f;
            shieldMin = 0.0f;
            shieldFull = 10.0f;
            lavaDMG = -1000;
        }


        static void RandomizedUpdate()
        {
            Random rand = new Random();
            int check = rand.Next(1, 6);
            Console.WriteLine(check);
            Console.ReadKey(true);
            if (check == 1)
            {
                //player kills enemy
                Update(enemyScore, 0, 0, 0, 0);
            }else if (check == 2)
            {
                //player gains health kit
                Update(0, healthKit, 0, 0, 0);
            }else if (check == 3)
            {
                //player gets attacked
                Update(0, enemyDMG, 0, 0, 0);
            }else if (check == 4)
            {
                //player finds shield
                Update(0, 0, shieldFull, 0, 0);
            }else if (check == 5)
            {
                //player finds 1up
                Update(0, 0, 0, oneUp, 0);
            }else if (check == 6)
            {
                //player finds multiplier
                Update(0, 0, 0, 0, scoreMultiplyItem);
            }
        }

        static void Update(int deltaScore, int deltaHP, float deltaShield, int deltaLives, int deltaMulti)
        {
            scoreMultiplier = scoreMultiplier + deltaMulti;
            score = score + (deltaScore * scoreMultiplier);

            shield = shield + deltaShield;
            if (shield > shieldFull)
            {
                shield = shieldFull;
            }
            if (shield > 0 && deltaHP < 0)
            {
                shield = shield + (deltaHP / shieldDMGReduce);
            }
            else
            {
                HP = HP + deltaHP;
            }
            if (shield < 0)
            {
                shield = 0;
            }
            lives = lives + deltaLives;
            if (HP <= 0)
            {
                lives = lives - 1;
                Respawn();
            }
            ShowHud();
        }

        static void ShowHud()
        {
            Console.Clear();

            Console.WriteLine(title + " by " + studio);
            Console.WriteLine();
            Console.WriteLine("Score: " + score + " | HP: " + HP + " | Shield: " + shield.ToString("0.00") + " | Lives: " + lives);
            Console.WriteLine();

            Console.ReadKey(true);
        }


    }
}
