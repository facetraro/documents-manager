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
    }
}