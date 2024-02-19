using _Project.CodeBase.Data;

namespace _Project.CodeBase.Services.Progress
{
    public interface IProgressSaver : IProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}