using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IgnuxNex.SpaceConqueror
{
    public class LogManager : MessageDisplayer
    {
        public static LogManager Instance { get; private set; }
        [SerializeField] protected float slideYAmount = 30;
        [SerializeField] protected Color defaultMessageColor = Color.white;

        protected override void Awake()
        {
            base.Awake();
            Instance = this;
        }

        public void ShowMessage(string message, Color messageColor)
        {
            foreach (var msg in _activeMessageList)
            {
                Vector3 pos = msg.transform.position;
                pos.y += slideYAmount;
                msg.transform.position = pos;
            }
            _activeMessageList.RemoveAll(x => !x.gameObject.activeSelf);
            MessageObj messageObj = _messageObjs.Find(x => !x.gameObject.activeSelf);
            if (messageObj == null)
            {
                messageObj = _activeMessageList[0];
                _activeMessageList.RemoveAt(0);
                messageObj.StopDisplay();
            }

            if (messageObj == null)
                return;
            messageObj.Show(message, messageColor, messageDisplayTime);
            _activeMessageList.Add(messageObj);
        }

        public override void ShowMessage(string message)
        {
            ShowMessage(message, defaultMessageColor);
        }

        public void ShowMessage(string message, Color messageColor, float displayTime)
        {
            foreach (var msg in _activeMessageList)
            {
                Vector3 pos = msg.transform.position;
                pos.y += slideYAmount;
                msg.transform.position = pos;
            }
            _activeMessageList.RemoveAll(x => !x.gameObject.activeSelf);
            MessageObj messageObj = _messageObjs.Find(x => !x.gameObject.activeSelf);
            if (messageObj == null)
            {
                messageObj = _activeMessageList[0];
                _activeMessageList.RemoveAt(0);
                messageObj.StopDisplay();
            }

            if (messageObj == null)
                return;
            messageObj.Show(message, messageColor, displayTime);
            _activeMessageList.Add(messageObj);
        }

        public override void ShowMessage(string message, float displayTime)
        {
            ShowMessage(message, defaultMessageColor, displayTime);
        }
    }
}
