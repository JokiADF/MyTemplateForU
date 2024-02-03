using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.Scripts.Infrastructure.SceneManagement;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameLoadingState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly GameStateMachine _gameStateMachine;

        public GameLoadingState(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader, GameStateMachine gameStateMachine)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _gameStateMachine = gameStateMachine;
        }
        
        public async void Enter()
        {
            _loadingCurtain.Show();
            
            await _sceneLoader.Load("1GameLoading");
            _gameStateMachine.Enter<GameHubState>();
            
            _loadingCurtain.Hide();
        }

        public async UniTask Exit()
        {
            _loadingCurtain.Show();
            
            await UniTask.DelayFrame(1);
        }
    }
}