using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sign : MonoBehaviour {
    public string signText="?";
    void Start()
    {
        SetText(signText);
    }

    public void SetText(string text)
    {
        foreach (GameObject child in ParentChildFunctions.GetAllChildren(gameObject, true))
            if (child.GetComponent<Text>() != null)
                child.GetComponent<Text>().text = text;
    }
}
