# TP VUFORIA

# Exercise 2

> What happens when you add the image target representation?

When adding the image target representation, it is displayed on top of the actual image target.

[exo 2_1] [exo 2_2]

> What happens if some of the game objects are affected by the unity physics?

Vuforia Game Objects are affected by the unity physics like any other Game Object. For example, we added a Rigidbody to the Astronaut and noticed him fall when lauching the program.

# Exercise 3

> Explore and explain what the “World Center Mode” option in the VuforiaBehaviour component of the ARCamera game object. 

The "World Center Mode" option define the origin (or anchor point) for the coordinates of the Game Objects. For example when choosing "First Target", the coordinates of the Game Objects associated with the first target will be fixed and the second will depend on the position of the first target. Same with "Specific Target" only it's not necessarily the first target but simply the chosen one.

> Does it impact the behavior you defined in the second exercise?

It has no impact on the behaviour defined in the second exercise.
Target representation is still shown when activated and the game object still falls when given a Rigidbody.

# Exercise 4

> Enable and disable the extended tracking functionality and describe the differences between the two modes.

When "Extended Tracking" is enabled, Vuforia continues to track the image target even after it goes out of the camera's view. 
If it is disabled, tracking is lost when the target is out of view.

# Exercise 5

> Check the contents of the DefaultObserverEventHandler and briefly describe is behavior.

The `DefaultObserverEventHandler` is a component that defines behavior or actions in response to different events that occur during the tracking of targets.
It can be extended to create custom behaviours.
For example, later on, we used `onTargetFound` and `onTargetLost` to change the Game Object displayed whenever the `Image Target` went out of the camera's view.

# Exercise 6

Below is the code we wrote to display a different object every time that the Image Target becomes visible.

```
public class ObserverEventHandler : DefaultObserverEventHandler
{
    int renderedItem = 0;

    protected override void OnTrackingFound()
    {
        if (mObserverBehaviour)
        {
            var rendererComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Renderer, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);
            var colliderComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Collider, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);
            var canvasComponents = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Canvas, DefaultObserverEventHandler>(mObserverBehaviour.gameObject);
            var item = 0;

            // Enable colliders:
            foreach (var component in colliderComponents)
                component.enabled = true;

            // Enable canvas':
            foreach (var component in canvasComponents)
                component.enabled = true;

            // Enable rendering:
            foreach (var component in rendererComponents)
            {
                if (item == renderedItem) component.enabled = true;
                else component.enabled = false;
            }

            renderedItem %= 3;
            renderedItem++;
        }

        OnTargetFound?.Invoke();
    }
}
```

# Exercise

[ex]
