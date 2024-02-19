using _Project.CodeBase.UI.Screens;
using _Project.CodeBase.UI.Services.Screens;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.UI.Services.Factory
{
  public interface IUIFactory
  {
    void CreateUIRoot();

    UniTask<ScreenBase> CreateWindow(ScreenId screenId);
  }
}