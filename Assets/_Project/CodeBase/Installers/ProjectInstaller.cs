using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.Scripts.Infrastructure.SceneManagement;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private LoadingCurtain prefab;
    
    public override void InstallBindings()
    {
        BindSceneLoader();
        BindLoadingCurtains();
        BindGameStateMachine();
    }

    private void BindSceneLoader()
    {
        Container
            .BindInterfacesAndSelfTo<SceneLoader>()
            .AsSingle();
    }

    private void BindLoadingCurtains()
    {
        var loadingCurtain = Instantiate(prefab);
        
        Container
            .BindInterfacesAndSelfTo<LoadingCurtain>()
            .FromInstance(loadingCurtain)
            .AsSingle();
    }

    private void BindGameStateMachine()
    {
        Container
            .Bind<GameStateMachine>()
            .AsSingle();
        Container
            .Bind<StatesFactory>()
            .AsSingle();
    }
}