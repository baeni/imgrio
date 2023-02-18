﻿using Fordele.Blazor.Backend.Interfaces;

namespace Fordele.Blazor.Backend.Models
{
    public class UploadedDocument : IUploadedFile
    {
        public UploadedDocument(Guid id, string extension, double size, DateTime createdAt, DateTime modifiedAt)
        {
            Id = id;
            Extension = extension;
            Size = size;
            CreatedAt = createdAt;
        }

        public Guid Id { get; }

        public string Extension { get; }

        public double Size { get; }

        public DateTime CreatedAt { get; }
    }
}
