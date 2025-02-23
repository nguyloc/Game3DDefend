using _Data.Scripts;
using _Data.Sound.Music;
using UnityEngine;

namespace _Data.Sound
{
    public class SoundManager : LocSingleton<SoundManager>
    {
        [SerializeField] protected SoundName bgName = SoundName.BackgroundMusicGamePlay;
        [SerializeField] protected MusicController bgMusic;
        [SerializeField] protected SoundSpawnerController soundSpawnerController;
        public SoundSpawnerController SoundSpawnerController =>  soundSpawnerController;
        
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSoundSpawnerController();
        }
        
        protected virtual void LoadSoundSpawnerController()
        {
            if (this.soundSpawnerController != null) return;
            this.soundSpawnerController = GameObject.FindAnyObjectByType<SoundSpawnerController>();
            Debug.Log(transform.name + ": LoadSoundSpawnerCtrl", gameObject);
        }
        
        public virtual void StartMusicBackground()
        {
            if (this.bgMusic == null) this.bgMusic = this.CreateMusic(this.bgName);
            this.bgMusic.gameObject.SetActive(true);
        }
        
        public virtual MusicController CreateMusic(SoundName soundName)
        {
            MusicController soundPrefab = (MusicController)this.soundSpawnerController.Prefabs.GetByName(soundName.ToString());
            return this.CreateMusic(soundPrefab);
        }
        
        public virtual MusicController CreateMusic(MusicController musicPrefab)
        {
            MusicController newMusic = (MusicController)this.soundSpawnerController.Spawner.Spawn(musicPrefab, Vector3.zero);
            this.AddMusic(newMusic);
            return newMusic;
        }
        
        public virtual void AddMusic(MusicController newMusic)
        {
            //if (this.listMusic.Contains(newMusic)) return;
            //this.listMusic.Add(newMusic);
        }
    }
}
