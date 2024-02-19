using System.Collections.Generic;
using System.Linq;
using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Services.Log;
using _Project.CodeBase.Services.StaticData.Configs;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ILogService _logService;
        
        public PlayerConfig Player { get; private set; }
        public Dictionary<int, LevelConfig> Levels { get; private set; }

        public StaticDataService(IAssetProvider assetProvider, ILogService logService)
        {
            _assetProvider = assetProvider;
            _logService = logService;
        }

        public async UniTask InitializeAsync()
        {
            var tasks = new List<UniTask>
            {
                LoadPlayerConfig(),
                LoadLevelConfigs()
            };

            await UniTask.WhenAll(tasks);
            
            _logService.Log("Static data loaded");
        }

        private async UniTask LoadPlayerConfig()
        {
            var configs = await GetConfigs<PlayerConfig>();
            if(configs.Length > 0)
                Player = configs.First();
            else
                _logService.LogError("There are no player config founded!");
        }
        
        private async UniTask LoadLevelConfigs()
        {
            var configs = await GetConfigs<LevelConfig>();
            Levels = configs.ToDictionary(config => config.level, config => config);
        }

        private async UniTask<TConfig[]> GetConfigs<TConfig>() where TConfig : class
        {
            var keys = await GetConfigKeys<TConfig>();
            return await _assetProvider.LoadAll<TConfig>(keys);
        }

        private async UniTask<List<string>> GetConfigKeys<TConfig>() => 
            await _assetProvider.GetAssetsListByLabel<TConfig>(AssetName.Lables.Configs);
    }
}