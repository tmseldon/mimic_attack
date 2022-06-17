using Game.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class UILabel : MonoBehaviour
    {
        PlayerHealth player;

        // Start is called before the first frame update
        void Start()
        {
            player = FindObjectOfType<PlayerHealth>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(player.transform);
        }
    }
}