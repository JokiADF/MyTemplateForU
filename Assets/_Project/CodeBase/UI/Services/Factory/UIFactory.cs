using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Services.Log;
using _Project.CodeBase.UI.Screens;
using _Project.CodeBase.UI.Services.Screens;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private Transform _uiRoot;
        
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assets;
        private readonly ILogService _log;
        
        private ScreenBase _hud;

        public UIFactory(IInstantiator instantiator, IAssetProvider assets, ILogService log)
        {
            _instantiator = instantiator;
            _assets = assets;
            _log = log;
        }

        public async void CreateUIRoot() => 
            _uiRoot = (await InstantiatePrefab(AssetName.UI.Root)).transform;

        public async UniTask<ScreenBase> CreateWindow(ScreenId screenId)
        {
            string assetName = default;

            switch (screenId)
            {
                case ScreenId.Menu: assetName = AssetName.UI.Menu; break;
                case ScreenId.HUD: assetName = AssetName.UI.HUD; break;
                case ScreenId.Result: break;
                default: _log.LogError("Not correct id"); break;
            }
            
            var screen = await InstantiatePrefabForComponent<ScreenBase>(assetName, _uiRoot);
            
            return screen;
        }

        private async UniTask<GameObject> InstantiatePrefab(string assetName)
        {
            var prefab = await _assets.Load<GameObject>(assetName);
            return _instantiator.InstantiatePrefab(prefab);
        }
        
        private async UniTask<TComponent> InstantiatePrefabForComponent<TComponent>(string assetName, Transform parent = null)
            where TComponent : MonoBehaviour
        {
            var prefab = await _assets.Load<GameObject>(assetName);
            return _instantiator.InstantiatePrefabForComponent<TComponent>(prefab, parent);
        }
    }
}