using System.Collections.Generic;

namespace Moxie.Core;

public static class HsLexer
{
    /// <summary>
    ///     Lexer the file
    /// </summary>
    /// <param name="text">refer a string[] wich contains all the lines of the text</param>
    /// <returns>All of the tags with their content</returns>
    public static List<Tag> Lexer(string[] text)
    {
        bool isTag = false, isTagValue = false;

        List<Tag> tags = new();
        string tagName = "", tagValue = "";

        foreach (var line in text)
        {
            // Split the line in words, not in character for performance reasons
            var test = line.Split(" ");

            foreach (var word in test)
            {
                // Tag prefix
                if (word.StartsWith('!'))
                {
                    if (!isTag)
                        isTag = true;

                    // Dont add blank tags
                    if (tagName != string.Empty && tagValue != string.Empty)
                    {
                        tags.Add(new Tag { Name = tagName, Value = tagValue });
                        tagValue = "";
                    }
                }

                // Tag suffix
                if (word.StartsWith(':'))
                    if (isTag)
                    {
                        isTag = false;
                        isTagValue = true;
                    }

                if (isTagValue)
                    if (word.Contains(':'))
                        tagValue += word.Split(':')[1];
                    else
                        tagValue += " " + word;

                if (isTag)
                    tagName = word;
            }

            isTag = false;
            isTagValue = false;
        }

        // Add the tag of the last line
        if (tagName != string.Empty && tagValue != string.Empty)
            tags.Add(new Tag { Name = tagName, Value = tagValue });

        // Kernel.bird.WriteLine($"Tags Length: {tags.Count}");

        return tags;
    }

    /// <summary>
    ///     Tag class
    /// </summary>
    public class Tag
    {
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
    }
}