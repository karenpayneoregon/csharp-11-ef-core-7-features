﻿namespace WinFormsApp2.Classes;

public static class Extensions
{
    public static IEnumerable<T> Descendants<T>(this Control control) where T : class
    {
        foreach (Control child in control.Controls)
        {
            if (child is T thisControl)
            {
                yield return (T)thisControl;
            }

            if (child.HasChildren)
            {
                foreach (T descendant in Descendants<T>(child))
                {
                    yield return descendant;
                }
            }
        }
    }
}