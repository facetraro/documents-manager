namespace DocumentsMangerEntities
{
    public enum FontType { Arial, CourierNew, TimesNewRoman, Verdana} ;
    static class FontTypeToHTML
    {
        public static string GetString(this FontType fontType)
        {
            switch (fontType)
            {
                case FontType.Arial:
                    return "arial";
                case FontType.CourierNew:
                    return "courier";
                case FontType.TimesNewRoman:
                    return "times";
                case FontType.Verdana:
                    return "verdana";
            }
            return null;
        }
        public static string GetStringParser(this FontType fontType)
        {
            switch (fontType)
            {
                case FontType.Arial:
                    return "arial";
                case FontType.CourierNew:
                    return "courier-new";
                case FontType.TimesNewRoman:
                    return "times-new-roman";
                case FontType.Verdana:
                    return "verdana";
            }
            return null;
        }
    }
}