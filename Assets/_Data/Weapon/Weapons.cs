using System.Collections.Generic;
using _Data.Scripts;
using _Data.Weapons;
using UnityEngine;

namespace _Data.Weapon
{
    public class Weapons : LocMonoBehaviour
    {
        [SerializeField] protected List<WeaponAbtract> weapons;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadWeapons();
        }
        
        protected virtual void LoadWeapons()
        {
            if (this.weapons.Count > 0) return;
            foreach (Transform child in transform)
            {
                WeaponAbtract weaponAbtract = child.GetComponent<WeaponAbtract>();
                if (weaponAbtract == null) continue;
                this.weapons.Add(weaponAbtract);
            }
        }
        
        public virtual WeaponAbtract GetCurrentWeapon()
        {
            return this.weapons[0];
        }
    }
}
