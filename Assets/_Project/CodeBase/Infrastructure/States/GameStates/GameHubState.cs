using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Infrastructure.SceneManagement;
using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.CodeBase.UI.Services.Screens;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.States.GameStates
{
    public class GameHubState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;
        private readonly IScreenService _screenService;

        public GameHubState(GameStateMachine gameStateMachine,
            ILoadingCurtain loadingCurtain, 
            ISceneLoader sceneLoader, 
            IAssetProvider assetProvider,
            IScreenService screenService)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _assetProvider = assetProvider;
            _gameStateMachine = gameStateMachine;
            _screenService = screenService;
        }
        
        public async void Enter()
        {
            _loadingCurtain.Show();
            
            await _assetProvider.WarmupAssetsByLabel(AssetName.Lables.GameHubState);
            await _sceneLoader.Load(AssetName.Scenes.GameHubScene);
            
            _screenService.Open(ScreenId.Menu);
            
            _loadingCurtain.Hide();
        }

        public async UniTask Exit()
        {
            _loadingCurtain.Show();
            
            await _assetProvider.ReleaseAssetsByLabel(AssetName.Lables.GameHubState);
        }
    }
}