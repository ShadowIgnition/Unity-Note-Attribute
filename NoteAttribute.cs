// https://github.com/ShadowIgnition/Unity-Note-Attribute
using UnityEngine;

/// <summary>
/// Custom attribute class used for creating Inspector notes
/// </summary>
public class NoteAttribute : PropertyAttribute
{
	/// <summary>
	/// The text contained in the note.
	/// </summary>
	public readonly string Description;

	/// <summary>
	/// The line height for the localized string translation. A value of 0 indicates auto-sizing.
	/// </summary>
	public readonly uint LineHeight = 0;

	/// <summary>
	/// Initializes a new instance of the <see cref="NoteAttribute"/> class with the specified description and (auto-sizing) line height.
	/// </summary>
	/// <param name="description">The text description for the note.</param>
	public NoteAttribute(string description)
	{
		Description = description;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="NoteAttribute"/> class with the specified description and line height.
	/// </summary>
	/// <param name="lineHeight">The line height for the note, A value of 0 indicates auto-sizing.</param>
	/// <param name="description">The text description for the note.</param>
	public NoteAttribute(uint lineHeight, string description)
	{
		Description = description;
		LineHeight = lineHeight;
	}
}

