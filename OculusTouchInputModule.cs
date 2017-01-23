using Tengio;
using UnityEngine;
using UnityEngine.EventSystems;

// The list of possiblew events is available in OculusTouchEventTriggerType enum class.
// Note: If you are listening for both PointerEnter and LeftPointerEnter (RightPointerEnter) on the same object, there is no guaranty of which event will trigger first.
namespace Tengio {
    [AddComponentMenu("Event/Oculus Touch Input Module")]
    public class OculusTouchInputModule : BaseInputModule {

        [Tooltip("Objects farther than this from the controller will not be detected (in Unity units).")]
        [SerializeField]
        private float maxRaycastDistance = 200f;
        [Tooltip("Width of the sphere raycast. Use 0 to raycast instead of shperecast.")]
        [Range(0F, 0.25F)]
        [SerializeField]
        private float raycastRadius = 0.05F; // Note: From Unity doc: "SphereCast will not detect colliders for which the sphere overlaps the collider.", so don't use a value too big or small objects will pass through.
        [Tooltip("Layer(s) on which the controller can send events.")]
        [SerializeField]
        private LayerMask raycastMask = -1; // Default to Everything.
        [SerializeField]
        private Transform leftHandAnchor;
        [SerializeField]
        private Transform rightHandAnchor;
        [Tooltip("Draw lines from each controller in the forward direction.")]
        [SerializeField]
        private bool debugLines = false;

        private LineRenderer lineRendererLeft;
        private LineRenderer lineRendererRight;
        private GameObject leftGameObject;
        private GameObject rightGameObject;
        private GameObject previousLeftGameObject;
        private GameObject previousRightGameObject;
        private bool isActive = false;

        private const float debugLineDefaultWidth = 0.005F;

        protected override void OnValidate() {
            base.OnValidate();

            InitializeDebugLine(ref lineRendererLeft, leftHandAnchor);
            InitializeDebugLine(ref lineRendererRight, rightHandAnchor);

            UpdateDebugLineParameters(lineRendererLeft);
            UpdateDebugLineParameters(lineRendererRight);
        }

        private void InitializeDebugLine(ref LineRenderer line, Transform hand) {
            line = hand.gameObject.GetComponent<LineRenderer>();
            if (line == null) {
                line = hand.gameObject.AddComponent<LineRenderer>();
            }
        }

        private void UpdateDebugLineParameters(LineRenderer lineRenderer) {
            if (debugLines) {
                float lineWidth = debugLineDefaultWidth;
                if (raycastRadius != 0F) {
                    lineWidth = raycastRadius * 2F;
                }
                lineRenderer.startWidth = lineWidth;
                lineRenderer.endWidth = lineWidth;
                lineRenderer.enabled = true;
            } else {
                lineRenderer.enabled = false;
            }
        }

        /// @cond
        public override bool ShouldActivateModule() {
            bool activeState = base.ShouldActivateModule();
            if (activeState != isActive) {
                isActive = activeState;
            }
            return activeState;
        }
        /// @endcond

        public override void Process() {
            CastRayFromControllerToTarget();
            UpdateCurrentObject();
            HandleTriggers();
            HandleButtons();
        }

        private void CastRayFromControllerToTarget() {
            previousLeftGameObject = leftGameObject;
            previousRightGameObject = rightGameObject;
            leftGameObject = GetControllerRaycastTarget(true);
            rightGameObject = GetControllerRaycastTarget(false);
        }

        private void UpdateCurrentObject() {
            // Send PointerEnter when: 
            //      L Enter GO and R isn't on GO (and conversely) 
            // Send PointerExit when: 
            //      L Exit GO and R isn't on GO (and conversely)
            if (previousLeftGameObject != null) {
                if (leftGameObject != previousLeftGameObject) {
                    if (previousLeftGameObject != rightGameObject) {
                        ExecuteEvents.Execute(previousLeftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.pointerExitHandler);
                    }
                    ExecuteEvents.Execute(previousLeftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.leftPointerExitHandler);
                }
            }
            if (leftGameObject != null) {
                if (leftGameObject != previousLeftGameObject) {
                    if (leftGameObject != rightGameObject) {
                        ExecuteEvents.Execute(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.pointerEnterHandler);
                    }
                    ExecuteEvents.Execute(previousLeftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.leftPointerEnterHandler);
                }
            }
            if (previousRightGameObject != null) {
                if (rightGameObject != previousRightGameObject) {
                    if (previousRightGameObject != leftGameObject) {
                        ExecuteEvents.Execute(previousRightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.pointerExitHandler);
                    }
                    ExecuteEvents.Execute(previousLeftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.rightPointerExitHandler);
                }
            }
            if (rightGameObject != null) {
                if (rightGameObject != previousRightGameObject) {
                    if (rightGameObject != leftGameObject) {
                        ExecuteEvents.Execute(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.pointerEnterHandler);
                    }
                    ExecuteEvents.Execute(previousLeftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.rightPointerEnterHandler);
                }
            }
        }

