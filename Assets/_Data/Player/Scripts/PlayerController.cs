using _Data.Level;
using _Data.Scripts;
using UnityEngine;
using Invector.vCharacterController;
using UnityEngine.Animations.Rigging;

namespace _Data.Player.Scripts
{
    public class PlayerController : LocSingleton<PlayerController>
    {
        [SerializeField] protected vThirdPersonController thirdPersonCtrl;
        public vThirdPersonController ThirdPersonController => thirdPersonCtrl;

        [SerializeField] protected vThirdPersonCamera thirdPersonCamera;
        public vThirdPersonCamera ThirdPersonCamera => thirdPersonCamera;
        
        [SerializeField] protected CrosshairPointer.CrosshairPointer crosshairPointer;
        public CrosshairPointer.CrosshairPointer CrosshairPointer => crosshairPointer;

        [SerializeField] protected Rig aimingRig;
        public Rig AimingRig => aimingRig;

        [SerializeField] protected Animator animator;
        public Animator Animator => animator;
        
        [SerializeField] protected Weapon.Weapons weapons;
        public Weapon.Weapons Weapons => weapons;

        [SerializeField] protected LevelAbstract level;
        public LevelAbstract Level => level;
        
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadThirdPersonCtrl();
            this.LoadThirdPersonCamera();
            this.LoadCrosshairPointer();
            this.LoadAimingRig();
            this.LoadAnimator();
            this.LoadWeaponController();
            this.LoadLevel();
        }
        
        protected virtual void LoadLevel()
        {
            if (this.level != null) return;
            this.level = GetComponentInChildren<LevelAbstract>();
            Debug.Log(transform.name + ": LoadLevel", gameObject);
        }
        
        protected virtual void LoadAimingRig()
        {
            if (this.aimingRig != null) return;
            this.aimingRig = transform.Find("Model").Find("AimingRig").GetComponent<Rig>();
            Debug.Log(transform.name + ": LoadAimingRig", gameObject);
        }
        
        protected virtual void LoadThirdPersonCtrl()
        {
            if (this.thirdPersonCtrl != null) return;
            this.thirdPersonCtrl = GetComponent<vThirdPersonController>();
            Debug.Log(transform.name + ": LoadThirPersonCtrl", gameObject);
        }
        
        protected virtual void LoadThirdPersonCamera()
        {
            if (this.thirdPersonCamera != null) return;
            this.thirdPersonCamera = GameObject.FindAnyObjectByType<vThirdPersonCamera>();
            this.thirdPersonCamera.rightOffset = 0.6f;
            this.thirdPersonCamera.defaultDistance = 1.3f;
            this.thirdPersonCamera.height = 1.8f;
            this.thirdPersonCamera.yMinLimit = -40f;
            this.thirdPersonCamera.yMaxLimit = 40f;
            Debug.Log(transform.name + ": LoadThirdPersonCamera", gameObject);
        }
        
        protected virtual void LoadCrosshairPointer()
        {
            if (this.crosshairPointer != null) return;
            this.crosshairPointer = GetComponentInChildren<CrosshairPointer.CrosshairPointer>();
            Debug.Log(transform.name + ": LoadCrosshairPointer", gameObject);
        }
        
        protected virtual void LoadAnimator()
        {
            if (this.animator != null) return;
            this.animator = GetComponentInChildren<Animator>();
            Debug.Log(transform.name + ": LoadAnimator", gameObject);
        }
        
        protected virtual void LoadWeaponController()
        {
            if (this.weapons != null) return;
            this.weapons = GetComponentInChildren<Weapon.Weapons>();
            Debug.Log(transform.name + ": LoadWeaponController", gameObject);
        }
    }
}
