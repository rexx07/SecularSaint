﻿using System.ComponentModel.DataAnnotations;
using SS.Domain.Blog;

namespace SS.Application.Dtos.Common;

public class ImportMessage
{
    public Status Status { get; set; }
    public string Message { get; set; }
}

public class ImportModel
{
    [Required] [Url] public string FeedUrl { get; set; }

    [Required] [Url] public string BaseUrl { get; set; }

    private List<string> FileExtensions { get; set; } = new()
        { "zip", "7z", "xml", "pdf", "doc", "docx", "xls", "xlsx", "mp3", "mp4", "avi" };
}