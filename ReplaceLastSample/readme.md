# StringExtensions class Documentation
## Namespace
`ReplaceLastSample.Classes`
## Class
`public static partial class StringExtensions`
### Methods
#### `public static string ReplaceLast(this string source, string find, string replace)`
**Summary:**
Replaces the last occurrence of a specified string within the given string.
**Parameters:**
- `source` (string): The string to search within.
- `find` (string): The string to find case-sensitive.
- `replace` (string): The string to replace the found string with.
**Returns:**
- `string`: A new string with the last occurrence of the specified string replaced.
#### `public static string RemoveExtraSpaces(this string source, bool trimEnd = false)`
**Summary:**
Removes extra spaces from the given string, optionally trimming the end.
**Parameters:**
- `source` (string): The string from which to remove extra spaces.
- `trimEnd` (bool, optional): If set to `true`, trims the end of the resulting string.
**Returns:**
- `string`: A new string with extra spaces removed.
#### `public static string TrimLastCharacter(this string sender)`
**Summary:**
Trims the last character from the given string.
**Parameters:**
- `sender` (string): The string from which to trim the last character.
**Returns:**
- `string`: A new string with the last character removed, or the original string if it is null or whitespace.
### Private Methods
#### `private static partial Regex ExtraSpacesRegex()`
**Summary:**
Provides a regular expression to match sequences of two or more whitespace characters.
**Returns:**
- `Regex`: A `Regex` object that matches sequences of two or more whitespace characters.
**Remarks:**
Pattern:
