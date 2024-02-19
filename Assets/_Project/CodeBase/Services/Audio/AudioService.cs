using System.Collections.Generic;
using _Project.CodeBase.Services.Audio.Factory;
using _Project.CodeBase.Services.Log;
using UnityEngine;

namespace _Project.CodeBase.Services.Audio
{
    public class AudioService : IAudioService
    {
        private readonly IAudioFactory _audioFactory;
        private readonly ILogService _log;
        private readonly Camera _camera;

        private readonly Dictionary<string, AudioClip> _clips = new();
        private AudioSource _music;

        public AudioService(IAudioFactory audioFactory, 
            ILogService log,
            Camera camera)
        {
            _audioFactory = audioFactory;
            _log = log;
            _camera = camera;
        }

        public void Initialize()
        {
            CreateMusic(); 
            CreateSfxClips();
        }

        public void PlaySfx(string key, float volume)
        {
            if (!_clips.TryGetValue(key, out var clip))
            {
                _log.LogError("Couldn't find the clip");
                return;
            }

            AudioSource.PlayClipAtPoint(clip, _camera.transform.position, volume);
        }

        public void PlayMusic()
        {
            _music.Play();
            
            _log.Log("Music started to play");
        }

        public void StopMusic()
        {
            _music.Stop();
            
            _log.Log("Music stopped to play");
        }

        // Commented out because they are not used and there are no necessary files in the project. Left for example
        private void CreateMusic()
        {
            // var clip = _audioFactory.GetClip(AssetName.Audio.Music);
            //
            // var go = new GameObject("Music");
            // Object.DontDestroyOnLoad(go);
            //
            // _music = go.AddComponent<AudioSource>();
            // _music.clip = clip;
            // _music.spatialBlend = 0;
            // _music.volume = 0;
            // _music.loop = true;
        }
        
        private void CreateSfxClips()
        {
            // _clips.Add(AssetName.Audio.Clash, _audioFactory.GetClip(AssetName.Audio.Clash));
            // _clips.Add(AssetName.Audio.Click, _audioFactory.GetClip(AssetName.Audio.Click));
            // _clips.Add(AssetName.Audio.Explosion, _audioFactory.GetClip(AssetName.Audio.Explosion));
        }
    }
}
