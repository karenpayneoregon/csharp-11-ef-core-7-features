﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

using EntityCoreFileLogger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StringSyntaxWithEntityFrameworkCore.Models;
using static StringSyntaxWithEntityFrameworkCore.Classes.Configuration.DataConnections;

namespace StringSyntaxWithEntityFrameworkCore.Data;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<BirthDay> BirthDays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Instance.MainConnection)
            .EnableSensitiveDataLogging()
            .LogTo(new DbContextToFileLogger().Log, new[]
                {
                    DbLoggerCategory.Database.Command.Name
                },
                LogLevel.Information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BirthDay>(entity =>
        {
            entity.Property(e => e.YearsOld).HasComputedColumnSql("((CONVERT([int],format(getdate(),'yyyyMMdd'))-CONVERT([int],format([BirthDate],'yyyyMMdd')))/(10000))", false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}