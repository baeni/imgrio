﻿namespace Fordele.Blazor.Backend.Interfaces
{
    public interface IUploadedFile
    {
        Guid Id { get; }

        string Extension { get; }

        double Size { get; }

        DateTime CreatedAt { get; }

        DateTime ModifiedAt { get; }

        string FancyCreatedOrModified { get; }
    }
}
