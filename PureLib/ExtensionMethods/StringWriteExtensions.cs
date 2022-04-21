namespace PureLib;

public static class StringWriteExtensions
{
    /// <summary>
    /// Writes the string to the file. If file or directory does not exists - it they be created.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    /// /// <exception cref="ArgumentNullException"/>
    /// /// <exception cref="PathTooLongException"/>
    /// /// <exception cref="DirectoryNotFoundException"/>
    /// /// <exception cref="IOException"/>
    /// /// <exception cref="UnauthorizedAccessException"/>
    /// /// <exception cref="NotSupportedException"/>
    public static FileInfo WriteToFile(this string contents, string filePath)
    {
        Directory.CreateDirectory(filePath);
        File.WriteAllText(filePath, contents);
        return new FileInfo(filePath);
    }

    /// <summary>
    /// Writes the string to the file asynchronously. If file or directory does not exists - it they be created.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    /// /// <exception cref="ArgumentNullException"/>
    /// /// <exception cref="PathTooLongException"/>
    /// /// <exception cref="DirectoryNotFoundException"/>
    /// /// <exception cref="IOException"/>
    /// /// <exception cref="UnauthorizedAccessException"/>
    /// /// <exception cref="NotSupportedException"/>
    public static async Task<FileInfo> WriteToFileAsync(this string contents, string filePath)
    {
        Directory.CreateDirectory(filePath);
        await File.WriteAllTextAsync(filePath, contents);
        return new FileInfo(filePath);
    }

    /// <summary>
    /// Appends the string to the end of the file. If file or directory does not exists - it they be created.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    /// /// <exception cref="ArgumentNullException"/>
    /// /// <exception cref="PathTooLongException"/>
    /// /// <exception cref="DirectoryNotFoundException"/>
    /// /// <exception cref="IOException"/>
    /// /// <exception cref="UnauthorizedAccessException"/>
    /// /// <exception cref="NotSupportedException"/>
    public static FileInfo AppendToFile(this string contents, string filePath)
    {
        Directory.CreateDirectory(filePath);
        File.AppendAllText(filePath, contents);
        return new FileInfo(filePath);
    }

    /// <summary>
    /// Appends the string to the end of the file asynchronously. If file or directory does not exists - it they be created.
    /// </summary>
    /// <exception cref="ArgumentException"/>
    /// /// <exception cref="ArgumentNullException"/>
    /// /// <exception cref="PathTooLongException"/>
    /// /// <exception cref="DirectoryNotFoundException"/>
    /// /// <exception cref="IOException"/>
    /// /// <exception cref="UnauthorizedAccessException"/>
    /// /// <exception cref="NotSupportedException"/>
    public static async Task<FileInfo> AppendToFileAsync(this string contents, string filePath)
    {
        Directory.CreateDirectory(filePath);
        await File.AppendAllTextAsync(filePath, contents);
        return new FileInfo(filePath);
    }
}