        private void HandleTriggers() {
            if (leftGameObject != null) {
                // Index Trigger
                if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.leftIndexTriggerHandler);
                }
                if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.leftIndexTriggerDownHandler);
                }
                if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.leftIndexTriggerUpHandler);
                }

                // Hand Trigger
                if (OVRInput.Get(OVRInput.RawButton.LHandTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.leftHandTriggerHandler);
                }
                if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.leftHandTriggerDownHandler);
                }
                if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.leftHandTriggerUpHandler);
                }
            }

            if (rightGameObject != null) {
                // Index Trigger
                if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.rightIndexTriggerHandler);
                }
                if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.rightIndexTriggerDownHandler);
                }
                if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.rightIndexTriggerUpHandler);
                }

                // Hand Trigger
                if (OVRInput.Get(OVRInput.RawButton.RHandTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.rightHandTriggerHandler);
                }
                if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.rightHandTriggerDownHandler);
                }
                if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.rightHandTriggerUpHandler);
                }
            }
        }

        private void HandleButtons() {
            if (leftGameObject != null) {
                if (OVRInput.Get(OVRInput.Button.Three)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.xButtonHandler);
                }
                if (OVRInput.Get(OVRInput.Button.Four)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.yButtonHandler);
                }
                if (OVRInput.GetDown(OVRInput.Button.Three)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.xButtonDownHandler);
                }
                if (OVRInput.GetDown(OVRInput.Button.Four)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.yButtonDownHandler);
                }
                if (OVRInput.GetUp(OVRInput.Button.Three)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.xButtonUpHandler);
                }
                if (OVRInput.GetUp(OVRInput.Button.Four)) {
                    ExecuteEvents.ExecuteHierarchy(leftGameObject, new BaseEventData(eventSystem), OculusTouchEvent.yButtonUpHandler);
                }
            }

            if (rightGameObject != null) {
                if (OVRInput.Get(OVRInput.Button.One)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.aButtonHandler);
                }
                if (OVRInput.Get(OVRInput.Button.Two)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.bButtonHandler);
                }
                if (OVRInput.GetDown(OVRInput.Button.One)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.aButtonDownHandler);
                }
                if (OVRInput.GetDown(OVRInput.Button.Two)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.bButtonDownHandler);
                }
                if (OVRInput.GetUp(OVRInput.Button.One)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.aButtonUpHandler);
                }
                if (OVRInput.GetUp(OVRInput.Button.Two)) {
                    ExecuteEvents.ExecuteHierarchy(rightGameObject, new BaseEventData(eventSystem), OculusTouchEvent.bButtonUpHandler);
                }
            }
        }

        private GameObject GetControllerRaycastTarget(bool leftController) {
            Vector3 controllerDirection;
            Vector3 controllerPosition;
            LineRenderer lineRenderer = null;
            if (leftController) {
                controllerDirection = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch) * Vector3.forward;
                controllerPosition = leftHandAnchor.position;
                if (debugLines) {
                    lineRenderer = lineRendererLeft;
                }
            } else {
                controllerDirection = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward;
                controllerPosition = rightHandAnchor.position;
                if (debugLines) {
                    lineRenderer = lineRendererRight;
                }
            }

            if (lineRenderer != null) {
                lineRenderer.SetPosition(0, controllerPosition);
                lineRenderer.SetPosition(1, controllerPosition + controllerDirection * maxRaycastDistance);
            }

            Ray ray = new Ray(controllerPosition, controllerDirection);
            RaycastHit hit;
            bool gotValidTarget = false;
            if (raycastRadius != 0F) {
                gotValidTarget = Physics.SphereCast(ray, raycastRadius, out hit, maxRaycastDistance, raycastMask);
            } else {
                gotValidTarget = Physics.Raycast(ray, out hit, maxRaycastDistance, raycastMask);
            }

            if (gotValidTarget) {
                return hit.collider.gameObject;
            }

            return null;
        }
    }
}