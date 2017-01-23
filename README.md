# Ghosthands

Ghosthands is an [Input Module](https://docs.unity3d.com/Manual/InputModules.html) for Unity and Oculus Touch. It allows you to use the Unity [Event System](https://docs.unity3d.com/Manual/EventSystem.html) to send events to GameObjects using your controllers.

To read more about this input module check [our blog](http://tengio.com/blog/crossing-realities-tips-and-tricks).
Here is an extract from it about how to setup the module:

1. Get the [*Unity Package*](https://docs.unity3d.com/Manual/AssetPackages.html) *OculusTouchInputModule.unitypackage* from our Github repository and import it in your project.
2. Create an [*EventSystem*](https://docs.unity3d.com/Manual/EventSystem.html) GameObject in your Scene (`Create > UI > Event System`), remove the *Standalone Input Module* component from it, add an *Oculus Touch Input Module* (`Add Component > Event >  Oculus Touch Input Module`).
3. Drag and drop the *LeftHandAnchor* and *RightHandAnchor* GameObjects from your *OVRCameraRig > TrackingSpace* GameObject into the corresponding slots of the *Oculus Touch Input Module*.
4. Go to any GameObject for which you want to register an event. Make sure that it has a collider (it works fine if it's a trigger collider). Add an *Oculus Touch Event Trigger* component (`Add Component > Event >  Oculus Touch Event Trigger`). And use it as you would for a classic *Event Trigger*!
