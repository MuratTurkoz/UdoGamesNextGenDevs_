using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IgnuxNex.SpaceConqueror
{
    public class MessageDisplayer : MonoBehaviour
    {
        [SerializeField] private GameObject _messagePF;
        [SerializeField] private int _maxMessageToShow = 5;
        protected List<MessageObj> _messageObjs;
        protected List<MessageObj> _activeMessageList;
        [SerializeField] protected float messageDisplayTime = 1f;

        protected virtual void Awake()
        {
            _messageObjs = new List<MessageObj>();
            for (int i = 0; i < _maxMessageToShow; i++)
            {
                GameObject obj = Instantiate(_messagePF, transform);
                obj.SetActive(false);
                _messageObjs.Add(obj.GetComponent<MessageObj>());
            }
            _activeMessageList = new List<MessageObj>();
        }

        public virtual void ShowMessage(string message)
        {
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
            messageObj.Show(message, messageDisplayTime);
            _activeMessageList.Add(messageObj);
        }

        public virtual void ShowMessage(string message, float displayTime)
        {
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
            messageObj.Show(message, displayTime);
            _activeMessageList.Add(messageObj);
        }
    }
}
