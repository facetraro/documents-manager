namespace DocumentsMangerEntities
{
    public enum FontType { Arial, CourierNew, TimesNewRoman } ;
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
            }
            return null;
        }
    }
}