# Depths of Unity 24/25
## Linus Ziesel, 1st part of submission

![alt text](Assets/Other_Things/Images/1.png)
*Sample Scene: Here all methods can be tested with button clicks.*

## ExtensionMethods Class Documentation

This class contains various extension methods for Unity objects and components. Here's a breakdown of each method:

### GameObject Array Extensions

- **ArrayToDict** - Converts an array of GameObjects into a Dictionary, using the GameObject names as keys.

### Transform Extensions

- **LookAtCamera** - Makes the transform look at the main camera.
- **ResetRotation** - Resets the transform's rotation to identity (no rotation).
- **ResetChildrenTransform** - Resets the local position of all child objects to zero. If specified, also resets their rotation.
- **LookAtY** - Rotates the transform to look at a target position, but only on the Y-axis.

### GameObject Extensions

- **LogInfo** - Logs the GameObject's name, position, and active state to the console.
- **PrintJoke** - Fetches a random Chuck Norris joke from an API and logs it to the console.
- **GetOrAddComponent<T>** - Gets a component of type T from the GameObject, or adds it if it doesn't exist.

### General Object Extensions

- **Log** - Logs any object to the Unity console.
- **WriteToTempFile** - Writes an object's string representation to a temporary file.

