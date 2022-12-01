using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour{

    public bool sampleBool;
    private static Singleton _instance;

    public static Singleton Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            _instance = GameObject.FindObjectOfType<Singleton>();

            if (_instance == null)
            {
                GameObject go = new GameObject(nameof(Singleton));
                _instance = go.AddComponent<Singleton>();
            }
            return _instance;
        }
    }

    void SampleUsage() {
        Singleton.Instance.sampleBool = true;
    }
}