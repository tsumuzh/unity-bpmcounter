using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    Text mainLabel, subLabel;
    bool started;
    float t, average;
    int keyCount;
    void Start()
    {
        mainLabel = GameObject.Find("MainLabel").GetComponent<Text>();
        subLabel = GameObject.Find("SubLabel").GetComponent<Text>();
        mainLabel.text = "Press Space";
        subLabel.text = "";
        started = false;
        t = 0;
        average = 0;
        keyCount = 1;
    }
    void Update()
    {
        if (started) t += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (started)
            {
                average = (average * (keyCount - 1) + t) / keyCount;
                subLabel.text = (t * 1000).ToString("f3") + ", " + subLabel.text;
                t = 0;
                mainLabel.text = "BPM\n" + (60 / average).ToString("f3");
                keyCount++;
            }
            else
            {
                started = true;
                mainLabel.text = "BPM\n-";
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
