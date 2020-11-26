using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BarController : MonoBehaviour
{
    public Transform Bar;
    public Transform TargetGameObject;
    public int currentValue;
    public int maxValue;

    float counter;

    void Start()
    {
        currentValue = 100;
        maxValue = 100;
    }

    void Update()
    {
        if (TargetGameObject != null)
        {
            transform.position = TargetGameObject.position + Vector3.up;
            
        }
    }

    public void resetvalue()
    {
        // Bar.transform.position = transform.position+new Vector3(0.103f,0,0);
        Bar.transform.position = new Vector3(
            Bar.transform.position.x + counter,
            transform.position.y,
            transform.position.z
        );
        
        
        counter = 0;
    }

    public void SetValue(int newValue)
    {
        
        if (newValue<currentValue)
        {
            Bar.transform.position = new Vector3(
                Bar.transform.position.x - 0.104f, 
                Bar.transform.position.y,
                Bar.transform.position.z
            );
            counter += 0.104f;
        }

        currentValue = newValue;
        Bar.localScale = new Vector3((float)((double) currentValue / (double) maxValue), 1.0f, 1.0f);

        //clamp LocalScale min to 0
        if (Bar.localScale.x < 0)
        {
            Bar.localScale = new Vector3(0.0f, 1.0f, 1.0f);
        }
    }
}
