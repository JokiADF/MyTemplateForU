namespace _Project.CodeBase.Infrastructure.SceneManagement.UI
{
    public class LoadingCurtainProxy : ILoadingCurtain
    {
        private readonly ILoadingCurtain _realSubject;
        
        public LoadingCurtainProxy(ILoadingCurtain realSubject) => 
            _realSubject = realSubject;

        public void Show() => 
            _realSubject.Show();

        public void Hide() => 
            _realSubject.Hide();
    }
}