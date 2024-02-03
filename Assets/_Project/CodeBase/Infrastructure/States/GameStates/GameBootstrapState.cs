using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameBootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameBootstrapState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public async void Enter()
        {
            await InitializeServices();
            
            _gameStateMachine.Enter<GameLoadingState>();
        }

        private async UniTask InitializeServices()
        {
            await UniTask.Yield();
        }

        public UniTask Exit() =>
            default;
    }
}