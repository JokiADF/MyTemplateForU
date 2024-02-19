using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Infrastructure.SceneManagement;
using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.CodeBase.Services.Pool;
using _Project.CodeBase.UI.Services.Screens;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.States.GameStates
{
    public class GameLoopState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;
        private readonly IPoolingService _poolingService;
        private readonly IScreenService _screenService;

        public GameLoopState(ILoadingCurtain loadingCurtain, 
            ISceneLoader sceneLoader,
            IAssetProvider assetProvider,
            IPoolingService poolingService,
            IScreenService screenService)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _assetProvider = assetProvider;
            _poolingService = poolingService;
            _screenService = screenService;
        }
        
        public async void Enter()
        {
            _loadingCurtain.Show();
            
            await _assetProvider.WarmupAssetsByLabel(AssetName.Lables.GameLoopState);
            await _sceneLoader.Load(AssetName.Scenes.GameLoopScene);
            
            _screenService.Open(ScreenId.HUD);
            
            _loadingCurtain.Hide();
        }

        public async UniTask Exit()
        {
            _loadingCurtain.Show();
            
            await _assetProvider.ReleaseAssetsByLabel(AssetName.Lables.GameLoopState);
            
            _poolingService.Cleanup();
            _assetProvider.Cleanup();
        }
    }
}