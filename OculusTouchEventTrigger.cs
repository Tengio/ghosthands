using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Tengio {
    [AddComponentMenu("Event/Oculus Touch Event Trigger")]
    public class OculusTouchEventTrigger : MonoBehaviour,
        IPointerEnterHandler, 
        IPointerExitHandler, 
        ILeftIndexTriggerHandler, 
        ILeftIndexTriggerDownHandler, 
        ILeftIndexTriggerUpHandler, 
        IRightIndexTriggerHandler, 
        IRightIndexTriggerDownHandler, 
        IRightIndexTriggerUpHandler, 
        ILeftHandTriggerHandler, 
        ILeftHandTriggerDownHandler, 
        ILeftHandTriggerUpHandler, 
        IRightHandTriggerHandler, 
        IRightHandTriggerDownHandler, 
        IRightHandTriggerUpHandler, 
        IAButtonHandler, 
        IAButtonDownHandler, 
        IAButtonUpHandler, 
        IXButtonHandler, 
        IXButtonDownHandler, 
        IXButtonUpHandler, 
        IBButtonHandler, 
        IBButtonDownHandler, 
        IBButtonUpHandler, 
        IYButtonHandler, 
        IYButtonDownHandler, 
        IYButtonUpHandler, 
        ILeftPointerEnterHandler, 
        ILeftPointerExitHandler, 
        IRightPointerEnterHandler, 
        IRightPointerExitHandler {

        [Serializable]
        public class TriggerEvent : UnityEvent<BaseEventData> { }

        [Serializable]
        public class Entry {
            public OculusTouchEventTriggerType eventID = OculusTouchEventTriggerType.PointerEnter;
            public TriggerEvent callback = new TriggerEvent();
        }

        [FormerlySerializedAs("delegates")]
        [SerializeField]
        private List<Entry> m_Delegates;

        //protected EventTrigger() { }

        public List<Entry> triggers {
            get {
                if (m_Delegates == null)
                    m_Delegates = new List<Entry>();
                return m_Delegates;
            }
            set { m_Delegates = value; }
        }

        private void Execute(OculusTouchEventTriggerType id, BaseEventData eventData) {
            for (int i = 0, imax = triggers.Count; i < imax; ++i) {
                var ent = triggers[i];
                if (ent.eventID == id && ent.callback != null)
                    ent.callback.Invoke(eventData);
            }
        }

        #region Events Functions

        public virtual void OnPointerEnter(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.PointerEnter, eventData);
        }

        public virtual void OnPointerExit(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.PointerExit, eventData);
        }

        public virtual void OnLeftPointerEnter(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.LeftPointerEnter, eventData);
        }

        public virtual void OnLeftPointerExit(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.LeftPointerExit, eventData);
        }

        public virtual void OnRightPointerEnter(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.RightPointerEnter, eventData);
        }

        public virtual void OnRightPointerExit(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.RightPointerExit, eventData);
        }

        public virtual void OnLeftIndexTrigger(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.LeftIndexTrigger, eventData);
        }

        public virtual void OnLeftIndexTriggerDown(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.LeftIndexTriggerDown, eventData);
        }

        public virtual void OnLeftIndexTriggerUp(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.LeftIndexTriggerUp, eventData);
        }

        public virtual void OnRightIndexTrigger(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.RightIndexTrigger, eventData);
        }

        public virtual void OnRightIndexTriggerDown(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.RightIndexTriggerDown, eventData);
        }

        public virtual void OnRightIndexTriggerUp(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.RightIndexTriggerUp, eventData);
        }

        public virtual void OnLeftHandTrigger(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.LeftHandTrigger, eventData);
        }

        public virtual void OnLeftHandTriggerDown(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.LeftHandTriggerDown, eventData);
        }

        public virtual void OnLeftHandTriggerUp(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.LeftHandTriggerUp, eventData);
        }

        public virtual void OnRightHandTrigger(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.RightHandTrigger, eventData);
        }

        public virtual void OnRightHandTriggerDown(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.RightHandTriggerDown, eventData);
        }

        public virtual void OnRightHandTriggerUp(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.RightHandTriggerUp, eventData);
        }

        public virtual void OnAButton(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.AButton, eventData);
        }

        public virtual void OnAButtonDown(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.AButtonDown, eventData);
        }

        public virtual void OnAButtonUp(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.AButtonUp, eventData);
        }

        public virtual void OnXButton(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.XButton, eventData);
        }

        public virtual void OnXButtonDown(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.XButtonDown, eventData);
        }

        public virtual void OnXButtonUp(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.XButtonUp, eventData);
        }

        public virtual void OnBButton(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.BButton, eventData);
        }

        public virtual void OnBButtonDown(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.BButtonDown, eventData);
        }

        public virtual void OnBButtonUp(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.BButtonUp, eventData);
        }

        public virtual void OnYButton(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.YButton, eventData);
        }

        public virtual void OnYButtonDown(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.YButtonDown, eventData);
        }

        public virtual void OnYButtonUp(BaseEventData eventData) {
            Execute(OculusTouchEventTriggerType.YButtonUp, eventData);
        }

        #endregion

    }

    public static class OculusTouchEvent {

        #region Execution Handlers

        private static readonly ExecuteEvents.EventFunction<IPointerEnterHandler> s_PointerEnterHandler = Execute;
        private static void Execute(IPointerEnterHandler handler, BaseEventData eventData) {
            handler.OnPointerEnter(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IPointerExitHandler> s_PointerExitHandler = Execute;
        private static void Execute(IPointerExitHandler handler, BaseEventData eventData) {
            handler.OnPointerExit(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<ILeftPointerEnterHandler> s_LeftPointerEnterHandler = Execute;
        private static void Execute(ILeftPointerEnterHandler handler, BaseEventData eventData) {
            handler.OnLeftPointerEnter(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<ILeftPointerExitHandler> s_LeftPointerExitHandler = Execute;
        private static void Execute(ILeftPointerExitHandler handler, BaseEventData eventData) {
            handler.OnLeftPointerExit(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IRightPointerEnterHandler> s_RightPointerEnterHandler = Execute;
        private static void Execute(IRightPointerEnterHandler handler, BaseEventData eventData) {
            handler.OnRightPointerEnter(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IRightPointerExitHandler> s_RightPointerExitHandler = Execute;
        private static void Execute(IRightPointerExitHandler handler, BaseEventData eventData) {
            handler.OnRightPointerExit(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<ILeftIndexTriggerHandler> s_LeftIndexTriggerHandler = Execute;
        private static void Execute(ILeftIndexTriggerHandler handler, BaseEventData eventData) {
            handler.OnLeftIndexTrigger(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<ILeftIndexTriggerDownHandler> s_LeftIndexTriggerDownHandler = Execute;
        private static void Execute(ILeftIndexTriggerDownHandler handler, BaseEventData eventData) {
            handler.OnLeftIndexTriggerDown(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<ILeftIndexTriggerUpHandler> s_LeftIndexTriggerUpHandler = Execute;
        private static void Execute(ILeftIndexTriggerUpHandler handler, BaseEventData eventData) {
            handler.OnLeftIndexTriggerUp(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IRightIndexTriggerHandler> s_RightIndexTriggerHandler = Execute;
        private static void Execute(IRightIndexTriggerHandler handler, BaseEventData eventData) {
            handler.OnRightIndexTrigger(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IRightIndexTriggerDownHandler> s_RightIndexTriggerDownHandler = Execute;
        private static void Execute(IRightIndexTriggerDownHandler handler, BaseEventData eventData) {
            handler.OnRightIndexTriggerDown(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IRightIndexTriggerUpHandler> s_RightIndexTriggerUpHandler = Execute;
        private static void Execute(IRightIndexTriggerUpHandler handler, BaseEventData eventData) {
            handler.OnRightIndexTriggerUp(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<ILeftHandTriggerHandler> s_LeftHandTriggerHandler = Execute;
        private static void Execute(ILeftHandTriggerHandler handler, BaseEventData eventData) {
            handler.OnLeftHandTrigger(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<ILeftHandTriggerDownHandler> s_LeftHandTriggerDownHandler = Execute;
        private static void Execute(ILeftHandTriggerDownHandler handler, BaseEventData eventData) {
            handler.OnLeftHandTriggerDown(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<ILeftHandTriggerUpHandler> s_LeftHandTriggerUpHandler = Execute;
        private static void Execute(ILeftHandTriggerUpHandler handler, BaseEventData eventData) {
            handler.OnLeftHandTriggerUp(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IRightHandTriggerHandler> s_RightHandTriggerHandler = Execute;
        private static void Execute(IRightHandTriggerHandler handler, BaseEventData eventData) {
            handler.OnRightHandTrigger(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IRightHandTriggerDownHandler> s_RightHandTriggerDownHandler = Execute;
        private static void Execute(IRightHandTriggerDownHandler handler, BaseEventData eventData) {
            handler.OnRightHandTriggerDown(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IRightHandTriggerUpHandler> s_RightHandTriggerUpHandler = Execute;
        private static void Execute(IRightHandTriggerUpHandler handler, BaseEventData eventData) {
            handler.OnRightHandTriggerUp(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IAButtonHandler> s_AButtonHandler = Execute;
        private static void Execute(IAButtonHandler handler, BaseEventData eventData) {
            handler.OnAButton(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IAButtonDownHandler> s_AButtonDownHandler = Execute;
        private static void Execute(IAButtonDownHandler handler, BaseEventData eventData) {
            handler.OnAButtonDown(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IAButtonUpHandler> s_AButtonUpHandler = Execute;
        private static void Execute(IAButtonUpHandler handler, BaseEventData eventData) {
            handler.OnAButtonUp(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IXButtonHandler> s_XButtonHandler = Execute;
        private static void Execute(IXButtonHandler handler, BaseEventData eventData) {
            handler.OnXButton(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IXButtonDownHandler> s_XButtonDownHandler = Execute;
        private static void Execute(IXButtonDownHandler handler, BaseEventData eventData) {
            handler.OnXButtonDown(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IXButtonUpHandler> s_XButtonUpHandler = Execute;
        private static void Execute(IXButtonUpHandler handler, BaseEventData eventData) {
            handler.OnXButtonUp(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IBButtonHandler> s_BButtonHandler = Execute;
        private static void Execute(IBButtonHandler handler, BaseEventData eventData) {
            handler.OnBButton(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IBButtonDownHandler> s_BButtonDownHandler = Execute;
        private static void Execute(IBButtonDownHandler handler, BaseEventData eventData) {
            handler.OnBButtonDown(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IBButtonUpHandler> s_BButtonUpHandler = Execute;
        private static void Execute(IBButtonUpHandler handler, BaseEventData eventData) {
            handler.OnBButtonUp(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IYButtonHandler> s_YButtonHandler = Execute;
        private static void Execute(IYButtonHandler handler, BaseEventData eventData) {
            handler.OnYButton(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IYButtonDownHandler> s_YButtonDownHandler = Execute;
        private static void Execute(IYButtonDownHandler handler, BaseEventData eventData) {
            handler.OnYButtonDown(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        private static readonly ExecuteEvents.EventFunction<IYButtonUpHandler> s_YButtonUpHandler = Execute;
        private static void Execute(IYButtonUpHandler handler, BaseEventData eventData) {
            handler.OnYButtonUp(ExecuteEvents.ValidateEventData<BaseEventData>(eventData));
        }

        #endregion

        #region Execution Accessors

        public static ExecuteEvents.EventFunction<IPointerEnterHandler> pointerEnterHandler {
            get { return s_PointerEnterHandler; }
        }

        public static ExecuteEvents.EventFunction<IPointerExitHandler> pointerExitHandler {
            get { return s_PointerExitHandler; }
        }

        public static ExecuteEvents.EventFunction<ILeftPointerEnterHandler> leftPointerEnterHandler {
            get { return s_LeftPointerEnterHandler; }
        }

        public static ExecuteEvents.EventFunction<ILeftPointerExitHandler> leftPointerExitHandler {
            get { return s_LeftPointerExitHandler; }
        }

        public static ExecuteEvents.EventFunction<IRightPointerEnterHandler> rightPointerEnterHandler {
            get { return s_RightPointerEnterHandler; }
        }

        public static ExecuteEvents.EventFunction<IRightPointerExitHandler> rightPointerExitHandler {
            get { return s_RightPointerExitHandler; }
        }

        public static ExecuteEvents.EventFunction<ILeftIndexTriggerHandler> leftIndexTriggerHandler {
            get { return s_LeftIndexTriggerHandler; }
        }

        public static ExecuteEvents.EventFunction<ILeftIndexTriggerDownHandler> leftIndexTriggerDownHandler {
            get { return s_LeftIndexTriggerDownHandler; }
        }

        public static ExecuteEvents.EventFunction<ILeftIndexTriggerUpHandler> leftIndexTriggerUpHandler {
            get { return s_LeftIndexTriggerUpHandler; }
        }

        public static ExecuteEvents.EventFunction<IRightIndexTriggerHandler> rightIndexTriggerHandler {
            get { return s_RightIndexTriggerHandler; }
        }

        public static ExecuteEvents.EventFunction<IRightIndexTriggerDownHandler> rightIndexTriggerDownHandler {
            get { return s_RightIndexTriggerDownHandler; }
        }

        public static ExecuteEvents.EventFunction<IRightIndexTriggerUpHandler> rightIndexTriggerUpHandler {
            get { return s_RightIndexTriggerUpHandler; }
        }

        public static ExecuteEvents.EventFunction<ILeftHandTriggerHandler> leftHandTriggerHandler {
            get { return s_LeftHandTriggerHandler; }
        }

        public static ExecuteEvents.EventFunction<ILeftHandTriggerDownHandler> leftHandTriggerDownHandler {
            get { return s_LeftHandTriggerDownHandler; }
        }

        public static ExecuteEvents.EventFunction<ILeftHandTriggerUpHandler> leftHandTriggerUpHandler {
            get { return s_LeftHandTriggerUpHandler; }
        }

        public static ExecuteEvents.EventFunction<IRightHandTriggerHandler> rightHandTriggerHandler {
            get { return s_RightHandTriggerHandler; }
        }

        public static ExecuteEvents.EventFunction<IRightHandTriggerDownHandler> rightHandTriggerDownHandler {
            get { return s_RightHandTriggerDownHandler; }
        }

        public static ExecuteEvents.EventFunction<IRightHandTriggerUpHandler> rightHandTriggerUpHandler {
            get { return s_RightHandTriggerUpHandler; }
        }

        public static ExecuteEvents.EventFunction<IAButtonHandler> aButtonHandler {
            get { return s_AButtonHandler; }
        }

        public static ExecuteEvents.EventFunction<IAButtonDownHandler> aButtonDownHandler {
            get { return s_AButtonDownHandler; }
        }

        public static ExecuteEvents.EventFunction<IAButtonUpHandler> aButtonUpHandler {
            get { return s_AButtonUpHandler; }
        }

        public static ExecuteEvents.EventFunction<IXButtonHandler> xButtonHandler {
            get { return s_XButtonHandler; }
        }

        public static ExecuteEvents.EventFunction<IXButtonDownHandler> xButtonDownHandler {
            get { return s_XButtonDownHandler; }
        }

        public static ExecuteEvents.EventFunction<IXButtonUpHandler> xButtonUpHandler {
            get { return s_XButtonUpHandler; }
        }

        public static ExecuteEvents.EventFunction<IBButtonHandler> bButtonHandler {
            get { return s_BButtonHandler; }
        }

        public static ExecuteEvents.EventFunction<IBButtonDownHandler> bButtonDownHandler {
            get { return s_BButtonDownHandler; }
        }

        public static ExecuteEvents.EventFunction<IBButtonUpHandler> bButtonUpHandler {
            get { return s_BButtonUpHandler; }
        }

        public static ExecuteEvents.EventFunction<IYButtonHandler> yButtonHandler {
            get { return s_YButtonHandler; }
        }

        public static ExecuteEvents.EventFunction<IYButtonDownHandler> yButtonDownHandler {
            get { return s_YButtonDownHandler; }
        }

        public static ExecuteEvents.EventFunction<IYButtonUpHandler> yButtonUpHandler {
            get { return s_YButtonUpHandler; }
        }

        #endregion

    }

    #region Events Interfaces

    public interface IPointerEnterHandler : IEventSystemHandler {
        void OnPointerEnter(BaseEventData eventData);
    }

    public interface IPointerExitHandler : IEventSystemHandler {
        void OnPointerExit(BaseEventData eventData);
    }

    public interface ILeftHandTriggerDownHandler : IEventSystemHandler {
        void OnLeftHandTriggerDown(BaseEventData eventData);
    }

    public interface ILeftPointerEnterHandler : IEventSystemHandler {
        void OnLeftPointerEnter(BaseEventData eventData);
    }

    public interface ILeftPointerExitHandler : IEventSystemHandler {
        void OnLeftPointerExit(BaseEventData eventData);
    }

    public interface IRightPointerEnterHandler : IEventSystemHandler {
        void OnRightPointerEnter(BaseEventData eventData);
    }

    public interface IRightPointerExitHandler : IEventSystemHandler {
        void OnRightPointerExit(BaseEventData eventData);
    }

    public interface ILeftIndexTriggerHandler : IEventSystemHandler {
        void OnLeftIndexTrigger(BaseEventData eventData);
    }

    public interface ILeftIndexTriggerDownHandler : IEventSystemHandler {
        void OnLeftIndexTriggerDown(BaseEventData eventData);
    }

    public interface ILeftIndexTriggerUpHandler : IEventSystemHandler {
        void OnLeftIndexTriggerUp(BaseEventData eventData);
    }

    public interface IRightIndexTriggerHandler : IEventSystemHandler {
        void OnRightIndexTrigger(BaseEventData eventData);
    }

    public interface IRightIndexTriggerDownHandler : IEventSystemHandler {
        void OnRightIndexTriggerDown(BaseEventData eventData);
    }

    public interface IRightIndexTriggerUpHandler : IEventSystemHandler {
        void OnRightIndexTriggerUp(BaseEventData eventData);
    }

    public interface ILeftHandTriggerHandler : IEventSystemHandler {
        void OnLeftHandTrigger(BaseEventData eventData);
    }

    public interface ILeftHandTriggerUpHandler : IEventSystemHandler {
        void OnLeftHandTriggerUp(BaseEventData eventData);
    }

    public interface IRightHandTriggerHandler : IEventSystemHandler {
        void OnRightHandTrigger(BaseEventData eventData);
    }

    public interface IRightHandTriggerDownHandler : IEventSystemHandler {
        void OnRightHandTriggerDown(BaseEventData eventData);
    }

    public interface IRightHandTriggerUpHandler : IEventSystemHandler {
        void OnRightHandTriggerUp(BaseEventData eventData);
    }

    public interface IAButtonHandler : IEventSystemHandler {
        void OnAButton(BaseEventData eventData);
    }

    public interface IAButtonDownHandler : IEventSystemHandler {
        void OnAButtonDown(BaseEventData eventData);
    }

    public interface IAButtonUpHandler : IEventSystemHandler {
        void OnAButtonUp(BaseEventData eventData);
    }

    public interface IXButtonHandler : IEventSystemHandler {
        void OnXButton(BaseEventData eventData);
    }

    public interface IXButtonDownHandler : IEventSystemHandler {
        void OnXButtonDown(BaseEventData eventData);
    }

    public interface IXButtonUpHandler : IEventSystemHandler {
        void OnXButtonUp(BaseEventData eventData);
    }

    public interface IBButtonHandler : IEventSystemHandler {
        void OnBButton(BaseEventData eventData);
    }

    public interface IBButtonDownHandler : IEventSystemHandler {
        void OnBButtonDown(BaseEventData eventData);
    }

    public interface IBButtonUpHandler : IEventSystemHandler {
        void OnBButtonUp(BaseEventData eventData);
    }

    public interface IYButtonHandler : IEventSystemHandler {
        void OnYButton(BaseEventData eventData);
    }

    public interface IYButtonDownHandler : IEventSystemHandler {
        void OnYButtonDown(BaseEventData eventData);
    }

    public interface IYButtonUpHandler : IEventSystemHandler {
        void OnYButtonUp(BaseEventData eventData);
    }

    #endregion
}
