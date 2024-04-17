using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeData : MonoBehaviour
{

    public CubeBehaviour myCubeData;

    private bool onlyOnce = false;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = myCubeData.cubeColor;
    }

    void Update()
    {
        if(myCubeData.enableRandomColor && !onlyOnce)
        {
            StartCoroutine(RandomColor());
            onlyOnce = true;
        }
        transform.Rotate(new Vector3(0f, myCubeData.rotationSpeed * Time.deltaTime, 0f)); 
    }

    IEnumerator RandomColor()
    {
        if (myCubeData.enableRandomColor)
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
            StartCoroutine(RandomColor());
        }
    }
}
