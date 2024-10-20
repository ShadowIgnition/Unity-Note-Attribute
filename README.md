# Note Attribute

The `NoteAttribute` is a custom attribute used for creating Inspector notes in Unity, helpful in streamlining design processes.

![Note Attribute](preview.png)

## Usage
To use the `NoteAttribute`, follow these steps:

1. Attach the `NoteAttribute` to a serialized field in a MonoBehaviour script or a ScriptableObject.
2. Provide the note description as a string parameter when creating an instance of the `NoteAttribute`.
3. Optionally, you can specify the line height for the note by providing a `uint` value as the second parameter. A value of 0 indicates auto-sizing.

In this example, the `NoteAttribute` is attached to the `myField` serialized field in the `MyScript` MonoBehaviour. The provided note description will be displayed in the Unity Inspector for the `myField` field.

```csharp
using SI.Note 
{
	public class MyScript : MonoBehaviour
	{
		[Note("This is a note for the field.")]
		public int myField;

		[Note(3, "This is a note with a custom line height.")]
		public int myField;
	}
}
```

4. Save your script and go back to the Unity Editor. Open the Inspector for the object that contains the script you just modified.

5. In the Inspector, you will now see a note above the associated field.

## How to add to your Unity Project via Package Manager

To add this your package to your Unity project via the Package Manager, follow these steps:

1. Open your Unity project.
2. Open the Package Manager window by going to `Window > Package Manager`.
3. Click on the `+` button in the top left corner of the Package Manager window.
4. Select "Add package from git URL...".
5. In the text field that appears, enter the URL of your repository, adding `.git` to the end of the url. (Example: `https://github.com/ShadowIgnition/Unity-Note-Attribute.git`)
6. Click the `Add` button.

The package will now be added to your project!


## Customization
You can customize the appearance and behavior of the note drawer by modifying the following constants in the `NoteDrawer` class:

- `AUTO_MAX_HEIGHT`: Maximum number of lines for the note text area (auto-sizing only).
- `AUTO_MIN_HEIGHT`: Minimum number of lines for the note text area (auto-sizing only).

You can also modify the `GetNoteStyle` method to change the visual style of the note box.

## Notes

- The `NoteAttribute` is purely for preview purposes in the Unity Inspector and does not affect the runtime behavior of your game or application.

- If you find the `NoteAttribute` helpful, please consider giving it a star on the GitHub repository. Your support is greatly appreciated!

## License

The `NoteAttribute` is provided as-is under the terms of the MIT License. Feel free to modify and adapt it to suit your needs.
