using DungeonLibary;

using System.Numerics;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using DungeonLibrary;

namespace TestProject1
{
    public class DungeonTests
    {

        [Fact]
        public void TestMonsterCalcDamage()
        {
            

            Dog dog = new Dog("Doggy", 25, 25, 50, 20,
                  2, 8, "That's not a small dog! Look at its long teeth!",
                  true);

            int actualDamage = dog.CalcDamage();

            Assert.True(actualDamage >= dog.MinDamage && actualDamage <= dog.MaxDamage);



        }

        [Fact]
        public void Test2()
        {

            Wasp wasp = new Wasp("BuzzKill", 25, 30, 70, 8, 1, 8, "Extra stingy");

            int actualDamage = wasp.CalcDamage();

            Assert.True(actualDamage >= wasp.MinDamage && actualDamage <= wasp.MaxDamage);



        }

        [Fact]
        public void Test3()
        {

            Ferret ferret = new Ferret("Bear", 17, 25, 50, 10, 1, 4, "A large fat ferret", 3, 10);
            int actualDamage = ferret.CalcDamage();

            Assert.True(actualDamage >= ferret.MinDamage && actualDamage <= ferret.MaxDamage);

        }

        [Fact]
        public void Test4()
        {

            Rat rat = new Rat("Sneaky", 10, 20, 65, 20, 1, 15, "The fattest rat.", true);

            int actualDamage = rat.CalcDamage();

            Assert.True(actualDamage >= rat.MinDamage && actualDamage <= rat.MaxDamage);


        }

        [Fact]
        public void Test5()
        {
            Ant ant = new Ant("Small", 10, 20, 65, 19, 1, 15, "Small but strong.");

            int actualDamage = ant.CalcDamage();

            Assert.True(actualDamage >= ant.MinDamage && actualDamage <= ant.MaxDamage);



        }

    }
    }