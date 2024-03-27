﻿using Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityDbContext<AppUser>(options) {
}