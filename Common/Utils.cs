using System.Text;

namespace CSharpExampleArtGallery;

public class Utils
{
    public static string GetDisplayName(string enumValue)
    {
        StringBuilder displayName = new();
        displayName.Append(enumValue[0]);
        for (int i = 1; i < enumValue.Length; i++)
        {
            if (char.ToUpper(enumValue[i]) == enumValue[i])
            {
                displayName.Append(' ');
            }
            displayName.Append(enumValue[i]);
        }
        return displayName.ToString();
    }
}
