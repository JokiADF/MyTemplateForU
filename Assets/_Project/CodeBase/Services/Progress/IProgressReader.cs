using _Project.CodeBase.Data;

namespace _Project.CodeBase.Services.Progress
{
    public interface IProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}