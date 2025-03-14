using UnityEngine;
using TMPro;
using System;
using System.Collections;
using Unity.VisualScripting;


public class GameTime : MonoBehaviour
{

    [SerializeField] private int startingTimeHour;
    [SerializeField] private float timeUntilHourChange;
    [SerializeField] private float timeUntilMinuteChange;
    private float resumeHourChange;
    private float resumeMinuteChange;
    [SerializeField] private TMP_Text timeText;

    [NonSerialized] public int timeHours;
    [NonSerialized] public int timeMinutes;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeHours = startingTimeHour;
        StartCoroutine(routine: advanceHourOverTime());
        StartCoroutine(routine: advanceMinuteOverTime());

    }

    // Update is called once per frame
    void Update()
    {
        if (timeMinutes > 9)
        {
            timeText.text = " " + timeHours + ":" + timeMinutes + " PM";
        }
        else
        {
            timeText.text = timeHours + ":0" + timeMinutes + " PM";
        }
    }

    public void PauseTime()
    {
        resumeHourChange = timeUntilHourChange;
        resumeMinuteChange = timeUntilMinuteChange;
        timeUntilHourChange = 99999999999999;
        timeUntilMinuteChange = 99999999999999;
        StopCoroutine(routine: advanceHourOverTime());
        StopCoroutine(routine: advanceMinuteOverTime());
    }

    public void ResumeTime()
    {
        timeUntilHourChange = resumeHourChange;
        timeUntilMinuteChange = resumeMinuteChange;
        StartCoroutine(routine: advanceHourOverTime());
        StartCoroutine(routine: advanceMinuteOverTime());
    }

    private IEnumerator advanceHourOverTime()
    {
        yield return new WaitForSeconds(timeUntilHourChange);

        if (timeHours == 12)
            timeHours = 1;
        else
            timeHours++;
        
        CustomerScoring.Instance.UpdateWaitTime();
        
        StartCoroutine(routine: advanceHourOverTime());
    }

    private IEnumerator advanceMinuteOverTime()
    {
        yield return new WaitForSeconds(timeUntilMinuteChange);

        if (timeMinutes == 59)
            timeMinutes = 0;
        else
            timeMinutes++;

        StartCoroutine(routine: advanceMinuteOverTime());
    }
}
