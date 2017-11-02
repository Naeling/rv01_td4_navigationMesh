﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour {

    public GameObject p_car;
    public Transform[] t_spawns;
    public Transform[] t_targets;

    public float f_probability;
    public int i_maxCars;
    public float f_spawnCooldown;

    private int i_currentCars;
    private SpawnCounter[] spawnCounters;
         
    private void Start()
    {
    spawnCounters = new SpawnCounter[]{
            new SpawnCounter(0f, f_spawnCooldown, true),
            new SpawnCounter(0f, f_spawnCooldown, true),
            new SpawnCounter(0f, f_spawnCooldown, true),
            new SpawnCounter(0f, f_spawnCooldown, true),
        };
    }


    void FixedUpdate () {

        float delta = Time.fixedDeltaTime;

        // WARNING this foreach loop may be buggy as fuck, if the value is copied in the loop and not the same as in the original array
        foreach (SpawnCounter s in spawnCounters)
        {
            s.DecrementTimer(delta);
        }

        if (i_currentCars < i_maxCars && Random.Range(0f, 1f) < f_probability && IsAvailable())
        {
            int spawnIndex = Random.Range(0, t_spawns.Length + 1);

            while (!spawnCounters[spawnIndex].Available)
            {
                spawnIndex = Random.Range(0, t_spawns.Length + 1);
            }

            GameObject newCar = Instantiate(p_car, t_spawns[spawnIndex].position, Quaternion.identity);
            // WARNING this instruction may be buggy because of the start method not being called if the object is instantiated during runtime ? 
            newCar.GetComponent<NavMeshScript>().UpdateDestination(t_targets[spawnIndex]);
            spawnCounters[spawnIndex].MakeUnavailable();
        }		
	}

    private bool IsAvailable()
    {
        bool isAvailable = false;
        foreach (SpawnCounter s in spawnCounters)
        {
            if (s.Available)
            {
                isAvailable = true;
                break;
            }
        }
        return isAvailable;
    }

    public class SpawnCounter
    {
        private float timer;
        private float maxTimer;
        private bool available;

        public SpawnCounter(float t, float mt, bool a)
        {
            Timer = t;
            MaxTimer = mt;
            Available = a;
        }

        public void MakeUnavailable()
        {
            Timer = MaxTimer;
            Available = false;
        }

        public void MakeAvailable()
        {
            Timer = 0f;
            Available = true;
        }

        public void DecrementTimer(float f)
        {
            Timer -= f;
            if (Timer < 0f)
            {
                MakeAvailable();
            }
        }

        public float Timer
        {
            get
            {
                return timer;
            }

            set
            {
                timer = value;
            }
        }

        public float MaxTimer
        {
            get
            {
                return maxTimer;
            }

            set
            {
                maxTimer = value;
            }
        }

        public bool Available
        {
            get
            {
                return available;
            }

            set
            {
                available = value;
            }
        }
    }
}