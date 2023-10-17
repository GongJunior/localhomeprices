using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

class HousingDb : DbContext
{
    public DbSet<RequestEvent> RequestEvents => Set<RequestEvent>();
    public DbSet<HousingDetail> HousingDetails => Set<HousingDetail>();
    public HousingDb(DbContextOptions<HousingDb> options) : base(options){}
}