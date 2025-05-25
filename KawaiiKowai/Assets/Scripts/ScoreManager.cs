using UnityEngine;

public static class ScoreManager
{
    public static int score;
    public static void InitGame()
    {
        score = 0;
    }

    public static void AddScore(int input)
    {
        score += input;
    }
}
