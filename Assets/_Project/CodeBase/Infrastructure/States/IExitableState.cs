using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.States
{
    public interface IExitableState
    {
        UniTask Exit();
    }
}