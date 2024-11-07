using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int totalPoints = 0;
    public TextMeshProUGUI pointsText;

    public void UpdatePoints(int points)
    {
        //when method is called, add points amount to total and display new value
        totalPoints += points;
        pointsText.text = totalPoints.ToString();
    }
}
