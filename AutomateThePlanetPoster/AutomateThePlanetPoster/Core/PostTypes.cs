using System.ComponentModel;

namespace AutomateThePlanetPoster.Core
{
    public enum PostTypes
    {
        [Description("D28300")]
        Highlights,
        [Description("339966")]
        QA,
        [Description("7a1f99")]
        Programming,
        [Description("4689D8")]
        DesignAndMethodology,
        [Description("ff66cc")]
        Magazines,       
        [Description("ACF200")]
        Books,
        [Description("9900CC")]
        SoftSkills
    }
}