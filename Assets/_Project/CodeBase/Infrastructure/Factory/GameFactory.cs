using System.Threading.Tasks;
using _Project.CodeBase.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assets;

        public GameFactory(IInstantiator instantiator, IAssetProvider assets)
        {
            _instantiator = instantiator;
            _assets = assets;
        }

        public async UniTask<GameObject> CreateHUD() => 
            await InstantiatePrefab(AssetName.UI.HUD);

        private async Task<GameObject> InstantiatePrefab(string assetName)
        {
            var prefab = await _assets.Load<GameObject>(assetName);
            return _instantiator.InstantiatePrefab(prefab);
        }
    }
}