﻿using GlobbingImages.Classes;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace GlobbingImages;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

}
