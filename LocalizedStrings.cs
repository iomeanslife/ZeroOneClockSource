using BinaryClockTry1.Resources;

namespace BinaryClockTry1
{
    /// <summary>
    /// Bietet Zugriff auf Zeichenfolgenressourcen.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        static public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}