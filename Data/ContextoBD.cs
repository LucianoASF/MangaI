using Microsoft.EntityFrameworkCore;

namespace MangaI.Data;

public class ContextoBD : DbContext
{
    public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
    {

    }
    
}
