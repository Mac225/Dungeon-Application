using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibary
{

    public abstract class Character
    {
        
            
        

        //FIELDS
        private int _life;
        private string _name;
        private int _hitChance;
        private int _block;
        private int _maxLife;

        //PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    //If trying to set a life value less than or equal
                    //to max life, that's fine.
                    _life = value;
                }
                else
                {
                    //Otherwise, if trying to set life higher than 
                    //max life, set it to their max life value instead.
                    _life = MaxLife;
                }
            }
        }
    


    //CONSTRUCTORS
    public Character(string name, int hitChance, int block, int maxLife, int life)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
        }

        //METHODS
        public override string ToString()
        {
            return string.Format("----- {0}--------\n" +
                "Life: {1} of {2}\nHit Chance: {3}%\n" +
                "Block: {4}",
                Name,
                Life,
                MaxLife,
                HitChance,
                Block);
        }

        //Because we intend to use Character as a base class for
        //other, more specific classes (Player & Monster), we want 
        //those classes to have their own versions of the below
        //methods. We can override these methods in those classes 
        //(just like we do with the ToString()), but only if we
        //add the "virtual" modifier to the method signature.

        public virtual int CalcBlock()
        {
            return Block;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            return 0;
        }
    

    }
}
