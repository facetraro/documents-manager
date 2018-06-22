namespace DocumentsMangerEntities
{
    public enum TextColor { Red, Blue, Black };
    static class TextColorToHTML
    {
        public static string GetString(this TextColor color)
        {
            switch (color)
            {
                case TextColor.Blue:
                    return "blue";
                case TextColor.Black:
                    return "black";
                case TextColor.Red:
                    return "red";
            }
            return null;
        }
        public static string GetStringParser(this TextColor color)
        {
            switch (color)
            {
                case TextColor.Blue:
                    return "0,0,128";
                case TextColor.Black:
                    return "0,0,0";
                case TextColor.Red:
                    return "128,0,0";
            }
            return null;
        }
    }
}