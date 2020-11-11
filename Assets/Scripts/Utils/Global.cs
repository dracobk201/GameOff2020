using UnityEngine;

public static class Global
{
    #region Tags
    public const string PlanetTag = "Planet";
    public const string MoonTag = "Moon";
    #endregion

    #region Axis
    public const string HorizontalAxis = "Horizontal";
    public const string VerticalAxis = "Vertical";
    public const string MouseVerticalAxis = "Mouse X";
    public const string MouseHorizontalAxis = "Mouse Y";
    public const string JumpAxis = "Jump";
    public const string StartAxis = "Submit";
    public const string QuitAxis = "Cancel";
    public const string FireAxis = "Fire1";
    #endregion

    #region Scene Names
    public const string MainMenuScene = "Main Menu";
    public const string LevelScene = "Game";
    #endregion

    #region Constants

    public const double Tolerance = float.Epsilon;

    #endregion

    #region Functions

    public static string ReturnTimeToString(float time)
    {
        var minutes = Mathf.FloorToInt(time / 60f);
        var seconds = Mathf.RoundToInt(time % 60f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        if (seconds <= 0)
            seconds = 0;
        if (minutes <= 0)
            minutes = 0;

        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public static float Clamp0360(float eulerAngles)
    {
        float result = eulerAngles - Mathf.CeilToInt(eulerAngles / 360f) * 360f;
        if (result < 0)
            result += 360f;
        return result;
    }

    #endregion
}
