using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    
    [SerializeField] private float _obs_rot_speed;

    public static float obs_rot_speed;

    private void Start()
    {
        obs_rot_speed = _obs_rot_speed;
    }
}
