using System.Security.Cryptography;
using UnityEngine;

public static class GameController
{
    public static string Nickname = "";
    public static float Score = 0;
    public static float LastY = -4.45f;
    public static bool Moved = true;
    public static bool isWinning = true;

    public static void Reset()
    {
        Nickname = "";
        Score = 0;
        LastY = -4.45f;
        Time.timeScale = 1;
        Moved = true;
        isWinning = true;
    }
    public static void TryAgain()
    {
        Score = 0;
        LastY = -4.45f;
        Time.timeScale = 1;
        Moved= true;
        isWinning = true;
    }
}
