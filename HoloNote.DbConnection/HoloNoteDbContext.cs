using HoloNote.Dto;

using Microsoft.EntityFrameworkCore;

namespace HoloNote.DbConnection;

public class HoloNoteDbContext : DbContext
{
    public HoloNoteDbContext(DbContextOptions<HoloNoteDbContext> options) : base(options)
    {
    }
    DbSet<Note> Notes { get; set; }
}
