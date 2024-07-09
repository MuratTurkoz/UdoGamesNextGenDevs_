using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IgnuxNex.SpaceConqueror
{
    public class MessageDisplayerDebugger : MonoBehaviour
    {

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Color messageColor = new Color(Random.Range(0, 4), Random.Range(0, 4), Random.Range(0, 4), 1);
                LogManager.Instance.ShowMessage("Test message", messageColor);
            }        
        }
    }
}
