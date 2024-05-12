using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using System.IO;

namespace EAI_Surfaces_Pack
{
    public class Mod : IMod
    {
        public static ILog log = LogManager.GetLogger($"{nameof(EAI_Surfaces_Pack)}.{nameof(Mod)}").SetShowsErrorsInUI(false);

        private string pathToModFolder;

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info(nameof(OnLoad));

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"Current mod asset at {asset.path}");

            pathToModFolder = $"{new FileInfo(asset.path).DirectoryName}";

            ExtraAssetsImporter.EAI.LoadCustomAssets(pathToModFolder);

        }

        public void OnDispose()
        {
            log.Info(nameof(OnDispose));
            ExtraAssetsImporter.EAI.UnLoadCustomAssets(pathToModFolder);
        }
    }
}
