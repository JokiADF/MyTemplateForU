namespace _Project.CodeBase.Services.Progress
{
    public interface IProgressSaver : IProgressReader
    {
        void UpdateProgress(Data.Progress progress);
    }
}