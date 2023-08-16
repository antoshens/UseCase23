using System.ComponentModel;

namespace UseCase23.Models
{
    public enum Certification
    {
        G = 0,
        PG,
        [Description("PG-13")]
        PG13,
        R,
        [Description("NC-17")]
        NC17,
        U,
        [Description("U/A")]
        UA,
        A,
        S,
        AL,
        [Description("6")]
        _6,
        [Description("9")]
        _9,
        [Description("12")]
        _12,
        [Description("12A")]
        _12A,
        [Description("15A")]
        _15,
        [Description("18")]
        _18,
        [Description("18R")]
        _18R,
        R18,
        R21,
        M,
        [Description("MA15+")]
        MA15Plus,
        R16,
        [Description("R18+")]
        R18Plus,
        X18,
        T,
        E,
        [Description("E10+")]
        E10Plus,
        EC,
        C,
        CA,
        GP,
        [Description("M/PG")]
        MPG,
        [Description("TV-Y")]
        TVY,
        [Description("TV-Y7")]
        TVY7,
        [Description("TV-G")]
        TVG,
        [Description("TV-PG")]
        TVPG,
        [Description("TV-14")]
        TV14,
        [Description("TV-MA")]
        TVMA
    }

    public enum Role
    {
        Director,
        Producer,
        Screenwriter,
        Actor,
        Actress,
        Cinematographer,
        [Description("Film Editor")]
        FilmEditor,
        [Description("Production Designer")]
        ProductionDesigner,
        [Description("Costume Designer")]
        CostumeDesigner,
        [Description("Music Composer")]
        MusicComposer
    }
}
