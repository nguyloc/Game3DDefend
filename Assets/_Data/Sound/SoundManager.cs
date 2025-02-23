using System;
using System.Collections.Generic;
using _Data.Scripts;
using _Data.Sound.Music;
using _Data.Sound.SFX;
using UnityEngine;

namespace _Data.Sound
{
    public class SoundManager : LocSingleton<SoundManager>
    {
        [SerializeField] protected SoundName bgName = SoundName.BackgroundMusicGamePlay;
        [SerializeField] protected MusicController bgMusic;
        [SerializeField] protected SoundSpawnerController soundSpawnerController;
        
        public SoundSpawnerController SoundSpawnerController =>  soundSpawnerController;
        
         [Range(0f, 1f)]
         [SerializeField] protected float volumeMusic = 1f;
        
         [Range(0f, 1f)]
         [SerializeField] protected float volumeSfx = 1f;
         [SerializeField] protected List<MusicController> listMusic;
         [SerializeField] protected List<SfxController> listSfx;
        
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
        
        public virtual void ToggleMusic()
        {
            if (this.bgMusic == null)
            {
                this.StartMusicBackground();
                return;
            }

            bool status = this.bgMusic.gameObject.activeSelf;
            this.bgMusic.gameObject.SetActive(!status);
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
            if (this.listMusic.Contains(newMusic)) return;
            this.listMusic.Add(newMusic);
        }
        
        public virtual SfxController CreateSfx(SoundName soundName)
        {
            SfxController soundPrefab = (SfxController) this.soundSpawnerController.Prefabs.GetByName(soundName.ToString());
            return this.CreateSfx(soundPrefab);
        }
        
        public virtual SfxController CreateSfx(SfxController sfxPrefab)
        {
            SfxController newSfx = (SfxController)this.soundSpawnerController.Spawner.Spawn(sfxPrefab, Vector3.zero);
            this.AddSfx(newSfx);
            return newSfx;
        }
        
        public virtual void AddSfx(SfxController newSound)
        {
            if (this.listSfx.Contains(newSound)) return;
            this.listSfx.Add(newSound);
        }
        
        public virtual void VolumeMusicUpdating(float volume)
        {
            this.volumeMusic = volume;
            foreach(MusicController musicCtrl in this.listMusic)
            {
                musicCtrl.AudioSource.volume = this.volumeMusic;
            }
        }
        
        public virtual void VolumeSfxUpdating(float volume)
        {
            this.volumeSfx = volume;
            foreach (SfxController sfxCtrl in this.listSfx)
            {
                sfxCtrl.AudioSource.volume = this.volumeSfx;
            }
        }
    }
}
