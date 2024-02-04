using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.Scripts.Infrastructure.SceneManagement;
using CodeBase.Services.AssetManagement;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;

        public GameLoopState(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
        }
        
        public async void Enter()
        {
            _loadingCurtain.Show();
            
            await _sceneLoader.Load(AssetName.Scenes.GameLoopScene);
            
            _loadingCurtain.Hide();
        }

        public async UniTask Exit()
        {
            _loadingCurtain.Show();
            
            await UniTask.DelayFrame(1);
        }
    }
}