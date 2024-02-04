namespace CodeBase.Services.AssetManagement
{
    public static class AssetName
    {
        public class Lables
        {
            public const string Configs = "Configs";
            public const string GameLoadingState = "GameLoadingState";
            public const string GameHubState = "GameHubState";
            public const string GameLoopState = "GameLoopState";
        }

        public class Scenes
        {
            public const string GameLoadingScene = "1GameLoading";
            public const string GameHubScene = "2GameHub";
            public const string GameLoopScene = "3GameLoop";
        }
        
        public class Objects
        {
            public const string Player = "Player";
            public const string Enemy = "Enemy";
            public const string Ball = "Ball";
            public const string Explosion = "Explosion";
        }

        public class UI
        {
            public const string Menu = "Menu";
            public const string Scores = "Scores";
            public const string Gameplay = "Gameplay";
            public const string Input = "Input";
            public const string Results = "Results";
        }

        public class Audio
        {
            public const string Click = "Click";
            public const string Music = "Music";
            public const string Clash = "Clash";
            public const string Explosion = "Explosion";
        }

        public class Materials
        {
            public const string Background = "Space";
        }
    }
}
