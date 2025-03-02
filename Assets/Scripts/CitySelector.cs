﻿using System;
using UnityEngine;

/// <summary>
/// Responsible for selecting a city upon a mouse press using raycasting
/// and notifying other scripts of the city that was selected through an event.
/// </summary>
public class CitySelector : MonoBehaviour
{
    public static event Action<City> OnCitySelected;
    //public City SelectedCity => _selectedCity;
    
    [SerializeField] private Camera cam;
    //private City _selectedCity;

    private void Update()
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hitInfo.transform.GetComponent<City>() != null)
                {
                    var city = hitInfo.transform.GetComponent<City>();
                    OnCitySelected?.Invoke(city);
                    //_selectedCity = city;
                }
            }
        }
    }
}
