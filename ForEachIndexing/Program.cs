﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using ForEachIndexing.Classes;

namespace ForEachIndexing;

internal partial class Program
{
    static void Main(string[] args)
    {
        //FindInvalidLinesInFileExample2();

        ReadOnlySpan<string> lines = File.ReadAllLines("CountryCodes.txt");

        var listEnumerator = lines.GetEnumerator();

        for (var index = 0; listEnumerator.MoveNext(); index++)
        {
            var line = listEnumerator.Current;

            Console.WriteLine($"{index, -5}{line}");

            var parts = line.Split(',');
            if (parts.Length < 2)
            {
                Console.WriteLine($"Line {index + 1} is invalid: {line}");
            }
        }

        //FindInvalidLinesInFileExample2();


        Console.ReadLine();
    }

    /// <summary>
    /// Each line in the file should have country name and country two-letter code separated by comma.
    /// but several lines do not, they are missing two-letter code separated by comma.
    /// </summary>
    private static void FindInvalidLinesInFileExample1()
    {
        var lines = File.ReadAllLines("CountryCodes.txt");

        foreach (var (line, index) in lines.Select((line, index) => (value: line, i: index)))
        {
            var parts = line.Split(',');
            if (parts.Length < 2)
            {
                Console.WriteLine($"Line {index + 1} is invalid: {line}");
            }
        }
    }


    /// <summary>
    /// Reads the lines from the "CountryCodes.txt" file and finds invalid
    /// lines that do not have a country name and country two-letter code
    /// separated by a comma.
    /// </summary>
    private static void FindInvalidLinesInFileExample2()
    {
        Span<string>.Enumerator enumerator = File.ReadAllLines("CountryCodes.txt").AsSpan().Enumerator();

        for (var index = 0; enumerator.MoveNext(); index++)
        {
            var line = enumerator.Current;

            var parts = line.Split(',');
            if (parts.Length < 2)
            {
                Console.WriteLine($"Line {index + 1} is invalid: {line}");
            }
        }
    }

    private static void FindInvalidLinesInFileWithIndexExample()
    {
        var lines = File.ReadAllLines("CountryCodes.txt");
        foreach (var (line, index) in lines.IncludeIndex())
        {
            var parts = line.Split(',');
            if (parts.Length < 2)
            {
                Console.WriteLine($"Line {index + 1} is invalid: {line}");
            }

        }
    }
    private static void StartWithSplitMonthNamesExample()
    {

        {
            List<string> list = [.. DateTimeFormatInfo.CurrentInfo.MonthNames[..^1]];

            foreach (var month in list)
            {

            }
        }

        {
            List<string> list = [.. DateTimeFormatInfo.CurrentInfo.MonthNames[..^1]];
            foreach (var month in list.Select((month, index) => (value: month, i: index + 1)))
            {

            }
        }

    }
    /// <summary>
    /// Change zero base index to one base index
    /// </summary>
    private static void SplitMonthNamesExample()
    {
        List<string> list = [.. DateTimeFormatInfo.CurrentInfo.MonthNames[..^1]];
        foreach (var (month, index) in list.Select((month, index) => (value: month, i: index + 1)))
        {
            Console.WriteLine($"{index,-3}{month}");
        }
    }

    /// <summary>
    /// This version is optimal for performance by Marc Gravell
    /// </summary>
    private static void SplitMonthNamesExample1()
    {
        Span<string> span = CollectionsMarshal.AsSpan([.. DateTimeFormatInfo.CurrentInfo.MonthNames[..^1]]);
        for (int index = 0; index < span.Length; index++)
        {
            Console.WriteLine($"{index,-3}{span[index]}");
        }

        
    }

    /// <summary>
    /// Split each path in the path environment variable
    /// </summary>
    private static void SplitPathExample()
    {
        var paths = Environment.GetEnvironmentVariable("Path")!.Split(";");
        foreach (var (part, index) in paths.Select((part, index) => (value: part, i: index)))
        {
            Console.WriteLine($"{index,-3}{part}");
        }
    }

    private static void SplitPathExample1()
    {
        Span<string> span = CollectionsMarshal.AsSpan(Environment.GetEnvironmentVariable("Path")!.Split(";").ToList());
        for (int index = 0; index < span.Length; index++)
        {
            Console.WriteLine($"{index,-3}{span[index]}");
        }
    }
}

public static class Extensions
{
    public static IEnumerable<(T senderType, int index)> IncludeIndex<T>(this IEnumerable<T> source)
        => source.Select((item, index)
            => (item, index));
}
