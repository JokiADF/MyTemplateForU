using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Infrastructure.SceneManagement;
using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.CodeBase.Services.Audio;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.States.GameStates
{
    public class GameLoadingState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;
        private readonly IAudioService _audioService;

        public GameLoadingState(GameStateMachine gameStateMachine,
            ILoadingCurtain loadingCurtain, 
            ISceneLoader sceneLoader, 
            IAssetProvider assetProvider,
            IAudioService audioService)
        {
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _assetProvider = assetProvider;
            _audioService = audioService;
        }
        
        public async void Enter()
        {
            _loadingCurtain.Show();
            
            await _assetProvider.WarmupAssetsByLabel(AssetName.Lables.GameLoadingState);
            await _assetProvider.WarmupAssetsByLabel(AssetName.Lables.Audio);
            await _sceneLoader.Load(AssetName.Scenes.GameLoadingScene);

            InitializeGameWorld();
            
            _gameStateMachine.Enter<GameHubState>();
            
            _loadingCurtain.Hide();
        }

        public async UniTask Exit()
        {
            _loadingCurtain.Show();
            
            await _assetProvider.ReleaseAssetsByLabel(AssetName.Lables.GameLoadingState);
        }

        private void InitializeGameWorld() => 
            _audioService.Initialize();
    }
}