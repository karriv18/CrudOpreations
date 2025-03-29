﻿namespace CrudOpreations.Configurations;

public class CrudSettings
{
    public const string SectionName = "UserManagement";

    public required string ModuleKey { get; set; }
     
    public required string UploadDirectory { get; set; }

    public required string ConnectionString { get; set; }

    public required string ModuleCode { get; set; }


}
