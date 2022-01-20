namespace LingvoNET;

/// <summary>
///     Словарь наречий
/// </summary>
public static class Adverbs
{
    public static Adverb FindOne(string sourceForm)
    {
        return new Adverb { Word = sourceForm };
    }
}

/// <summary>
///     Наречие
/// </summary>
public class Adverb
{
    /// <summary>
    ///     Разряд наречия
    /// </summary>
    public Comparability Comparability
    {
        get
        {
            if (Word[Word.Length - 1] == 'о')
                return Comparability.Comparable;
            return Comparability.Incomparable;
        }
    }

    //долго-дольше
    //круто-круче
    //свято-свяче
    //легко-легче
    //мягко-мягче
    //мелко-мельче
    //хорошо-лучше
    //плохо-хуже
    //высоко-выше
    //низко-ниже
    //далеко-дальше
    //трудно-труднее трудней

    public string this[Comparison comp]
    {
        get
        {
            var c = Word[Word.Length - 1];
            var @base = Word.Substring(0, Word.Length - 1);
            var po = "по";
            if (char.IsUpper(@base[0]))
            {
                po = "По";
                @base = @base.ToLowerInvariant();
            }

            switch (c)
            {
                case 'о':
                    switch (comp)
                    {
                        case Comparison.Comparative1: return @base + "ее";
                        case Comparison.Comparative2: return po + @base + "ее";
                        case Comparison.Comparative3: return @base + "ей";
                        case Comparison.Comparative4: return po + @base + "ей";
                        case Comparison.Comparative5: return "более " + @base;
                    }

                    return "";
                default:
                    return "";
            }
        }
    }

    public string Word { get; internal set; }
}