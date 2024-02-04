using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.Scripts.Infrastructure.SceneManagement;
using CodeBase.Services.AssetManagement;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameHubState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly GameStateMachine _gameStateMachine;

        public GameHubState(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader, GameStateMachine gameStateMachine)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _gameStateMachine = gameStateMachine;
        }
        
        public async void Enter()
        {
            _loadingCurtain.Show();
            
            await _sceneLoader.Load(AssetName.Scenes.GameHubScene);
            _gameStateMachine.Enter<GameLoopState>();
            
            _loadingCurtain.Hide();
        }

        public async UniTask Exit()
        {
            _loadingCurtain.Show();
            
            await UniTask.DelayFrame(1);
        }
    }
}