namespace DocumentsMangerEntities
{
    public enum TextAlignment { Center, Right, Justify, Left };
    static class TextAlignmentToHTML
    {
        public static string GetString(this TextAlignment fontType)
        {
            switch (fontType)
            {
                case TextAlignment.Left:
                    return "left";
                case TextAlignment.Right:
                    return "right";
                case TextAlignment.Center:
                    return "center";
                case TextAlignment.Justify:
                    return "justify";
            }
            return null;
        }
    }
}