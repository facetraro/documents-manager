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
    }
}