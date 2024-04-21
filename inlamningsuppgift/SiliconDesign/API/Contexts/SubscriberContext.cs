using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts;

public class SubscriberContext(DbContextOptions<SubscriberContext> options) : DbContext(options) {
    public DbSet<SubscriberEntity> Subscribers { get; set; }
}