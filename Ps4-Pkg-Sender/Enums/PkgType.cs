using PS4_Tools;

namespace Ps4_Pkg_Sender.Enums {

    public enum PkgType {
        Unknown,
        Game = 6,
        Additional_Content = 7,
        Patch = 8,
        Addon_Theme,
    }

    public class Parser { //Just C# things
      
        public static PkgType Parse(string name) {
            switch (name) {
                case "Patch":
                return PkgType.Patch;
                case "Game":
                return PkgType.Game;
                case "Addon_Theme":
                return PkgType.Addon_Theme;
                default:
                return PkgType.Unknown;
            }
        }

        public static PkgType Parse(PKG.SceneRelated.PKGType pKG_Type) {
            switch (pKG_Type) {
                case PKG.SceneRelated.PKGType.Patch:
                return PkgType.Patch;
                case PKG.SceneRelated.PKGType.Game:
                return PkgType.Game;
                case PKG.SceneRelated.PKGType.Addon_Theme:
                return PkgType.Additional_Content;
                // return PkgType.Addon_Theme;
                case PKG.SceneRelated.PKGType.App:
                return PkgType.Game;
                default:
                return PkgType.Unknown;
            }
        }
    }
}
