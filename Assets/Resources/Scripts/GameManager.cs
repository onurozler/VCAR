using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    // Reference for UI Elements
    public Text currentCarText;
    public GameObject credits;

    // Reference for GameObjects
    [SerializeField] private List<GameObject> _cars;
    [SerializeField] private GameObject _stage;

    private float _rotationSpeed = 5.0f;

    // Current index for car selection
    private int curIndex = 0;

    void Start()
    {
        // Added Cars to List
       _cars = new List<GameObject>();
       foreach (Transform car in _stage.transform)
       {
           car.gameObject.SetActive(false);
           _cars.Add(car.gameObject);
       }

       // Active current Car
       _cars[curIndex].SetActive(true);
       currentCarText.text = _cars[curIndex].name;
    }

    void Update()
    {
        // Rotate stage
        _stage.transform.Rotate(Vector3.up, Time.deltaTime * _rotationSpeed);
    }


    // Button Events

    public void ChangeCar(bool right)
    {

        // Changing car in UI Right and Left Button

        _cars[curIndex].SetActive(false);
        if (right)
        {
            curIndex++;
            if (curIndex > _cars.Count - 1)
                curIndex = 0;
        }
        else
        {
            curIndex--;
            if (curIndex < 0)
                curIndex = _cars.Count - 1;
        }
        _cars[curIndex].SetActive(true);
        currentCarText.text = _cars[curIndex].name;
    }

    public void ChangeToScene()
    {
        // Change to AR scene
        SceneManager.LoadScene("ARScene");
    }

    public void OpenCredits(bool yes)
    {
        // Open or Close Credits

        if (yes)
        {
            credits.SetActive(true);
        }
        else
        {
            credits.SetActive(false);
        }
    }
}
