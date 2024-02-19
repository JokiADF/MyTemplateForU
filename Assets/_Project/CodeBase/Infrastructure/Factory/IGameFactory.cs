using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory
    {
        UniTask<GameObject> CreateHUD();
    }
}