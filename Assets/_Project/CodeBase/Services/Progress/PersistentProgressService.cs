using _Project.CodeBase.Data;

namespace _Project.CodeBase.Services.Progress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}