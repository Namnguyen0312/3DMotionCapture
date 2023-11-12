using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalibrationTimer : MonoBehaviour
{
    public PipeServer server;
    public int timer = 5;
    public KeyCode calibrationKey = KeyCode.C;

    private bool calibrated;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(calibrationKey))
        {
            if(!calibrated)
            {
                calibrated = true;
                StartCoroutine(Timer());
            }
            else
            {
                StartCoroutine(Notify());
            }
        }
    }
    private IEnumerator Timer()
    {
        int t = timer;
        while (t > 0)
        {
            yield return new WaitForSeconds(1f);
            --t;
        }
        Avatar[] a = FindObjectsByType<Avatar>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        foreach(Avatar aa in a)
        {
            aa.Calibrate();
        }
        if (a.Length>0)
        {
            server.SetVisible(false);
        }
        else
        {
        }
        yield return new WaitForSeconds(1.5f);
    }
    private IEnumerator Notify()
    {
        yield return new WaitForSeconds(3f);
    }
}
