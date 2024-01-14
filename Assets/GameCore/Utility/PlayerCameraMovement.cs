using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameCore.Utility
{
    public class PlayerCameraMovement : MonoBehaviour
    {
        private void Update()
        {
            float horizontalSpeed = 1.0F;
            float verticalSpeed = 1.0F;

            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(0, h, 0);
        }
    }
}
