using System.ComponentModel;

namespace AutomateThePlanetPoster.Core
{
    public enum PostTypes
    {
        [Description("D28300")]
        [Title(Value = "Highlights")]
        Highlights,
        [Description("339966")]
        [Title(Value = "Quality Assurance and Automation")]
        QA,
        [Description("7a1f99")]
        [Title(Value = "Programming")]
        Programming,
        [Description("4689D8")]
        [Title(Value = "Design And Methodology")]
        DesignAndMethodology,
        [Description("ff66cc")]
        [Title(Value = "Magazines")]
        Magazines,       
        [Description("ACF200")]
        [Title(Value = "Books")]
        Books,
        [Description("9900CC")]
        [Title(Value = "Soft Skills")]
        SoftSkills,
        [Description("669900")]
        [Title(Value = "Productivity")]
        Productivity,
        NA
    }
}