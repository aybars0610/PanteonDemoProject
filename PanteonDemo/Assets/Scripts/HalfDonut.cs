using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonut : MonoBehaviour
{
    private GameObject stick;
    private GameObject rod;
    private GameObject donut;
    private float rate;
    [SerializeField] private float counter = 2f;
    [SerializeField] private float direction;


    // Start is called before the first frame update
    void Start()
    {
        stick = gameObject.transform.GetChild(0).gameObject;
        rod = stick.transform.GetChild(2).gameObject;
        donut = stick.transform.GetChild(0).gameObject;

        rate = counter;
    }

    // Update is called once per frame
    void Update()
    {
        donut.transform.Rotate(90 * Time.deltaTime, 0, 0);
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            StartCoroutine(Motion());
            counter = rate;
        }
    }

    IEnumerator Motion()
    {
        stick.transform.position += new Vector3(-0.3f * direction, 0, 0);
        rod.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(1.5f, 1, 1), 1f);
        yield return new WaitForSeconds(0.5f);
        stick.transform.position += new Vector3(0.3f * direction, 0, 0);
        rod.transform.localScale = Vector3.Lerp(new Vector3(1.5f, 1, 1), new Vector3(1f, 1, 1), 1f);
    }



}
