using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Services.StaticData
{
    public interface IStaticDataService
    {
        UniTask InitializeAsync();
    }
}