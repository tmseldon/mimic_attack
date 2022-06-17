using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Game.Combat
{
    public class ZoomWeapon : MonoBehaviour
    {
        [SerializeField] Camera cameraFPS;
        [SerializeField] RigidbodyFirstPersonController rbFPSControl;
        [SerializeField] float zoomInFOV = 20f;
        [SerializeField] float zoomOutFOV = 60f;

        [SerializeField] float initialSensitivity = 2f;
        [SerializeField] float sensitivityZoom = 0.5f;

        bool zoomIsToogled = false;

        //private void OnEnable()
        //{
        //    ResetZoom();
        //}

        private void OnDisable()
        {
            ResetZoom();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (zoomIsToogled == false)
                {
                    ApplyZoom();
                }
                else
                {
                    ResetZoom();
                }
            }
        }

        private void ApplyZoom()
        {
            cameraFPS.fieldOfView = zoomInFOV;
            zoomIsToogled = true;

            //Sensibilidad del mouse
            rbFPSControl.mouseLook.XSensitivity = sensitivityZoom;
            rbFPSControl.mouseLook.YSensitivity = sensitivityZoom;
        }

        private void ResetZoom()
        {
            cameraFPS.fieldOfView = zoomOutFOV;
            zoomIsToogled = false;

            //Sensibilidad del mouse
            rbFPSControl.mouseLook.XSensitivity = initialSensitivity;
            rbFPSControl.mouseLook.YSensitivity = initialSensitivity;
        }
    }

}
