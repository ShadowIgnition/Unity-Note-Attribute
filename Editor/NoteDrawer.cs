// https://github.com/ShadowIgnition/Unity-Note-Attribute
using UnityEditor;
using UnityEngine;

namespace SI.Note
{
    [CustomPropertyDrawer(typeof(NoteAttribute))]
    public class NoteDrawer : DecoratorDrawer
    {
        // <summary>
        /// Overrides OnGUI() to draw the note attribute in the Inspector.
        /// </summary>
        /// <param name="position">The position of the drawer in the Inspector.</param>
        public override void OnGUI(Rect position)
        {
            CachePreviewHeight(Attribute.Description, position.width);

            if (m_Height != m_ScrollViewHeight)
            {
                Rect scrollArea = GetRect(position, true);
                Rect content = scrollArea;

                // Adjust xMax to account for vertical scrollbar
                content.xMax -= 14;

                using (var scrollScope = new GUI.ScrollViewScope(position, scrollPos, content))
                {
                    scrollPos = scrollScope.scrollPosition;
                    GUI.Box(content, Attribute.Description, GetNoteStyle());
                }
            }
            else
            {
                GUI.Box(GetRect(position, false), Attribute.Description, GetNoteStyle());
            }
        }

        /// <summary>
        /// Gets the height of the drawer.
        /// </summary>
        /// <returns>The height of the drawer.</returns>
        public override float GetHeight()
        {
            return m_Height;
        }

        /// <summary>
        /// Gets the cached note style.
        /// </summary>
        /// <returns>The GUIStyle for the note.</returns>
        static GUIStyle GetNoteStyle()
        {
            if (Style == null)
            {
                GUIStyle style = GUI.skin.box;
                style.padding = new RectOffset(4, 16, 4, 4);
                style.normal.background = Texture2D.grayTexture;
                style.wordWrap = true;
                style.alignment = TextAnchor.UpperLeft;
                style.richText = true;
                Style = style;
            }
            return Style;
        }

        /// <summary>
        /// Caches the height of the note text area.
        /// </summary>
        /// <param name="note">The note string.</param>
        /// <param name="width">The width of the text area.</param>
        void CachePreviewHeight(string note, float width)
        {
            if (Attribute.LineHeight > 0)
            {
                // If a custom line height is specified, use it
                m_Height = GetPaddedLineHeight(Attribute.LineHeight);
                m_ScrollViewHeight = m_Height;
            }
            else
            {
                // Calculate the height of the text area
                m_Height = GUI.skin.textArea.CalcHeight(new GUIContent(note), width) + (GUI.skin.textArea.lineHeight / 2);

                // Store the unclamped height, so we can use for a scroll view later if needed
                m_ScrollViewHeight = m_Height;

                // Clamp the height within the specified range (Don't want to be able to make the editor preview too big)
                m_Height = Mathf.Clamp(m_Height, GetPaddedLineHeight(AUTO_MIN_HEIGHT), GetPaddedLineHeight(AUTO_MAX_HEIGHT));
            }
        }

        /// <summary>
        /// Gets the rect for drawing the note area.
        /// </summary>
        /// <param name="position">The position of the drawer in the Inspector.</param>
        /// <param name="isScrollView">Flag indicating if the drawer is part of a scroll view.</param>
        /// <returns>The rect for drawing the note area.</returns>
        Rect GetRect(Rect position, bool isScrollView)
        {
            return new Rect(position.x, position.y, position.width, isScrollView ? m_ScrollViewHeight : m_Height);
        }

        /// <summary>
        /// Gets the padded line height based on the number of lines.
        /// </summary>
        /// <param name="lineCount">The number of lines.</param>
        /// <returns>The padded line height.</returns>
        float GetPaddedLineHeight(uint lineCount)
        {
            return (GUI.skin.textArea.lineHeight * lineCount) + (GUI.skin.textArea.lineHeight / 2);
        }

        /// <summary>
        /// Gets the <see cref="NoteAttribute"/> associated with this drawer.
        /// </summary>
        NoteAttribute Attribute { get { return attribute as NoteAttribute; } }

        static GUIStyle Style;

        Vector2 scrollPos; // Current Scroll position
        float m_Height;  // Height of the note text area
        float m_ScrollViewHeight;  // Height of the note text area

        const uint AUTO_MAX_HEIGHT = 5;  // Maximum number of lines for the text area
        const uint AUTO_MIN_HEIGHT = 2;  // Minimum number of lines for the text area
    }
}