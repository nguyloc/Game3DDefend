using _Data.Scripts;
using UnityEngine;

namespace _Data.Level
{
    public abstract class LevelAbstract : LocMonoBehaviour
    {
        [SerializeField] protected int currentLevel = 1;
        public int CurrentLevel => currentLevel;

        [SerializeField] protected int maxLevel = 100;
        [SerializeField] protected int nextLevelExp;

        protected abstract int GetCurrentExp();
        protected abstract bool DeductExp(int exp);
        
        // public cho slider su dung
        public int NextLevelExp => this.GetNextLevelExp(); 
        public int CurrentExp => this.GetCurrentExp(); 
       
        
        
        protected virtual void FixedUpdate()
        {
            this.Leveling();
        }

        protected virtual void Leveling()
        {
            if (this.currentLevel >= this.maxLevel) return;
            if (this.GetCurrentExp() < this.GetNextLevelExp()) return;
            if (!this.DeductExp(this.GetNextLevelExp())) return;
            this.currentLevel++;
        }

        protected virtual int GetNextLevelExp()
        {
            return this.nextLevelExp = this.currentLevel * 10;
        }
    }
}
