using UnityEngine;

namespace _Project.CodeBase.Services.StaticData.Configs
{
    [CreateAssetMenu(menuName = "Configs/Game/Level")]
    public class LevelConfig : ScriptableObject
    {
        public int level;
    }
}