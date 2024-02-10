using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharChange : MonoBehaviour
{
    public List<GameObject> imageObjects;
    private int currentIndex = 0;

    private void Start()
    {
        ShowImage(currentIndex);
    }

    public void NextImage()
    {
        currentIndex = (currentIndex + 1) % imageObjects.Count;
        ShowImage(currentIndex);
    }

    private void ShowImage(int index)
    {
        for (int i = 0; i < imageObjects.Count; i++)
        {
            imageObjects[i].SetActive(i == index);
        }
    }
}
