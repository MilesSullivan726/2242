using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalPoints : MonoBehaviour
{
	public int finalPoints;
	public TextMeshProUGUI pointsText;


	public void FinalPointCount()
	{
		//find points manager object and get the final points to display
		finalPoints = GameObject.Find("Point Manager").GetComponent<PointManager>().totalPoints;
		pointsText.text = finalPoints.ToString();
	}
}
