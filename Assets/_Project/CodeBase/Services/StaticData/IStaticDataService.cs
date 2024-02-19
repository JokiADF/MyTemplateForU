using System.Collections.Generic;
using _Project.CodeBase.Services.StaticData.Configs;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Services.StaticData
{
    public interface IStaticDataService
    {
        UniTask InitializeAsync();
        PlayerConfig Player { get; }
        Dictionary<int, LevelConfig> Levels { get; }
    }
}