using _Project.CodeBase.Infrastructure.AssetManagement;
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

        private GameObject InstantiatePrefab(string assetName)
        {
            var prefab = _assets.Get<GameObject>(assetName);
            return _instantiator.InstantiatePrefab(prefab);
        }
        
        private TComponent InstantiatePrefabForComponent<TComponent>(string assetName)
            where TComponent : MonoBehaviour
        {
            var prefab = _assets.Get<GameObject>(assetName);
            return _instantiator.InstantiatePrefabForComponent<TComponent>(prefab);
        }
    }
}